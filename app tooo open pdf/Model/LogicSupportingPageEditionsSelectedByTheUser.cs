using ImageMagick;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSchematicEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PdfSchematicEditor
{
    internal class LogicSupportingPageEditionsSelectedByTheUser
    {
        private string outputDirectory = SingletonInformationStorage.Instance.OutPutDirectory;
       private string where;
      
        public LogicSupportingPageEditionsSelectedByTheUser()
        {
        }

        public void IsPageInNumbers(PageSelectionAndEditingWindowController formController, int pageInTextBox)
        {

            string textBoxValue = formController.TexboxToolStripMenuItem.Text; 
            string[] numbersAsString = textBoxValue.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = Array.ConvertAll(numbersAsString, int.Parse);
            
            bool isPageInNumbers = Array.Exists(numbers, element => element == pageInTextBox);
            SingletonInformationStorage.Instance.IsPageInNumbers = isPageInNumbers;
        }

        public void HowTOConvetPdf(FileSelectionWindowController formController)
        {
          
            if (formController.ConvertFastToolStripMenuItem1.Checked == true)
            { 
               FastConvertPDFtoPNG();
            }

            if (formController.ConvertSlowToolStripMenuItem1.Checked == true)
            {
                SlowConvertPDFtoPNG();
            }
           
        }

        private void SlowConvertPDFtoPNG()
        {
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }
            string filePath = SingletonInformationStorage.Instance.FilePath;
          

            var settings = new MagickReadSettings
            {
                Density = new Density(600, 600),
                ColorSpace = ColorSpace.RGB,
                TextAntiAlias = true,
                Format = MagickFormat.Pdf
            };
            using (var images = new MagickImageCollection())
            {


                Stopwatch stop = new Stopwatch();
                stop.Start();

                images.Read(filePath, settings);
                int maxPage = images.Count;
                SingletonInformationStorage.Instance.MaxPage = maxPage;
                stop.Stop();
                TimeSpan time = stop.Elapsed;

                Stopwatch stopwatchForEach = new Stopwatch();
                stopwatchForEach.Start();

                Parallel.ForEach(images, (image, state, i) =>
                {
                    image.BackgroundColor = MagickColors.White;
                    image.Alpha(AlphaOption.Remove);
                    image.Write(outputDirectory + "/" + System.IO.Path.GetFileNameWithoutExtension(filePath) + "_page" + (i + 1) + ".png");
                });

                stopwatchForEach.Stop();
                TimeSpan timeForEach = stopwatchForEach.Elapsed;           
            }
        }

       
        private void FastConvertPDFtoPNG()
        {
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }
            string filePath = SingletonInformationStorage.Instance.FilePath;
            var settings = new MagickReadSettings
            {
          
                Density = new Density(150, 150),
                ColorSpace = ColorSpace.sRGB,
                TextAntiAlias = false,
                Format = MagickFormat.Pdf
            };

            int maxThreads = Environment.ProcessorCount;
            int numThreads = Math.Min(maxThreads, 4);
            ParallelOptions options = new ParallelOptions { MaxDegreeOfParallelism = numThreads };

            using (var images = new MagickImageCollection())
            {
                Stopwatch stop = new Stopwatch();
                stop.Start();

                images.Read(filePath, settings);
                int maxPage = images.Count;
                SingletonInformationStorage.Instance.MaxPage = maxPage;
                stop.Stop();
                TimeSpan time = stop.Elapsed;

                Stopwatch stopwatchForEach = new Stopwatch();
                stopwatchForEach.Start();

                Parallel.ForEach(images, options, (image, state, i) =>
                {
                    image.BackgroundColor = MagickColors.White;
                    image.Alpha(AlphaOption.Remove);
                    image.Write(outputDirectory + "/" + System.IO.Path.GetFileNameWithoutExtension(filePath) + "_page" + (i + 1) + ".png");
                });

                stopwatchForEach.Stop();
                TimeSpan timeForEach = stopwatchForEach.Elapsed;
            }
        }

        public void SloswConvertPDFtoPNG()// problemy z pamięcią ale krótsze ładownie 
        {
            // odczytanie wartości pola FilePath z klasy SingletonInformationStorage
            string filePath = SingletonInformationStorage.Instance.FilePath;
          
            // Sprawdzam, czy istnieje katalog wyjściowy o podanej nazwie (outputDirectory),
            // a jeśli nie, tworze go
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }
            Stopwatch stop = new Stopwatch();
            stop.Start();
            using (var input = System.IO.File.OpenRead(filePath))
            {
                var buffer = new byte[1048576]; // Rozmiar bufora ustawiony na 4KB za mało 1MB

                using (var pdfStream = new MemoryStream())
                {
                    input.CopyTo(pdfStream);
                    pdfStream.Position = 0;

                    var pdfImages = new MagickImageCollection();
                    pdfImages.Read(pdfStream);
                    int maxPage = pdfImages.Count;
                    // aktualizacja wartości pola FilePath w klasie SingletonInformationStorage
                    SingletonInformationStorage.Instance.MaxPage = maxPage;

                    // zapisanie wartości pola FilePath do pliku w klasie SingletonInformationStorage
                    SingletonInformationStorage.Instance.SaveToFile();

                    Parallel.ForEach(pdfImages, (pdfImage, state, i) =>
                    {
                        var currentPage = i + 1;
                        var pngImage = pdfImage.Clone();

                        
                        pngImage.BackgroundColor = MagickColors.White;
                        pngImage.Alpha(AlphaOption.Remove);

                      
                        using (var outputStream = System.IO.File.Create(outputDirectory + "/" + System.IO.Path.GetFileNameWithoutExtension(filePath) + "_page" + currentPage + ".png"))
                        {
                            using (var pngStream = new MemoryStream())
                            {
                                pngImage.Format = MagickFormat.Png;
                                pngImage.Write(pngStream);
                                pngStream.Position = 0;

                                while (true)
                                {
                                    var bytesRead = pngStream.Read(buffer, 0, buffer.Length);

                                    if (bytesRead <= 0)
                                    {
                                        break;
                                    }
                                    outputStream.Write(buffer, 0, bytesRead);
                                }
                            }
                        }
                    });

                }
            }
            stop.Stop();
            TimeSpan time = stop.Elapsed;
        }


        public void Skirts(PageSelectionAndEditingWindowController formController)
        {
            if (formController.TexboxToolStripMenuItem.Text != "")
            {
                
                for (int i = 0; i <= SingletonInformationStorage.Instance.MaxPage; i++)
                { 
                    IsPageInNumbers(formController, i);
                    if (SingletonInformationStorage.Instance.IsPageInNumbers)
                    {
                        Where(i);
                        WhatSizeIsChecked(formController);
                    }
                }
            }
            else
            {
                Where(SingletonInformationStorage.Instance.Page);
                WhatSizeIsChecked(formController);
            }
        }

        public void Where(int i)
        {
            string filenameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(SingletonInformationStorage.Instance.FilePath);

            where = System.IO.Path.Combine(SingletonInformationStorage.Instance.outPutDirectory, $"{filenameWithoutExtension}_page{i}.png");

        }

        public void WhatSizeIsChecked(PageSelectionAndEditingWindowController formController)
        {

            if (formController.EnlargeMakeA2AndDivideIntoA4ToolStripMenuItem.Checked == true&& where!=null)
            {
                MessageBox.Show("a2");
                SizeforA2();

            }

            if (formController.EnlargeMakeA3AndDivideIntoA4ToolStripMenuItem.Checked == true&& where!=null)
            {
                MessageBox.Show("a3");
                SizeforA3();
            }

        }
     
        public void SizeforA2()
        {
            Image img = Image.FromFile(where);
            int width = img.Width;
            int height = img.Height;

            int newWidth = 4960;
            int newHeight = 7016;
            Bitmap newImg = new Bitmap(newWidth, newHeight);

            using (Graphics gfx = Graphics.FromImage(newImg))
            {
                gfx.FillRectangle(Brushes.White, 0, 0, newWidth, newHeight);
            }

            float ratio = (float)width / (float)height;
            float a2Ratio = 1.414f;
            if (ratio > a2Ratio)
            {

                width = (int)(newWidth * 1.0f);
                height = (int)(width / ratio);
            }
            else
            {

                height = (int)(newHeight * 1.0f);
                width = (int)(height * ratio);
            }

            int offsetX = (newWidth - width) / 2;
            int offsetY = (newHeight - height) / 2;
            using (Graphics gfx = Graphics.FromImage(newImg))
            {
                gfx.DrawImage(img, offsetX, offsetY, width, height);
            }

            int a4Width = newWidth / 2;
            int a4Height = newHeight / 2;
            int x1 = 0, y1 = 0, x2 = a4Width, y2 = a4Height;

            string baseFileName = System.IO.Path.GetFileNameWithoutExtension(where);
            string folderName = System.IO.Path.GetDirectoryName(where) + "\\" + baseFileName;

            Directory.CreateDirectory(folderName);

            for (int i = 1; i <= 4; i++)
            {
                string filename = baseFileName + "_page" + i + ".png";
                using (Bitmap part = new Bitmap(a4Width, a4Height))
                {
                    using (Graphics gfx = Graphics.FromImage(part))
                    {
                        gfx.DrawImage(newImg, new Rectangle(0, 0, a4Width, a4Height), new Rectangle(x1, y1, a4Width, a4Height), GraphicsUnit.Pixel);
                    }
                    part.Save(folderName + "\\" + filename, ImageFormat.Png);
                }
 
                x1 = x2;
                x2 += a4Width;
                if (x2 > newWidth)
                {
                    x1 = 0;
                    x2 = a4Width;
                    y1 = y2;
                    y2 += a4Height;
                }
            }

          
            img.Dispose();
            newImg.Dispose();
        }


        public void SizeforA3()
        {
            Image img = Image.FromFile(where);
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            int width = img.Width;
            int height = img.Height;

            int newWidth = 4961;
            int newHeight = 3508;
            Bitmap newImg = new Bitmap(newWidth, newHeight);

          
            using (Graphics gfx = Graphics.FromImage(newImg))
            {
                gfx.FillRectangle(Brushes.White, 0, 0, newWidth, newHeight);
            }

            float ratio = (float)width / (float)height;
            float a3Ratio = 0.707f;
            if (ratio > a3Ratio)
            {
                width = (int)(newWidth * 1.0f);
                height = (int)(width / ratio);
            }
            else
            {
               
                height = (int)(newHeight * 1.0f);
                width = (int)(height * ratio);
            }


            int offsetX = (newWidth - width) / 2;
            int offsetY = (newHeight - height) / 2;
            using (Graphics gfx = Graphics.FromImage(newImg))
            {
                gfx.DrawImage(img, offsetX, offsetY, width, height);
            }

            
            int a4Width = newWidth / 2;
            int a4Height = newHeight;
            int x1 = 0, y1 = 0, x2 = a4Width, y2 = a4Height;

            string baseFileName = System.IO.Path.GetFileNameWithoutExtension(where);
            string folderName = System.IO.Path.GetDirectoryName(where) + "\\" + baseFileName;

            Directory.CreateDirectory(folderName);

            for (int i = 1; i <= 2; i++)
            {
                string filename = baseFileName + "_page" + i + ".png";
                using (Bitmap part = new Bitmap(a4Width, a4Height))
                {
                    using (Graphics gfx = Graphics.FromImage(part))
                    {
                        gfx.DrawImage(newImg, new Rectangle(0, 0, a4Width, a4Height), new Rectangle(x1, y1, a4Width, a4Height), GraphicsUnit.Pixel);
                    }
                    part.Save(folderName + "\\" + filename, ImageFormat.Png);
                }
                x1 = x2;
                x2 += a4Width;
            }

            img.Dispose();
            newImg.Dispose();
        }
    }
}