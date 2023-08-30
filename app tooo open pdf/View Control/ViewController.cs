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

namespace PdfSchematicEditor
{
    public class ViewController
    {
      
        
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

        public void UpdateWebBrowser()
        {
            formController.WebBrowser1.Navigate(Singleton.Instance.FilePath);
        }
        public void CheckedMenuOption(object sender) 
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;


            if (menuItem == formController.ConvertFastToolStripMenuItem1)
            {
                menuItem.Checked = !menuItem.Checked;
                formController.ConvertSlowToolStripMenuItem1.Checked = false;
            }
            else
            if (menuItem == formController.ConvertSlowToolStripMenuItem1)
            {
                menuItem.Checked = !menuItem.Checked;
                formController.ConvertFastToolStripMenuItem1.Checked = false;
            }
        }
    }
}
