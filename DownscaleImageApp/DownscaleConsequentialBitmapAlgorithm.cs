using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace DownscaleImageApp
{
    class DownscaleConsequentialBitmapAlgorithm
    {
        public static Bitmap DownscaleConsequentialBitmap(Bitmap sourceBitmap, int targetWidth, int targetHeight)
        {
            Bitmap resizedBitmap = new Bitmap(targetWidth, targetHeight, PixelFormat.Format32bppRgb);

            BitmapData sourceData = sourceBitmap.LockBits(
                new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format32bppRgb
            );

            BitmapData destinationData = resizedBitmap.LockBits(
                new Rectangle(0, 0, targetWidth, targetHeight),
                ImageLockMode.WriteOnly,
                PixelFormat.Format32bppRgb
            );

            int sourcePixelSize = 4;
            float scaleX = (float)sourceBitmap.Width / targetWidth;
            float scaleY = (float)sourceBitmap.Height / targetHeight;

            unsafe
            {
                byte* srcPtr = (byte*)sourceData.Scan0;
                byte* destPtr = (byte*)destinationData.Scan0;

                for (int y = 0; y < targetHeight; y++)
                {
                    for (int x = 0; x < targetWidth; x++)
                    {
                        int srcX = (int)(x * scaleX);
                        int srcY = (int)(y * scaleY);
                        int srcIndex = (srcY * sourceData.Stride) + (srcX * sourcePixelSize);

                        int destIndex = (y * destinationData.Stride) + (x * sourcePixelSize);

                        for (int p = 0; p < sourcePixelSize; p++)
                        {
                            destPtr[destIndex + p] = srcPtr[srcIndex + p];
                        }
                    }
                }
            }

            sourceBitmap.UnlockBits(sourceData);
            resizedBitmap.UnlockBits(destinationData);

            return resizedBitmap;

        }
    }
}
