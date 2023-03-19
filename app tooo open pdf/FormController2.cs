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
        private int maxPage = Singleton.Instance.MaxPage;
        private string outFilleName = Singleton.Instance.OutFilleName;
        private ViewFormController viewController;
        
        public FormController2()
        {
            InitializeComponent();
            PictureOpen.SizeMode = PictureBoxSizeMode.Zoom;

            ViewController2 viewController2 = new ViewController2(this);
            viewController2.SetImage(outFilleName,1);
            //this.Opacity = 0.5;
            viewController = new ViewFormController(this);
            this.MouseWheel += new MouseEventHandler(panel1_MouseWheel);//ew form2 loas

            //  MessageBox.Show($"{maxPage}");  max page kontrola previous oraz next błąd gdy 1 strona
        }

        private void Form2_SizeChanged(object sender, EventArgs e)
        {
           // label1.Parent = PictureOpen;
            //label1.BackColor = Color.Transparent;
        }
        private void Nextbt_Click(object sender, EventArgs e)
        {
            ModelControll2 modelContrroll2 = new ModelControll2();
            modelContrroll2.BTNext(this);
        }

        public void Previousbt_Click(object sender, EventArgs e)
        {
            ModelControll2 modelContrroll2 = new ModelControll2();
            modelContrroll2.BtPrevious(this);
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
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
        }

    

     

        private void konwertujDoA3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            // Tworzenie zmiennej menuItem, która przechowuje obiekt ToolStripMenuItem z opcją "konwertujDoA3ToolStripMenuItem"
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

            // Ustawienie właściwości Checked na przeciwną wartość obecnej opcji
            menuItem.Checked = !menuItem.Checked;
            //string filenameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(filePath);

            //string where = System.IO.Path.Combine(a, $"{filenameWithoutExtension}_page{textBox1.Text}.png");
            //ModelCusttomMesage modelCusttomMesage = new ModelCusttomMesage(where);
            //modelCusttomMesage.ShowCustomMessageBox();
            //ModelSize model = new ModelSize();

            ////  w zależność od wyboru w menu
            //model.Sizefor4(where);

        }

        private void kowertujDoA4ToolStripMenuItem_Click(object sender, EventArgs e)
        {// Tworzenie zmiennej menuItem, która przechowuje obiekt ToolStripMenuItem z opcją "konwertujDoA3ToolStripMenuItem"
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

            // Ustawienie właściwości Checked na przeciwną wartość obecnej opcji
            menuItem.Checked = !menuItem.Checked;
            //string filenameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(filePath);

            //string where = System.IO.Path.Combine(a, $"{filenameWithoutExtension}_page{textBox1.Text}.png");
            //ModelCusttomMesage modelCusttomMesage = new ModelCusttomMesage(where);
            //modelCusttomMesage.ShowCustomMessageBox();
            //ModelSize model = new ModelSize();

            ////  w zależność od wyboru w menu
            //model.Sizefor4(where);

        }
        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int cursorPos = toolStripTextBox1.SelectionStart;

            // jeśli wpisano spację, to dodaj przecinek przed nią
            if (e.KeyChar == ' ' && cursorPos > 0 && char.IsDigit(toolStripTextBox1.Text[cursorPos - 1]))
            {
                toolStripTextBox1.Text = toolStripTextBox1.Text.Insert(cursorPos, ", ");
                toolStripTextBox1.SelectionStart = cursorPos + 2;
                e.Handled = true;
            }
            // sprawdzenie czy wpisany znak to cyfra lub spacja
            else if (!char.IsDigit(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // zablokuj wpisanie innego znaku
                return;
            }
            // zablokuj dodawanie spacji jeśli nie ma cyfry przed nią
            else if (e.KeyChar == ' ' && (cursorPos == 0 || !char.IsDigit(toolStripTextBox1.Text[cursorPos - 1])))
            {
                e.Handled = true;
                return;
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            ViewController2 viewController2 = new ViewController2(this);
            viewController2.TollStriptTextADD();
        }

        private void kONWERTUJToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // konwersja tego co w textbox
        }

        private void toolStripTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            toolStripTextBox1.SelectionStart = toolStripTextBox1.Text.Length;
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                toolStripTextBox1.SelectionStart = toolStripTextBox1.Text.Length;
                e.Handled = true;
            }
        }

        private void PictureOpen_Click(object sender, EventArgs e)
        {
            label1_Click(sender, e);
        }
    }
}


