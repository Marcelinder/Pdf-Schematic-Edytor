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
using app_tooo_open_pdf;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace app_tooo_open_pdf
{
    internal class ModelConvertAndSize
    {
        private string outputDirectory = Singleton.Instance.OutPutDirectory;
       private string where;
      
        public ModelConvertAndSize()
        {
        }

        public void IsPageInNumbers(FormController2 formController, int pageInTextBox)
        {

            string textBoxValue = formController.TexboxToolStripMenuItem.Text; // pobranie wartości z texboxa
                                                                               // rozdzielenie wartości z textboxa na poszczególne liczby 
            string[] numbersAsString = textBoxValue.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = Array.ConvertAll(numbersAsString, int.Parse);
            // wyszukiwanie liczby równiej page w tablicy liczb
            bool isPageInNumbers = Array.Exists(numbers, element => element == pageInTextBox);
            Singleton.Instance.IsPageInNumbers = isPageInNumbers;
        }

        public void HowTOConvetPdf(FormController1 formController)
        {
          
            if (formController.ConvertFastToolStripMenuItem1.Checked == true)
            { 
               // MessageBox.Show("fast");
               FastConvertPDFtoPNG();
                
            }

            if (formController.ConvertSlowToolStripMenuItem1.Checked == true)
            {
              //  MessageBox.Show("slow");
                SlowConvertPDFtoPNG();
            }
           
        }

        private void SlowConvertPDFtoPNG()
        {
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }
            string filePath = Singleton.Instance.FilePath;
            ////Tworze nowy obiekt settings klasy MagickReadSettings,
            ////który pozwala na ustawienie różnych opcji odczytu plików graficznych.
            var settings = new MagickReadSettings
            {
                //Ustawiam gęstość obrazu na 300 dpi,
                //co pozwala na uzyskanie lepszej jakości obrazu
                Density = new Density(600, 600),

                //Ustawiam tryb koloru na RGB zamiast domyślnego sRGB
                ColorSpace = ColorSpace.RGB,
                //wygładazanie tekstu 
                TextAntiAlias = true,
                // ustawienie formatu 
                Format = MagickFormat.Pdf
            };


            ///////////wielowątkowość 30 stron tego samego pliku pdf czas około 32 sekundy o 20 sekund szybciej niż 
            // w przypadku renderowania na bierząco domyślny czas załadowania tego pliku to około 20 sekund

            // Tworze kolekcję obrazów za pomocą klasy MagickImageCollection
            using (var images = new MagickImageCollection())
            {


                Stopwatch stop = new Stopwatch();
                stop.Start();


                //// Wczytuje wszystkie strony pliku PDF i dodaje je do kolekcji images
                images.Read(filePath, settings);
                int maxPage = images.Count;
                Singleton.Instance.MaxPage = maxPage;
                stop.Stop();
                TimeSpan time = stop.Elapsed;
                //////////////////////////// add the line adding and no stop the whole aplikation 
                // MessageBox.Show($"Czas przetwarzania dla 'read': {time.TotalSeconds} s");

                Stopwatch stopwatchForEach = new Stopwatch();
                stopwatchForEach.Start();

                // Przetwarza każdą stronę PDF osobno równolegle
                Parallel.ForEach(images, (image, state, i) =>
                {
                    // Ustawia tło na białe zamiast przezroczystego
                    image.BackgroundColor = MagickColors.White;

                    // Usuwa alfa-kanał, który powoduje problemy z siatką w tle
                    image.Alpha(AlphaOption.Remove);

                    // Zapisuje obraz w formacie PNG
                    image.Write(outputDirectory + "/" + System.IO.Path.GetFileNameWithoutExtension(filePath) + "_page" + (i + 1) + ".png");
                });

                stopwatchForEach.Stop();
                TimeSpan timeForEach = stopwatchForEach.Elapsed;

                //MessageBox.Show($"Czas przetwarzania dla 'foreach': {timeForEach.TotalSeconds} s");
            }
        }

       
        private void FastConvertPDFtoPNG()
        {
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }
            string filePath = Singleton.Instance.FilePath;
            var settings = new MagickReadSettings
            {
                // Decrease density to 150 dpi for faster processing
                Density = new Density(150, 150),

                // Use sRGB color space instead of RGB for faster processing
                ColorSpace = ColorSpace.sRGB,

                // Disable text anti-aliasing for faster processing
                TextAntiAlias = false,

                // Set format to PDF
                Format = MagickFormat.Pdf
            };

            // Use a smaller number of threads for parallel processing
            int maxThreads = Environment.ProcessorCount;
            int numThreads = Math.Min(maxThreads, 4);
            ParallelOptions options = new ParallelOptions { MaxDegreeOfParallelism = numThreads };

            using (var images = new MagickImageCollection())
            {
                Stopwatch stop = new Stopwatch();
                stop.Start();

                images.Read(filePath, settings);
                int maxPage = images.Count;
                Singleton.Instance.MaxPage = maxPage;
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

        /// <summary>
        /// ///////////////////////////////////////// problemy z pamięcią ale krótsze ładownie oraz strata na jakości 
        /// </summary>

        public void SloswConvertPDFtoPNG()// problemy z pamięcią ale krótsze ładownie 
        {
            // odczytanie wartości pola FilePath z klasy Singleton
            string filePath = Singleton.Instance.FilePath;
          
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
                    // aktualizacja wartości pola FilePath w klasie Singleton
                    Singleton.Instance.MaxPage = maxPage;

                    // zapisanie wartości pola FilePath do pliku w klasie Singleton
                    Singleton.Instance.SaveToFile();

                    Parallel.ForEach(pdfImages, (pdfImage, state, i) =>
                    {
                        var currentPage = i + 1;
                        var pngImage = pdfImage.Clone();

                        // Ustawia tło na białe zamiast przezroczystego
                        pngImage.BackgroundColor = MagickColors.White;

                        // Usuwa alfa-kanał, który powoduje problemy z siatką w tle
                        pngImage.Alpha(AlphaOption.Remove);

                        // Zapisuje obraz w formacie PNG
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


        public void Skirts(FormController2 formController)
        {
            if (formController.TexboxToolStripMenuItem.Text != "")
            {
                
                for (int i = 0; i <= Singleton.Instance.MaxPage; i++)
                { 
                    IsPageInNumbers(formController, i);
                    if (Singleton.Instance.IsPageInNumbers)
                    {
                        Where(i);
                        WhatSizeIsChecked(formController);
                    }
                }
            }
            else
            {
                Where(Singleton.Instance.Page);
                WhatSizeIsChecked(formController);
            }
        }

        public void Where(int i)
        {/// która strona nazwa folderu do zapisu
            string filenameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(Singleton.Instance.FilePath);

            where = System.IO.Path.Combine(Singleton.Instance.outPutDirectory, $"{filenameWithoutExtension}_page{i}.png");
            //tylko druga strona parametr należało by podmieniać w zależności od textboxa 
        }

        public void WhatSizeIsChecked(FormController2 formController)//A2 cvzy A4
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

            // Przygotowanie płótna o rozmiarze A2
            int newWidth = 4960;
            int newHeight = 7016;
            Bitmap newImg = new Bitmap(newWidth, newHeight);

            // Wypełnienie płótna białym kolorem .// sprawezic czy użyteczne 
            using (Graphics gfx = Graphics.FromImage(newImg))
            {
                gfx.FillRectangle(Brushes.White, 0, 0, newWidth, newHeight);
            }
            // Dostosowanie proporcji obrazu do wymiarów A2
            float ratio = (float)width / (float)height;
            float a2Ratio = 1.414f;
            if (ratio > a2Ratio)
            {
                // Obraz jest szerszy niż A2, więc zmniejszamy szerokość i proporcjonalnie zmniejszamy wysokość
                width = (int)(newWidth * 1.0f);
                height = (int)(width / ratio);
            }
            else
            {
                // Obraz jest wyższy niż A2, więc zmniejszamy wysokość i proporcjonalnie zmniejszamy szerokość
                height = (int)(newHeight * 1.0f);
                width = (int)(height * ratio);
            }

            // Wklejenie obrazu na środek płótna A2
            int offsetX = (newWidth - width) / 2;
            int offsetY = (newHeight - height) / 2;
            using (Graphics gfx = Graphics.FromImage(newImg))
            {
                gfx.DrawImage(img, offsetX, offsetY, width, height);
            }

            // Podział płótna A2 na 4 części A4 i zapisanie każdej części jako oddzielny plik
            int a4Width = newWidth / 2;
            int a4Height = newHeight / 2;
            int x1 = 0, y1 = 0, x2 = a4Width, y2 = a4Height;

            string baseFileName = System.IO.Path.GetFileNameWithoutExtension(where);
            string folderName = System.IO.Path.GetDirectoryName(where) + "\\" + baseFileName;

            Directory.CreateDirectory(folderName); // Utworzenie folderu o nazwie oryginalnego pliku

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
                // Przesunięcie wierzchołków prostokąta opisującego część A4
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

            // Zwolnienie zasobów obrazu
            img.Dispose();
            newImg.Dispose();
        }


        public void SizeforA3()
        {
            Image img = Image.FromFile(where);
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            int width = img.Width;
            int height = img.Height;

            // Przygotowanie płótna o rozmiarze A3
            int newWidth = 4961;
            int newHeight = 3508;
            Bitmap newImg = new Bitmap(newWidth, newHeight);

            // Wypełnienie płótna białym kolorem
            using (Graphics gfx = Graphics.FromImage(newImg))
            {
                gfx.FillRectangle(Brushes.White, 0, 0, newWidth, newHeight);
            }

            // Dostosowanie proporcji obrazu do wymiarów A3
            float ratio = (float)width / (float)height;
            float a3Ratio = 0.707f;
            if (ratio > a3Ratio)
            {
                // Obraz jest szerszy niż A3, więc zmniejszamy szerokość i proporcjonalnie zmniejszamy wysokość
                width = (int)(newWidth * 1.0f);
                height = (int)(width / ratio);
            }
            else
            {
                // Obraz jest wyższy niż A3, więc zmniejszamy wysokość i proporcjonalnie zmniejszamy szerokość
                height = (int)(newHeight * 1.0f);
                width = (int)(height * ratio);
            }


            // Wklejenie obrazu na środek płótna A3
            int offsetX = (newWidth - width) / 2;
            int offsetY = (newHeight - height) / 2;
            using (Graphics gfx = Graphics.FromImage(newImg))
            {
                gfx.DrawImage(img, offsetX, offsetY, width, height);
            }

            // Podział płótna A3 na 2 części A4 i zapisanie każdej części jako oddzielny plik
            int a4Width = newWidth / 2;
            int a4Height = newHeight;
            int x1 = 0, y1 = 0, x2 = a4Width, y2 = a4Height;

            string baseFileName = System.IO.Path.GetFileNameWithoutExtension(where);
            string folderName = System.IO.Path.GetDirectoryName(where) + "\\" + baseFileName;

            Directory.CreateDirectory(folderName); // Utworzenie folderu o nazwie oryginalnego pliku

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
                // Przesunięcie wierzchołków prostokąta opisującego część A4
                x1 = x2;
                x2 += a4Width;//
            }

            // Zwolnienie zasobów obrazu
            img.Dispose();
            newImg.Dispose();
        }
    }
}
//public async Task ConvertPDFtpPNGAsync()
//{
//    if (!Directory.Exists(outputDirectory))
//    {
//        Directory.CreateDirectory(outputDirectory);
//    }
//    string filePath = Singleton.Instance.FilePath;

//    var settings = new MagickReadSettings
//    {
//        Density = new Density(600, 600),
//        ColorSpace = ColorSpace.RGB,
//        TextAntiAlias = true,
//        Format = MagickFormat.Pdf
//    };

//    using (var images = new MagickImageCollection())
//    {
//        Stopwatch stop = new Stopwatch();
//        stop.Start();
//        images.Read(filePath, settings);
//        int maxPage = images.Count;
//        Singleton.Instance.MaxPage = maxPage;
//        stop.Stop();
//        TimeSpan time = stop.Elapsed;

//        Stopwatch stopwatchForEach = new Stopwatch();
//        stopwatchForEach.Start();

//        await Task.Run(() => Parallel.ForEach(images, (image, state, i) =>
//        {
//            image.BackgroundColor = MagickColors.White;
//            image.Alpha(AlphaOption.Remove);
//            image.Write(outputDirectory + "/" + System.IO.Path.GetFileNameWithoutExtension(filePath) + "_page" + (i + 1) + ".png");
//        }));

//        stopwatchForEach.Stop();
//        TimeSpan timeForEach = stopwatchForEach.Elapsed;
//    }
//}