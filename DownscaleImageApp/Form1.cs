using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DownscaleImageApp
{
    public partial class DownscaleImageApp : Form
    {
        public DownscaleImageApp()
        {
            InitializeComponent();

            buttonStartDownscalingParallel.Enabled = false;
            buttonStartDownscalingConsequential.Enabled = false;
            buttonSaveDownscaledImage.Enabled = false;
            numericDowncsalingFactor.Enabled = false;

            numericDowncsalingFactor.ValueChanged += numericDownscalingFactor_Changed;

            //buttonSaveDownscaledImage.Click += buttonSaveDownscaledImage_Click;
        }

        private void numericDownscalingFactor_Changed(object sender, EventArgs e)
        {
            //bool isFactorValid = numericDowncsalingFactor.Enabled && numericDowncsalingFactor.Value > 0;

            if(numericDowncsalingFactor.Enabled == true)
            {
                buttonStartDownscalingParallel.Enabled = true;
                buttonStartDownscalingConsequential.Enabled = true;
                buttonSaveDownscaledImage.Enabled = true;
            }

        }

        private void buttonSelectImage_Click(object sender, EventArgs e)
        {
            if (pictureBoxDownscaled.Image != null)
            {
                pictureBoxDownscaled.Image.Dispose();
                pictureBoxDownscaled.Image = null;
            }

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select an Image";
                openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    numericDowncsalingFactor.Enabled = true;
                    numericDownscalingFactor_Changed(sender, e);

                    try
                    {
                        using (var fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                        {
                            using (var ms = new MemoryStream())
                            {
                                fs.CopyTo(ms);
                                ms.Position = 0;
                                pictureBoxOriginal.Image?.Dispose();
                                pictureBoxOriginal.Image = new Bitmap(ms);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to load image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void buttonStartDownscalingConsequential_Click(object sender, EventArgs e)
        {
            var originalImageControl = pictureBoxOriginal.Image;
            if (originalImageControl == null)
            {
                MessageBox.Show("Please load an image before resizing.", "No Source Image", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double scaleValue = Convert.ToDouble(numericDowncsalingFactor.Value) / 100.0;

            if (scaleValue == 0)
            {
                var unchangedImage = new Bitmap(pictureBoxOriginal.Image);
                DisplayNewImage(pictureBoxDownscaled, unchangedImage);
                MessageBox.Show("Scale factor cannot be 0. The image will remain unchanged.", "Invalid Scale Factor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (scaleValue <= 0 || scaleValue > 10)
            {
                MessageBox.Show("Please enter a scale factor between 0 and 1000 (percent).", "Scale Factor Out of Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int targetWidth = (int)(originalImageControl.Width * scaleValue);
            int targetHeight = (int)(originalImageControl.Height * scaleValue);

            Bitmap sourceBitmap = originalImageControl as Bitmap;
            Bitmap newBitmap = DownscaleConsequentialBitmapAlgorithm.DownscaleConsequentialBitmap(sourceBitmap, targetWidth, targetHeight);

            DisplayNewImage(pictureBoxDownscaled, newBitmap);
            DisplayCompletionMessage();

        }

        private void buttonStartDownscalingParallel_Click(object sender, EventArgs e)
        {
            var originalImageControl = pictureBoxOriginal.Image;
            if (originalImageControl == null)
            {
                MessageBox.Show("Please load an image before resizing.", "No Source Image", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var timer = Stopwatch.StartNew();

            double scaleValue = Convert.ToDouble(numericDowncsalingFactor.Value) / 100.0;
            int targetWidth = (int)(originalImageControl.Width * scaleValue);
            int targetHeight = (int)(originalImageControl.Height * scaleValue);

            Bitmap inputBitmap = originalImageControl as Bitmap;
            Bitmap newBitmap = DownscaleParallelBitmapAlgorithm.DownscaleParallelBitmap(inputBitmap, targetWidth, targetHeight);

            timer.Stop();

            DisplayNewImage(pictureBoxDownscaled, newBitmap);
            DisplayPerformance(timer.ElapsedMilliseconds);
        }

        private static void CopyPixelData(BitmapData sourceData, BitmapData destinationData, byte[] pixels, int originalX, int originalY, int x, int y, int pixelSize)
        {
            int sourceIndex = (originalY * sourceData.Stride) + (originalX * pixelSize);
            int destinationIndex = (y * destinationData.Stride) + (x * pixelSize);
            Array.Copy(pixels, sourceIndex, pixels, destinationIndex, pixelSize);
        }

        private void DisplayNewImage(PictureBox pictureBox, Image image)
        {
            if (pictureBox.Image != null)
            {
                pictureBox.Invoke(new Action(() =>
                {
                    pictureBox.Image?.Dispose();
                    pictureBox.Image = image;
                }));
            }
            else
            {
                pictureBox.Image?.Dispose();
                pictureBox.Image = image;
            }
        }

        private void DisplayCompletionMessage()
        {
            MessageBox.Show("Resizing operation completed.", "Operation Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DisplayPerformance(long milliseconds)
        {
            MessageBox.Show($"Resizing operation completed successfully.\nTotal time: {milliseconds} ms.", "Operation Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void buttonSaveDownscaledImage_Click(object sender, EventArgs e)
        {
            if (pictureBoxDownscaled.Image == null)
            {
                MessageBox.Show("There is no downscaled image to save.", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Save Downscaled Image";
                saveFileDialog.Filter = "JPEG Image|*.jpg|Bitmap Image|*.bmp|GIF Image|*.gif|PNG Image|*.png";
                saveFileDialog.FileName = "downscaled_image";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ImageFormat format = ImageFormat.Png;
                    switch (Path.GetExtension(saveFileDialog.FileName).ToLower())
                    {
                        case ".jpg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                        case ".gif":
                            format = ImageFormat.Gif;
                            break;
                        case ".png":
                            format = ImageFormat.Png;
                            break;
                    }

                    pictureBoxDownscaled.Image.Save(saveFileDialog.FileName, format);
                }
            }
        }

    }
}
