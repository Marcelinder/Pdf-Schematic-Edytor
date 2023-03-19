using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_tooo_open_pdf
{
    public class ViewController2
    {

        private FormController2 formController;
        private int maxPage = Singleton.Instance.MaxPage;
        string outFilleName = Singleton.Instance.OutFilleName;


        public ViewController2(FormController2 formController)
        {
            this.formController = formController;
        }

        private readonly object _lock = new object();// zabezpieczenie przed wykonaniem sie 2 razy tym samym czasie 

        public void SetImage(string png, int Page)
        {
            lock (_lock)
            {
                if (outFilleName != png)
                {
                    Singleton.Instance.OutFilleName = png;
                    formController.PictureOpen.Image.Dispose();
                    formController.PictureOpen.Image = null;
                }

                System.Drawing.Image image = System.Drawing.Image.FromFile(png);
                formController.PictureOpen.Image = image;
                formController.PictureOpen.SizeMode = PictureBoxSizeMode.Zoom;
                formController.label1.Text = $"Strona {Page} z {maxPage}";
                Singleton.Instance.Page = Page;
            }
        }
        public void TollStriptTextADD()
        {
            formController.toolStripTextBox1.Text += $"{Singleton.Instance.Page}"+", ";
        }
    }
  
}
