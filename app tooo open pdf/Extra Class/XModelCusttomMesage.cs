using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PdfSchematicEditor
{
    internal class XModelCusttomMesage
    {
        //private Form form;
        string _where;

        public XModelCusttomMesage(string where) 
        {
            _where = where;  
        }
        /// <summary>
        /// //////////////////////// Masage boz dający mozliwość kopiowanie tekstu 
        /// start with debuging to samo przy błędach ?
        /// </summary>

        public void ShowCustomMessageBox()
        {
            Form form = new Form();
            Label label = new Label();
            Button button = new Button();

            form.Text = "Error";
            label.Text = _where;
            button.Text = "Copy";

            label.SetBounds(9, 20, 372, 13);
            button.SetBounds(197, 72, 75, 23);
            form.ClientSize = new System.Drawing.Size(396, 107);
            form.Controls.AddRange(new Control[] { label, button });
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = button;

            button.Click += (sender, e) =>
            {
                Clipboard.SetText(_where);
                form.Close();
            };

            form.ShowDialog();
        }
    }
}
