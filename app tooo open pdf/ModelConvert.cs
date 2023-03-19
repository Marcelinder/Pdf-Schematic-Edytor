using ImageMagick;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_tooo_open_pdf
{
    internal class ModelConvert
    {
        private string outputDirectory = Singleton.Instance.OutPutDirectory;
        private FormController1 formController;
        private ViewController viewController;
        public ModelConvert(FormController1 formController, ViewController viewController)
        {
            this.formController = formController;
            this.viewController = viewController;
        }


        public void ConvertPDFtpPNG()
        {

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }
            string filePath = Singleton.Instance.FilePath; 
            ////Tworze nowy obiekt settings klasy MagickReadSettings,
            ////który pozwala na ustawienie różnych opcji odczytu plików graficznych.
            var settings = new MagickReadSettings();

            //Ustawiam gęstość obrazu na 300 dpi,
            //co pozwala na uzyskanie lepszej jakości obrazu
            settings.Density = new Density(600, 600);

            //Ustawiam tryb koloru na RGB zamiast domyślnego sRGB
            settings.ColorSpace = ColorSpace.RGB;
            //wygładazanie tekstu 
            settings.TextAntiAlias = true;
            // ustawienie formatu 
            settings.Format = MagickFormat.Pdf;


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
            //////////działenie do form 1 
            // wczytaj obraz z pliku

            viewController.UpdatePicturebox();
          
        }

        public async Task ConvertPDFtpPNGAsync()
        {
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }
            string filePath = Singleton.Instance.FilePath;
            var settings = new MagickReadSettings();
            settings.Density = new Density(600, 600);
            settings.ColorSpace = ColorSpace.RGB;
            settings.TextAntiAlias = true;
            settings.Format = MagickFormat.Pdf;

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

                await Task.Run(() => Parallel.ForEach(images, (image, state, i) =>
                {
                    image.BackgroundColor = MagickColors.White;
                    image.Alpha(AlphaOption.Remove);
                    image.Write(outputDirectory + "/" + System.IO.Path.GetFileNameWithoutExtension(filePath) + "_page" + (i + 1) + ".png");
                }));

                stopwatchForEach.Stop();
                TimeSpan timeForEach = stopwatchForEach.Elapsed;
            }
            viewController.UpdatePicturebox();
        }

        /// <summary>
        /// ///////////////////////////////////////// problemy z pamięcią ale krótsze ładownie oraz strata na jakości 
        /// </summary>

        public void ConvertPDFtoPNG()// problemy z pamięcią ale krótsze ładownie 
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
            viewController.UpdatePicturebox();
        }
    }
}
