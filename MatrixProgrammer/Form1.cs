using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Management;

namespace MatrixProgrammer
{
    public partial class Form1 : Form
    {
        private string imageFilePath = "";
        
        public Form1()
        {
            InitializeComponent();

            foreach (string serialPort in SerialPort.GetPortNames())
            {
                serialPortDropdown.Items.Add(serialPort);
            }
            
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Caption LIKE '%CH340%'");
            List<ManagementBaseObject> serialPorts = managementObjectSearcher.Get().Cast<ManagementBaseObject>().ToList();
            if (serialPorts.Count == 0) return;
            string firstCH340Port = serialPorts[0]["Caption"].ToString().Replace("USB-SERIAL CH340 (", "").Replace(")", "");
            serialPortDropdown.SelectedItem = firstCH340Port;
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            if (imageFilePath == "")
            {
                MessageBox.Show("Please select an image file!");
                return;
            }
            
            if (serialPortDropdown.SelectedItem == null)
            {
                MessageBox.Show("Please select a serial port!");
                return;
            }
            
            progressBar.Value = 0;
            try
            {
                Directory.Delete("arduino\\output", true);
            }
            catch (DirectoryNotFoundException)
            {
            }

            Directory.CreateDirectory("arduino\\output");

            progressBar.PerformStep();

            Bitmap originalBitmap;
            
            try
            {
                originalBitmap = new Bitmap(imageFilePath);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Invalid image file selected");
                progressBar.Value = 0;
                return;
            }

            if (originalBitmap.Height != originalBitmap.Width)
            {
                MessageBox.Show("Image must be square!");
                progressBar.Value = 0;
                return;
            }

            Bitmap bitmap = new Bitmap(originalBitmap, new Size(16, 16));

            int line = 0;
            int column = 15;
            int led = 0;

            double multiplier = ((double) brightnessSlider.Value) / 100;

            string output = "";

            while (line < 16)
            {
                bool backwards = (column == 15);

                for (int i = 0; i < 16; i++)
                {
                    Color color = bitmap.GetPixel(column, line);
                    
                    if (color.Name != "ffffffff" || !whiteTransparentCheckbox.Checked)
                        output += "pixels.setPixelColor(" + led + ", pixels.Color(" + (color.R * multiplier).ToString(new CultureInfo("en-US")) + ", " + (color.G * multiplier).ToString(new CultureInfo("en-US")) + ", " + (color.B * multiplier).ToString(new CultureInfo("en-US")) + "));" + Environment.NewLine;
                    
                    led++;

                    if (i == 15) break;
                    if (backwards) column--;
                    else column++;
                }

                line++;
            }

            progressBar.PerformStep();
            
            string templateFile = File.ReadAllText("arduino\\template\\template.ino");
            templateFile = templateFile.Replace("##CODEPLACEHOLDER##", output);
            File.WriteAllText("arduino\\output\\output.ino", templateFile);
            
            progressBar.PerformStep();
            
            new Thread(CompileAndUpload).Start();
        }

        private void CompileAndUpload()
        {
            Process compileProcess = new Process();
            compileProcess.StartInfo.UseShellExecute = false;
            compileProcess.StartInfo.CreateNoWindow = true;
            compileProcess.StartInfo.RedirectStandardError = true;
            compileProcess.StartInfo.FileName = "arduino\\arduino-cli.exe";
            compileProcess.StartInfo.Arguments = "compile --config-file arduino.conf --fqbn arduino:avr:uno output";
            compileProcess.StartInfo.WorkingDirectory = "arduino";
            compileProcess.Start();

            if (compileProcess.StandardError.ReadToEnd() != "")
            {
                MessageBox.Show("Failed to compile firmware");
                progressBar.Value = 0;
                return;
            }
            
            progressBar.PerformStep();
            
            Process uploadProcess = new Process();
            uploadProcess.StartInfo.UseShellExecute = false;
            uploadProcess.StartInfo.CreateNoWindow = true;
            uploadProcess.StartInfo.RedirectStandardError = true;
            uploadProcess.StartInfo.FileName = "arduino\\arduino-cli.exe";
            uploadProcess.StartInfo.Arguments = "upload --config-file arduino.conf -p " + serialPortDropdown.SelectedItem + " --fqbn arduino:avr:uno output";
            uploadProcess.StartInfo.WorkingDirectory = "arduino";
            uploadProcess.Start();
            
            if (uploadProcess.StandardError.ReadToEnd() != "")
            {
                MessageBox.Show("Failed to flash firmware to device");
                progressBar.Value = 0;
                return;
            }
            
            progressBar.PerformStep();

            MessageBox.Show("Device flashed successfully!");
            progressBar.Value = 0;
        }

        private void pickFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.bmp; *.jpg; *.png)|*.bmp;*.jpg;*.png";
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            imageFilePath = openFileDialog.FileName;
            pathLabel.Text = imageFilePath;
            refreshPreview();
        }

        private void refreshPreview()
        {
            Bitmap resizedBitmap = new Bitmap(new Bitmap(imageFilePath), new Size(16, 16));

            if (whiteTransparentCheckbox.Checked)
            {
                for (int x = 0; x < 16; x++)
                {
                    for (int y = 0; y < 16; y++)
                    {
                        Color color = resizedBitmap.GetPixel(x, y);
                        if (color.Name == "ffffffff")
                            resizedBitmap.SetPixel(x, y, Color.Transparent);
                    }
                }
            }

            Rectangle previewRectangle = new Rectangle(0, 0, 304, 304);
            Bitmap previewBitmap = new Bitmap(304, 304);
            previewBitmap.SetResolution(resizedBitmap.HorizontalResolution, resizedBitmap.VerticalResolution);

            using (Graphics graphics = Graphics.FromImage(previewBitmap))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                graphics.SmoothingMode = SmoothingMode.None;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (ImageAttributes wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(resizedBitmap, previewRectangle, 0, 0, resizedBitmap.Width, resizedBitmap.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            pictureBox.Image = previewBitmap;
        }

        private void whiteTransparentCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            refreshPreview();
        }
    }
}