namespace MatrixProgrammer
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.uploadButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.serialPortDropdown = new System.Windows.Forms.ComboBox();
            this.pathLabel = new System.Windows.Forms.Label();
            this.pickFileButton = new System.Windows.Forms.Button();
            this.whiteTransparentCheckbox = new System.Windows.Forms.CheckBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.brightnessSlider = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // uploadButton
            // 
            this.uploadButton.Location = new System.Drawing.Point(241, 6);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(75, 23);
            this.uploadButton.TabIndex = 2;
            this.uploadButton.Text = "Upload";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(13, 396);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(304, 23);
            this.progressBar.Step = 20;
            this.progressBar.TabIndex = 5;
            // 
            // serialPortDropdown
            // 
            this.serialPortDropdown.FormattingEnabled = true;
            this.serialPortDropdown.Location = new System.Drawing.Point(114, 8);
            this.serialPortDropdown.Name = "serialPortDropdown";
            this.serialPortDropdown.Size = new System.Drawing.Size(121, 21);
            this.serialPortDropdown.TabIndex = 1;
            // 
            // pathLabel
            // 
            this.pathLabel.Location = new System.Drawing.Point(13, 422);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(304, 15);
            this.pathLabel.TabIndex = 6;
            // 
            // pickFileButton
            // 
            this.pickFileButton.Location = new System.Drawing.Point(12, 8);
            this.pickFileButton.Name = "pickFileButton";
            this.pickFileButton.Size = new System.Drawing.Size(96, 23);
            this.pickFileButton.TabIndex = 0;
            this.pickFileButton.Text = "Pick Image File";
            this.pickFileButton.UseVisualStyleBackColor = true;
            this.pickFileButton.Click += new System.EventHandler(this.pickFileButton_Click);
            // 
            // whiteTransparentCheckbox
            // 
            this.whiteTransparentCheckbox.Checked = true;
            this.whiteTransparentCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.whiteTransparentCheckbox.Location = new System.Drawing.Point(12, 37);
            this.whiteTransparentCheckbox.Name = "whiteTransparentCheckbox";
            this.whiteTransparentCheckbox.Size = new System.Drawing.Size(149, 24);
            this.whiteTransparentCheckbox.TabIndex = 3;
            this.whiteTransparentCheckbox.Text = "Treat white as transparent";
            this.whiteTransparentCheckbox.UseVisualStyleBackColor = true;
            this.whiteTransparentCheckbox.CheckedChanged += new System.EventHandler(this.whiteTransparentCheckbox_CheckedChanged);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(12, 86);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(304, 304);
            this.pictureBox.TabIndex = 6;
            this.pictureBox.TabStop = false;
            // 
            // brightnessSlider
            // 
            this.brightnessSlider.LargeChange = 10;
            this.brightnessSlider.Location = new System.Drawing.Point(167, 37);
            this.brightnessSlider.Maximum = 100;
            this.brightnessSlider.Name = "brightnessSlider";
            this.brightnessSlider.Size = new System.Drawing.Size(149, 45);
            this.brightnessSlider.SmallChange = 5;
            this.brightnessSlider.TabIndex = 7;
            this.brightnessSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.brightnessSlider.Value = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 446);
            this.Controls.Add(this.brightnessSlider);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.whiteTransparentCheckbox);
            this.Controls.Add(this.pickFileButton);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.serialPortDropdown);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.uploadButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "LED Matrix Flasher";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TrackBar brightnessSlider;

        private System.Windows.Forms.PictureBox pictureBox;

        private System.Windows.Forms.CheckBox whiteTransparentCheckbox;

        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.Button pickFileButton;

        private System.Windows.Forms.ComboBox serialPortDropdown;

        private System.Windows.Forms.ProgressBar progressBar;

        private System.Windows.Forms.Button uploadButton;

        #endregion
    }
}