using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace app_tooo_open_pdf
{
    internal class ModelSize
    {
        public ModelSize()
        {

        }
        public void Pagewhere()
        {
            //string filenameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(filePath);

            //string where = System.IO.Path.Combine( która stronna, $"{filenameWithoutExtension}_page{textBox1.Text}.png");
            //ModelCusttomMesage modelCusttomMesage = new ModelCusttomMesage(where);
            //modelCusttomMesage.ShowCustomMessageBox();
            //ModelSize model = new ModelSize();

            ////  w zależność od wyboru w menu
            //model.Sizefor4(where);
           
        }

        public void Sizefor4(string where)
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

        public void SizeforA3(string where)
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
