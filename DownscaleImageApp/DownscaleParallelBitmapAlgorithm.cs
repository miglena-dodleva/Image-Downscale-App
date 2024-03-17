using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;

namespace DownscaleImageApp
{
    internal class DownscaleParallelBitmapAlgorithm
    {
        public static Bitmap DownscaleParallelBitmap(Bitmap inputBitmap, int targetWidth, int targetHeight)
        {
            Bitmap outputBitmap = new Bitmap(targetWidth, targetHeight, PixelFormat.Format32bppRgb);

            BitmapData inputData = inputBitmap.LockBits(new Rectangle(0, 0, inputBitmap.Width, inputBitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);
            BitmapData destinationData = outputBitmap.LockBits(new Rectangle(0, 0, targetWidth, targetHeight), ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);

            int sourcePixelSize = 4;
            byte[] sourcePixels = new byte[inputData.Stride * inputBitmap.Height];
            Marshal.Copy(inputData.Scan0, sourcePixels, 0, sourcePixels.Length);

            float xRatio = (float)inputBitmap.Width / targetWidth;
            float yRatio = (float)inputBitmap.Height / targetHeight;

            int processorCount = Environment.ProcessorCount;
            var resizingThreads = new Thread[processorCount];

            for (int i = 0; i < processorCount; i++)
            {
                int threadIndex = i;
                resizingThreads[i] = new Thread(() =>
                {
                    for (int y = threadIndex * targetHeight / processorCount; y < (threadIndex + 1) * targetHeight / processorCount; y++)
                    {
                        for (int x = 0; x < targetWidth; x++)
                        {
                            int sourcePosX = (int)(x * xRatio);
                            int sourcePosY = (int)(y * yRatio);
                            int destIndex = (y * destinationData.Stride) + (x * sourcePixelSize);
                            int sourceIndex = (sourcePosY * inputData.Stride) + (sourcePosX * sourcePixelSize);

                            for (int byteIndex = 0; byteIndex < sourcePixelSize; byteIndex++)
                            {
                                Marshal.WriteByte(destinationData.Scan0, destIndex + byteIndex, Marshal.ReadByte(inputData.Scan0, sourceIndex + byteIndex));
                            }
                        }
                    }
                });
                resizingThreads[i].Start();
            }

            foreach (Thread t in resizingThreads)
            {
                t.Join();
            }

            inputBitmap.UnlockBits(inputData);
            outputBitmap.UnlockBits(destinationData);

            return outputBitmap;
        }
    }
}
