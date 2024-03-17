namespace DownscaleImageApp
{
    partial class DownscaleImageApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelDownscaleFactor = new System.Windows.Forms.Label();
            this.numericDowncsalingFactor = new System.Windows.Forms.NumericUpDown();
            this.pictureBoxOriginal = new System.Windows.Forms.PictureBox();
            this.pictureBoxDownscaled = new System.Windows.Forms.PictureBox();
            this.buttonSelectImage = new System.Windows.Forms.Button();
            this.buttonStartDownscalingConsequential = new System.Windows.Forms.Button();
            this.buttonStartDownscalingParallel = new System.Windows.Forms.Button();
            this.buttonSaveDownscaledImage = new System.Windows.Forms.Button();
            this.openFileDialogImage = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.numericDowncsalingFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDownscaled)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDownscaleFactor
            // 
            this.labelDownscaleFactor.AutoSize = true;
            this.labelDownscaleFactor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDownscaleFactor.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelDownscaleFactor.Location = new System.Drawing.Point(328, 60);
            this.labelDownscaleFactor.Name = "labelDownscaleFactor";
            this.labelDownscaleFactor.Size = new System.Drawing.Size(239, 18);
            this.labelDownscaleFactor.TabIndex = 0;
            this.labelDownscaleFactor.Text = "Select Downscale Procentage:";
            // 
            // numericDowncsalingFactor
            // 
            this.numericDowncsalingFactor.BackColor = System.Drawing.Color.AliceBlue;
            this.numericDowncsalingFactor.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.numericDowncsalingFactor.Location = new System.Drawing.Point(389, 92);
            this.numericDowncsalingFactor.Name = "numericDowncsalingFactor";
            this.numericDowncsalingFactor.Size = new System.Drawing.Size(120, 22);
            this.numericDowncsalingFactor.TabIndex = 1;
            // 
            // pictureBoxOriginal
            // 
            this.pictureBoxOriginal.Location = new System.Drawing.Point(26, 184);
            this.pictureBoxOriginal.Name = "pictureBoxOriginal";
            this.pictureBoxOriginal.Size = new System.Drawing.Size(397, 281);
            this.pictureBoxOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxOriginal.TabIndex = 2;
            this.pictureBoxOriginal.TabStop = false;
            // 
            // pictureBoxDownscaled
            // 
            this.pictureBoxDownscaled.Location = new System.Drawing.Point(453, 184);
            this.pictureBoxDownscaled.Name = "pictureBoxDownscaled";
            this.pictureBoxDownscaled.Size = new System.Drawing.Size(400, 281);
            this.pictureBoxDownscaled.TabIndex = 3;
            this.pictureBoxDownscaled.TabStop = false;
            // 
            // buttonSelectImage
            // 
            this.buttonSelectImage.BackColor = System.Drawing.Color.AliceBlue;
            this.buttonSelectImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSelectImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelectImage.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonSelectImage.Location = new System.Drawing.Point(90, 500);
            this.buttonSelectImage.Name = "buttonSelectImage";
            this.buttonSelectImage.Size = new System.Drawing.Size(153, 48);
            this.buttonSelectImage.TabIndex = 4;
            this.buttonSelectImage.Text = "Select Image";
            this.buttonSelectImage.UseVisualStyleBackColor = false;
            this.buttonSelectImage.Click += new System.EventHandler(this.buttonSelectImage_Click);
            // 
            // buttonStartDownscalingConsequential
            // 
            this.buttonStartDownscalingConsequential.BackColor = System.Drawing.Color.AliceBlue;
            this.buttonStartDownscalingConsequential.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonStartDownscalingConsequential.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartDownscalingConsequential.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonStartDownscalingConsequential.Location = new System.Drawing.Point(320, 500);
            this.buttonStartDownscalingConsequential.Name = "buttonStartDownscalingConsequential";
            this.buttonStartDownscalingConsequential.Size = new System.Drawing.Size(189, 48);
            this.buttonStartDownscalingConsequential.TabIndex = 5;
            this.buttonStartDownscalingConsequential.Text = "Start Downscaling Consequential";
            this.buttonStartDownscalingConsequential.UseVisualStyleBackColor = false;
            this.buttonStartDownscalingConsequential.Click += new System.EventHandler(this.buttonStartDownscalingConsequential_Click);
            // 
            // buttonStartDownscalingParallel
            // 
            this.buttonStartDownscalingParallel.BackColor = System.Drawing.Color.AliceBlue;
            this.buttonStartDownscalingParallel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonStartDownscalingParallel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartDownscalingParallel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonStartDownscalingParallel.Location = new System.Drawing.Point(600, 500);
            this.buttonStartDownscalingParallel.Name = "buttonStartDownscalingParallel";
            this.buttonStartDownscalingParallel.Size = new System.Drawing.Size(189, 48);
            this.buttonStartDownscalingParallel.TabIndex = 6;
            this.buttonStartDownscalingParallel.Text = "Start Downscaling Parallel";
            this.buttonStartDownscalingParallel.UseVisualStyleBackColor = false;
            this.buttonStartDownscalingParallel.Click += new System.EventHandler(this.buttonStartDownscalingParallel_Click);
            // 
            // buttonSaveDownscaledImage
            // 
            this.buttonSaveDownscaledImage.BackColor = System.Drawing.Color.AliceBlue;
            this.buttonSaveDownscaledImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSaveDownscaledImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveDownscaledImage.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonSaveDownscaledImage.Location = new System.Drawing.Point(667, 112);
            this.buttonSaveDownscaledImage.Name = "buttonSaveDownscaledImage";
            this.buttonSaveDownscaledImage.Size = new System.Drawing.Size(183, 48);
            this.buttonSaveDownscaledImage.TabIndex = 7;
            this.buttonSaveDownscaledImage.Text = "Save Downscaled Image";
            this.buttonSaveDownscaledImage.UseVisualStyleBackColor = false;
            this.buttonSaveDownscaledImage.Click += new System.EventHandler(this.buttonSaveDownscaledImage_Click);
            // 
            // openFileDialogImage
            // 
            this.openFileDialogImage.FileName = "openFileDialogImage";
            // 
            // DownscaleImageApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(915, 615);
            this.Controls.Add(this.buttonSaveDownscaledImage);
            this.Controls.Add(this.buttonStartDownscalingParallel);
            this.Controls.Add(this.buttonStartDownscalingConsequential);
            this.Controls.Add(this.buttonSelectImage);
            this.Controls.Add(this.pictureBoxDownscaled);
            this.Controls.Add(this.pictureBoxOriginal);
            this.Controls.Add(this.numericDowncsalingFactor);
            this.Controls.Add(this.labelDownscaleFactor);
            this.Name = "DownscaleImageApp";
            this.Text = "Downscale Image App";
            ((System.ComponentModel.ISupportInitialize)(this.numericDowncsalingFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDownscaled)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDownscaleFactor;
        private System.Windows.Forms.NumericUpDown numericDowncsalingFactor;
        private System.Windows.Forms.PictureBox pictureBoxOriginal;
        private System.Windows.Forms.PictureBox pictureBoxDownscaled;
        private System.Windows.Forms.Button buttonSelectImage;
        private System.Windows.Forms.Button buttonStartDownscalingConsequential;
        private System.Windows.Forms.Button buttonStartDownscalingParallel;
        private System.Windows.Forms.Button buttonSaveDownscaledImage;
        private System.Windows.Forms.OpenFileDialog openFileDialogImage;
    }
}

