using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace app_tooo_open_pdf
{
    public partial class FormController2 : Form
    {
        
       
        private int _scrollDelta = 0;
        private ViewFormController viewFormController;
        
        
        public FormController2()
        { 
            //this.Opacity = 0.5;
            InitializeComponent();
            PictureOpen.SizeMode = PictureBoxSizeMode.Zoom;
            Singleton.Instance.Page = 1;
            
            ViewController2 viewController2 = new ViewController2(this);
            viewController2.SetImage();
            viewFormController = new ViewFormController(this);
            this.MouseWheel += new MouseEventHandler(panel1_MouseWheel);//ew form2 load
            TexboxToolStripMenuItem.Text ="";
        }

        private void FormController2_Load(object sender, EventArgs e)
        {

        }
        private void Form2_SizeChanged(object sender, EventArgs e)
        {
           // label1.Parent = PictureOpen;
            //label1.BackColor = Color.Transparent;
        }
        private void Nextbt_Click(object sender, EventArgs e)
        {
            ModelControll2 modelContrroll2 = new ModelControll2();
            modelContrroll2.BTNext();
            ModelConvertAndSize modelConvertAndSize = new ModelConvertAndSize();
            modelConvertAndSize.IsPageInNumbers(this, Singleton.Instance.Page);
            ViewController2 viewController2 = new ViewController2(this);
            viewController2.SetImage();
        }

        public void Previousbt_Click(object sender, EventArgs e)
        {
            ModelControll2 modelContrroll2 = new ModelControll2();
            modelContrroll2.BtPrevious();
            ModelConvertAndSize modelConvertAndSize = new ModelConvertAndSize();
            modelConvertAndSize.IsPageInNumbers(this,Singleton.Instance.Page);
            ViewController2 viewController2 = new ViewController2(this);
            viewController2.SetImage();
        }
        
        private void panel1_MouseWheel(object sender, MouseEventArgs e)
        {
            // Obliczenie liczby linii do przesunięcia na podstawie wartości Delta myszy i ustawienia liczby linii przewijania kółka myszy w systemie.
            int numberOfTextLinesToMove = e.Delta * SystemInformation.MouseWheelScrollLines / 80;

            // Obliczenie nowej wartości delta przesunięcia.
            _scrollDelta += numberOfTextLinesToMove;

            // Jeśli wartość delta przesunięcia przekracza pewien próg (80), zmieniana jest wyświetlana w kontrolce Panel obrazu.
            if (_scrollDelta >= 80)
            {
                // Wywołanie metody Previousbt_Click, która zmienia wyświetlany obraz na poprzedni.
                Previousbt_Click(sender, e);
                // Wyzerowanie wartości delta przesunięcia.
                _scrollDelta = 0;
            }
            else if (_scrollDelta <= -80)
            {
                // Wywołanie metody Nextbt_Click, która zmienia wyświetlany obraz na następny.
                Nextbt_Click(sender, e);
                // Wyzerowanie wartości delta przesunięcia.
                _scrollDelta = 0;
            }
        }

        private void AddPageFromLabelAndConttexAddPage_Click(object sender, EventArgs e)
        {
            ViewController2 viewController2 = new ViewController2(this);
            viewController2.TollStriptTextADD();
        }
     

        private void PictureOpen_Click(object sender, EventArgs e)
        {
            
        }
        private void PictureOpen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Wyświetlenie menu kontekstowego w pozycji kursora myszy
                ContextMenuStrip.Show(Cursor.Position);
            }
        }
        private void PanelMouseSupport_MouseDown(object sender, MouseEventArgs e)
        {
       
        }
        private void TexboxToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            TexboxToolStripMenuItem.SelectionStart = TexboxToolStripMenuItem.Text.Length;
        }

        private void TexboxToolStripMenuItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                TexboxToolStripMenuItem.SelectionStart = TexboxToolStripMenuItem.Text.Length;
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Back)
            {
                int cursorPos = TexboxToolStripMenuItem.SelectionStart;
                int commaPos = TexboxToolStripMenuItem.Text.LastIndexOf(',', cursorPos - 1);
                if (commaPos == -1 || cursorPos - commaPos == 1)
                {
                    TexboxToolStripMenuItem.Text = "";
                }
                else
                {
                    int newCommaPos = TexboxToolStripMenuItem.Text.LastIndexOf(',', commaPos - 1);
                    if (newCommaPos == -1)
                    {
                        TexboxToolStripMenuItem.Text = TexboxToolStripMenuItem.Text.Substring(0, commaPos + 1);
                    }
                    else
                    {
                        TexboxToolStripMenuItem.Text = TexboxToolStripMenuItem.Text.Substring(0, newCommaPos + 1) + TexboxToolStripMenuItem.Text.Substring(commaPos + 1);
                    }
                }
                TexboxToolStripMenuItem.SelectionStart = TexboxToolStripMenuItem.Text.Length;
                e.Handled = true;
            }
        }

        private void TexboxToolStripMenuItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            int cursorPos = TexboxToolStripMenuItem.SelectionStart;

            // jeśli wpisano spację, to dodaj przecinek przed nią
            if (e.KeyChar == ' ' && cursorPos > 0 && char.IsDigit(TexboxToolStripMenuItem.Text[cursorPos - 1]))
            {   
                TexboxToolStripMenuItem.Text = TexboxToolStripMenuItem.Text.Insert(cursorPos, ", ");
                TexboxToolStripMenuItem.SelectionStart = cursorPos + 2;
                e.Handled = true;
            }
            // sprawdzenie czy wpisany znak to cyfra lub spacja
            else if (!char.IsDigit(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // zablokuj wpisanie innego znaku
                return;
            }
            // zablokuj dodawanie spacji jeśli nie ma cyfry przed nią
            else if (e.KeyChar == ' ' && (cursorPos == 0 || !char.IsDigit(TexboxToolStripMenuItem.Text[cursorPos - 1])))
            {
                e.Handled = true;
                return;
            }
        }
        private void TexboxToolStripMenuItem_TextChanged(object sender, EventArgs e)
        {
            ModelConvertAndSize modelConvertAndSize = new ModelConvertAndSize();
            modelConvertAndSize.IsPageInNumbers(this, Singleton.Instance.Page);
            ViewController2 viewController2 = new ViewController2(this);
            viewController2.IsGreen();
        }
        private void A3_And_A2_Menu_Click(object sender, EventArgs e)
        {
            ViewController2 viewController2 = new ViewController2(this);
            viewController2.CheckedMenuOption(sender);
        }

        private void SkirtsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModelConvertAndSize modelConvertAndSize = new ModelConvertAndSize();
            modelConvertAndSize.Skirts(this);
        }

        private void A4x2ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ModelConvertAndSize modelConvertAndSize= new ModelConvertAndSize();
            modelConvertAndSize.Where(Singleton.Instance.Page);
            modelConvertAndSize.SizeforA3();
        }

        private void A4x4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModelConvertAndSize modelConvertAndSize = new ModelConvertAndSize();
            modelConvertAndSize.Where(Singleton.Instance.Page);
            modelConvertAndSize.SizeforA2();
        }
    }
}


// Pobierz obraz wyświetlany w kontrolce PictureBox
// Image image = PictureOpen.Image;

// Utwórz obiekt Graphics dla obrazu  nie działa z skanami imao
//using (Graphics graphics = Graphics.FromImage(image))
//{
//    // Ustaw kolor i czcionkę
//    Brush brush = new SolidBrush(Color.Black);
//    Font font = new Font("Arial", 25);

//    // Narysuj tekst w lewym górnym rogu obrazu
//    string text = $"Strona {currentPageNumber} z {maxPage2}";
//    graphics.DrawString(text, font, brush, new PointF(10, 10));
//}

//// Ustaw obraz z powrotem do kontrolki PictureBox
//PictureOpen.Image = image;