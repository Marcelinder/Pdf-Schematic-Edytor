using PdfSchematicEditor;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace PdfSchematicEditor
{
    public class ControlOfBasicFunctionsAllWindow : NativeWindow
    {
        private Form form;
        public bool isMouseDown = false;
        //private const int BORDER_WIDTH = 8;
        //private const int WM_NCHITTEST = 0x0084;
        // private const int WM_SIZING = 0x0214;
        private const int HTBOTTOMRIGHT = 17;
        private const int HTBOTTOM = 15;
        private const int HTRIGHT = 11;
        const int HTTOPLEFT = 13;
        const int HTBOTTOMLEFT = 16;
        const int HTLEFT = 10;
        const int HTTOPRIGHT = 14;
        const int HTTOP = 12;
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        private static extern bool ReleaseCapture();


        public ControlOfBasicFunctionsAllWindow(Form form)
        {
            this.form = form;
            AssignHandle(form.Handle); // Przypisz uchwyt formularza do tej klasy

           // Color leadingColor = SystemColors.ActiveBorder; //bliski najbliższy kolor do systemowego  Nie używane

            // Dodaj obsługę zdarzeń dla wszystkich formularzy
            form.MouseDown += Form_MouseDown;

            // Dodaj obsługę zdarzeń specyficznych dla formularza 1
            if (form is FileSelectionWindowController form1)
            {
                form1.CloseBt.Click += CloseButton_Click;
                form1.MaximizeBt.Click += MaximizeButton_Click;
                form1.MinimizeBt.Click += MinimizeButton_Click;
                form1.MenuStrip.MouseDown += MenuStrip_MouseDown;
        
                form1.AllowDrop = true;  // dodawanie przez upuszczanie 
                form1.DragEnter += Form1_DragEnter;
                form1.DragDrop += Form1_DragDrop;
            }

            // Dodaj obsługę zdarzeń specyficznych dla formularza 2
            else if (form is PageSelectionAndEditingWindowController form2)
            {
                form2.CloseBt.Click += CloseButton_Click;
                form2.MaximizeBt.Click += MaximizeButton_Click;
                form2.MinimizeBt.Click += MinimizeButton_Click;
                form2.MenuStrip.MouseDown += MenuStrip_MouseDown;
            }
        }
 
      

        private void CloseButton_Click(object sender, EventArgs e)
        {
            form.Close();
        }

        private void MaximizeButton_Click(object sender, EventArgs e)
        {
            if (form.WindowState == FormWindowState.Normal)
            {
                form.WindowState = FormWindowState.Maximized;
                SetMaximizeButtonText("2");
            }
            else if (form.WindowState == FormWindowState.Maximized)
            {
                form.WindowState = FormWindowState.Normal;
                SetMaximizeButtonText("1");
            }
        }

        public void SetMaximizeButtonText(string buttonText)
        {
            if (form.Controls.Find("maximizeBt", true).FirstOrDefault() is Button maximizeBt)
            {
                maximizeBt.Text = buttonText;
            }
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            form.WindowState = FormWindowState.Minimized;
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(form.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void MenuStrip_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(form.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            isMouseDown = true;
            Resize();   
        }

        private void Resize()
        {
            // Sprawdź, czy przycisk myszy jest wciąż wciśnięty
            if (isMouseDown)
            {
                // Pobierz ekran, na którym znajduje się formularz
                Screen screen = Screen.FromControl(form);

                // Sprawdź, czy formularz znajduje się na górze ekranu
                if (form.Location.Y == screen.WorkingArea.Y)
                {
                    // Sprawdź, czy górna krawędź formularza jest widoczna na ekranie
                    if (form.Bounds.Top >= screen.Bounds.Top)
                    {
                        // Jeśli tak, zmień stan okna na maksymalizowany
                        if (form.WindowState != FormWindowState.Maximized)
                        {
                            form.WindowState = FormWindowState.Maximized;
                            //Button button4 = (Button)form1.Controls.Find("button4", true)[0];
                            SetMaximizeButtonText("1");
                        }
                    }
                }
                else
                {
                    // Jeśli nie, zmień stan okna na normalny
                    if (form.WindowState != FormWindowState.Maximized)
                    {
                        SetMaximizeButtonText("1");
                    }
                    // Sprawdź, czy lewa krawędź formularza znajduje się w połowie ekranu lub dalej
                    if (form.Left >= screen.WorkingArea.Left + screen.WorkingArea.Width / 2)
                    {

                        // Ustaw szerokość i pozycję formularza na 50% szerokości i 100% wysokości ekranu
                        int width = screen.WorkingArea.Width / 2;
                        int height = screen.WorkingArea.Height;
                        int x = screen.WorkingArea.Right - width;
                        int y = screen.WorkingArea.Top;

                        form.Width = width;
                        form.Height = height;
                        form.Left = x;
                        form.Top = y;
                    }
                    // Sprawdź, czy prawa krawędź formularza znajduje się w połowie ekranu lub mniej
                    else if (form.Right <= screen.WorkingArea.Right - screen.WorkingArea.Width / 2)
                    {
                        // Ustaw szerokość i pozycję formularza na 50% szerokości i 100% wysokości ekranu
                        int width = screen.WorkingArea.Width / 2;
                        int height = screen.WorkingArea.Height;
                        int x = screen.WorkingArea.Left;
                        int y = screen.WorkingArea.Top;

                        form.Width = width;
                        form.Height = height;
                        form.Left = x;
                        form.Top = y;
                    }
                }
            }
            isMouseDown = false;
        }

        protected override void WndProc(ref Message m)
        {
            // Wywołanie metody bazowej WndProc, aby obsłużyć standardowe zachowanie okna
            base.WndProc(ref m);

            // Sprawdzenie, czy wiadomość jest typu WM_NCHITTEST, co oznacza, że kursor myszy znajduje się w obszarze nieklienckim (np. obramowaniu) okna
            if (m.Msg == 0x84) // WM_NCHITTEST
            {
                // Pobranie położenia kursora myszy w formularzu
                int x = (int)(m.LParam.ToInt64() & 0xFFFF);
                int y = (int)((m.LParam.ToInt64() & 0xFFFF0000) >> 16);
                Point pt = form.PointToClient(new Point(x, y));

                // Sprawdzenie, czy kursor myszy znajduje się na krawędzi formularza
                if (pt.X <= 5)
                {
                    // Sprawdzenie, czy kursor myszy znajduje się na górnej lewej krawędzi
                    if (pt.Y <= 5)
                        m.Result = (IntPtr)HTTOPLEFT; // Ustawienie wartości m.Result na HTTOPLEFT oznacza, że kursor myszy powinien wyświetlać się jako skośny dwukierunkowy kursor z lewej strony i z góry
                                                      // Sprawdzenie, czy kursor myszy znajduje się na dolnej lewej krawędzi
                    else if (pt.Y >= form.ClientSize.Height - 5)
                        m.Result = (IntPtr)HTBOTTOMLEFT; // Ustawienie wartości m.Result na HTBOTTOMLEFT oznacza, że kursor myszy powinien wyświetlać się jako skośny dwukierunkowy kursor z lewej strony i z dołu
                                                         // Jeśli kursor myszy znajduje się gdzieś pomiędzy, ustawienie wartości m.Result na HTLEFT oznacza, że kursor myszy powinien wyświetlać się jako poziomy kursor z lewej strony
                    else m.Result = (IntPtr)HTLEFT;
                }
                // Analogicznie dla prawej krawędzi
                else if (pt.X >= form.ClientSize.Width - 5)
                {
                    if (pt.Y <= 5)
                        m.Result = (IntPtr)HTTOPRIGHT; // Jeśli kursor myszy znajduje się w odległości 5 pikseli od górnego prawego rogu okna, to ustaw m.Result na HTTOPRIGHT, co oznacza, że kursor myszy powinien wyświetlić się jako skośny dwukierunkowy kursor z prawej strony i z góry.
                    else if (pt.Y >= form.ClientSize.Height - 5)
                        m.Result = (IntPtr)HTBOTTOMRIGHT; // Jeśli kursor myszy znajduje się w odległości 5 pikseli od dolnego prawego rogu okna, to ustaw m.Result na HTBOTTOMRIGHT, co oznacza, że kursor myszy powinien wyświetlić się jako skośny dwukierunkowy kursor z prawej strony i z dołu.
                    else m.Result = (IntPtr)HTRIGHT; // W przeciwnym razie, jeśli kursor myszy znajduje się w odległości większej niż 5 pikseli od prawej krawędzi okna, ustaw m.Result na HTRIGHT, co oznacza, że kursor myszy powinien wyświetlać się jako poziomy kursor z prawej strony.
                }
                else if (pt.Y <= 5)
                {
                    m.Result = (IntPtr)HTTOP; // Jeśli kursor myszy znajduje się w odległości 5 pikseli od górnej krawędzi okna, to ustaw m.Result na HTTOP, co oznacza, że kursor myszy powinien wyświetlić się jako pionowy kursor z góry.
                }
                else if (pt.Y >= form.ClientSize.Height - 5)
                {
                    m.Result = (IntPtr)HTBOTTOM; // Jeśli kursor myszy znajduje się w odległości 5 pikseli od dolnej krawędzi okna, to ustaw m.Result na HTBOTTOM, co oznacza, że kursor myszy powinien wyświetlić się jako pionowy kursor z dołu.
                }
            }

        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            // Check if the data being dragged is a file
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Set the effect to indicate that a file can be dropped here
                e.Effect = DragDropEffects.Copy;
            }
        }

        public void Form1_DragDrop(object sender, DragEventArgs e)
        {
            // Get the file path from the data being dropped
            string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);
            string filePath = filePaths[0];
            // Pobierz istniejącą instancję kontrolera

            // aktualizacja wartości pola FilePath w klasie SingletonInformationStorage
            SingletonInformationStorage.Instance.FilePath = filePath;

            // zapisanie wartości pola FilePath do pliku w klasie SingletonInformationStorage
            SingletonInformationStorage.Instance.SaveToFile();
        }
      
    }
}
