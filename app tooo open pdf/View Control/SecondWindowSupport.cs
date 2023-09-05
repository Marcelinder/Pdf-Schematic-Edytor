using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Converters;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PdfSchematicEditor
{
    public class SecondWindowSupport
    {

        private PageSelectionAndEditingWindowController formController;
        private int maxPage = SingletonInformationStorage.Instance.MaxPage;
        int page = SingletonInformationStorage.Instance.Page;
        string outFilleName = SingletonInformationStorage.Instance.OutFilleName;
        string newFilleName = SingletonInformationStorage.Instance.NewFilleName;
        
        public SecondWindowSupport(PageSelectionAndEditingWindowController formController)
        {
            this.formController = formController;
        }

        private readonly object _lock = new object();// zabezpieczenie przed wykonaniem sie 2 razy tym samym czasie 

        public void SetImage()
        {
            lock (_lock)
            {
                
                if (outFilleName != newFilleName )
                {
                    SingletonInformationStorage.Instance.OutFilleName = newFilleName;
                    formController.PictureOpen.Image.Dispose();
                    formController.PictureOpen.Image = null;
                }

                System.Drawing.Image image = System.Drawing.Image.FromFile(newFilleName);
                formController.PictureOpen.Image = image;
                formController.PictureOpen.SizeMode = PictureBoxSizeMode.Zoom;
                formController.LabelPageAndMaxPage.Text = $"Strona {page} z {maxPage}";
                SingletonInformationStorage.Instance.Page = page;
                IsGreen();
            }
        }
        public void TollStriptTextADD()
        {
            formController.TexboxToolStripMenuItem.Text += $"{page}"+", ";
        }

        public void IsGreen()
        {
            if (SingletonInformationStorage.Instance.IsPageInNumbers) 
            {
                formController.ColorDot.ForeColor = Color.FromArgb(128, 0, 255, 0);
            }
            else
            {
                formController.ColorDot.ForeColor = Color.FromArgb(128, 255, 0, 0);
            }

        }
  
        public void CheckedMenuOption(object sender)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            

               //optiom too 
            if (menuItem == formController.EnlargeMakeA2AndDivideIntoA4ToolStripMenuItem)
            {
                menuItem.Checked = !menuItem.Checked;
                formController.EnlargeMakeA3AndDivideIntoA4ToolStripMenuItem.Checked = false;
            
            }
            else
            if (menuItem == formController.EnlargeMakeA3AndDivideIntoA4ToolStripMenuItem)
            {
                menuItem.Checked = !menuItem.Checked;
                formController.EnlargeMakeA2AndDivideIntoA4ToolStripMenuItem.Checked = false;
                
            };

        }
    }
  
}
