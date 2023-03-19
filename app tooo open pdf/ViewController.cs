using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Imaging;
using System.IO;
using ImageMagick;
using System.Diagnostics;
using Path = System.IO.Path;
using System.Security.RightsManagement;

namespace app_tooo_open_pdf
{
    public class ViewController
    {
      
        public Image imageInBox;
        private FormController1 formController;
        public ViewController(FormController1 formController)
        {
            this.formController = formController;
        }


        public static void OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF Files|*.pdf";
            openFileDialog.Title = "Select a PDF File";

            // Show the Open File dialog and check if a file was selected
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the path of the selected file
               string filePath = openFileDialog.FileName;

                // aktualizacja wartości pola FilePath w klasie Singleton
                Singleton.Instance.FilePath = filePath;

                // zapisanie wartości pola FilePath do pliku w klasie Singleton
                Singleton.Instance.SaveToFile();
            }
          
        }

        public void UpdatePicturebox()
        {
            string filePath = Singleton.Instance.FilePath;
            string saveWhere = Singleton.Instance.OutPutDirectory;
            imageInBox = System.Drawing.Image.FromFile($"{saveWhere}" + "/" + $"{System.IO.Path.GetFileNameWithoutExtension(filePath)}_page1.png");
            //// przypisz obraz do kontrolki PictureBox
           Update(imageInBox);
        }

       public void Update(Image imageInBox)
       {
                formController.pictureBox1.Image = imageInBox;
                formController.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
       }
    }
}
