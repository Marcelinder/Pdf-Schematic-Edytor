using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using ImageMagick;
using System.Threading.Tasks;
using System.Diagnostics;
using Path = System.IO.Path;

namespace app_tooo_open_pdf
{

    public partial class FormController1 : Form
    {

      private readonly ViewFormController viewFormController;
        private ViewController viewController;
        public FormController1()
        {
            InitializeComponent();
            viewController = new ViewController(this);
            viewFormController = new ViewFormController(this);
        }

        /// //////////////////////////////////////dodwanie plku po przez wybór windows 
        private void AddPdfBt_Click(object sender, EventArgs e)
        {
            ViewController.OpenFileDialog();
        }
        
        private void ConvertBt_Click(object sender, EventArgs e)
        {
            // odczytanie wartości pola FilePath z klasy Singleton
           string filePath = Singleton.Instance.FilePath;
            // odczytanie wartości pola FilePath z klasy Singleton
            int maxPage = Singleton.Instance.MaxPage;

            var modelConvert = new ModelConvert(this, viewController);
            
            modelConvert.ConvertPDFtpPNG();
            string outputDirectory = Singleton.Instance.OutPutDirectory;
            string outFilleName = $"{outputDirectory}" + "/" + $"{System.IO.Path.GetFileNameWithoutExtension(filePath)}_page1.png";
            Singleton.Instance.OutFilleName = outFilleName;
            // Utworzenie nowego obiektu Form2
            FormController2 form2 = new FormController2();
          
            // Wywołanie metody Show() lub ShowDialog() na nowym obiekcie Form2
            form2.TopLevel = true;
            form2.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
            if (textBox1.Text != null)
            {
                // odczytanie wartości pola FilePath z klasy Singleton
                string filePath = Singleton.Instance.FilePath;
                string filenameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(filePath);
                string outputDirctory = Singleton.Instance.OutPutDirectory;
                string where = System.IO.Path.Combine(outputDirctory, $"{filenameWithoutExtension}_page{textBox1.Text}.png");
                ModelCusttomMesage modelCusttomMesage = new ModelCusttomMesage(where);
                modelCusttomMesage.ShowCustomMessageBox();
                ModelSize model = new ModelSize();

                //  w zależność od wyboru w menu
                model.Sizefor4(where);
                // model.SizeforA3(where);  // add somfthig 

            }
        }
     

       
        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

            //instrukcja dla menu
        }

        private void FormController1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
//if (WindowState == FormWindowState.Maximized) // sprawdzanie, czy okno jest w trybie maksymalizacji
//{
//    WindowState = FormWindowState.Normal; // przywrócenie okna do stanu normalnego
//    button4.Text = "1";
//}


//Tworze kolekcję obrazów za pomocą klasy MagickImageCollection  zostawić WOLNY SPOSÓB
//using (var images = new MagickImageCollection())
//{
//    //Wczytuje wszystkie strony pliku PDF i dodaje je do kolekcji images
//    images.Read(inputFile, settings);

//    //Tworze zmienną page i ustawiam ją na 1.
//    //Następnie iteruje przez kolekcję images i dla każdego obrazu zapisuje go do pliku PNG
//    //o nazwie składającej się z nazwy pliku wejściowego (bez rozszerzenia),
//    //numeru strony i rozszerzenia PNG
//    var page = 1;
//    foreach (var image in images)
//    {
//        // Ustawiam tło na białe zamiast przezroczystego
//        // image.BackgroundColor = MagickColors.White;

//        // Usuwam alfa-kanał, który powoduje problemy z siatką w tle
//        image.Alpha(AlphaOption.Remove);

//        // Zapisuję obraz w formacie PNG
//        image.Write(outputDirectory + "/" + System.IO.Path.GetFileNameWithoutExtension
//            (inputFile) + "_page" + page + ".png");

//        page++;
//    }
//}



//Stopwatch stopwatchFor = new Stopwatch();
//stopwatchFor.Start();

//// Tworzy pętlę równoległą, która iteruje przez kolekcję images
//Parallel.For(0, images.Count, i =>
//{
//    // Ustawia tło na białe zamiast przezroczystego
//    images[i].BackgroundColor = MagickColors.White;

//    // Usuwa alfa-kanał, który powoduje problemy z siatką w tle
//    images[i].Alpha(AlphaOption.Remove);

//    // Zapisuje obraz w formacie PNG
//    images[i].Write(outputDirectory + "/" + System.IO.Path.GetFileNameWithoutExtension(inputFile) + "_page" + (i + 1) + ".png");
//});

//stopwatchFor.Stop();
//TimeSpan timeFor = stopwatchFor.Elapsed;

//MessageBox.Show($"Czas przetwarzania dla 'for': {timeFor.TotalSeconds} s");


// wpf tylko


//private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
//{
//    if (e.Button == MouseButtons.Left)
//    {
//        if (WindowState == FormWindowState.Maximized)
//        {
//            WindowState = FormWindowState.Normal;
//        }
//        DragMove();
//    }
//}
////// własny move przed poznaniem metody 
/////private bool isDragging = false;
//private Point lastCursor;
//private Point lastForm;
//private Point initialCursor;
//private Point startLocation;

//private void menuStrip1_MouseMove(object sender, MouseEventArgs e)
//{
//    if (isDragging) // sprawdzanie, czy użytkownik aktualnie przeciąga formularz
//    {
//        // ograniczenie ruchu kursora do granic menuStrip1
//        Rectangle rect = menuStrip1.RectangleToScreen(menuStrip1.ClientRectangle);
//        Cursor.Clip = rect;
//        // Cursor.Clip = new Rectangle(initialCursor, new Size(1, 1));


//        int dx = Cursor.Position.X - lastCursor.X; // obliczenie różnicy między aktualną pozycją kursora myszy a pozycją kursora myszy w momencie naciśnięcia przycisku myszy
//        int dy = Cursor.Position.Y - lastCursor.Y; // obliczenie różnicy między aktualną pozycją kursora myszy a pozycją kursora myszy w momencie naciśnięcia przycisku myszy
//        this.Location = new Point(lastForm.X + dx, lastForm.Y + dy); // ustawienie nowej pozycji formularza na podstawie pozycji formularza w momencie naciśnięcia przycisku myszy oraz różnicy między pozycją kursora myszy w momencie naciśnięcia przycisku myszy a aktualną pozycją kursora myszy
//    }
//}

//private void menuStrip1_MouseUp(object sender, MouseEventArgs e)
//{

//    if (e.Button == MouseButtons.Left) // sprawdzanie, czy użytkownik puścił lewy przycisk myszy
//    {
//        Cursor.Clip = Rectangle.Empty;
//        isDragging = false; // ustawienie zmiennej isDragging na false, aby wskazać, że użytkownik przestał przeciągać formularz
//    }
//}
//private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
//{

//    if (e.Button == MouseButtons.Left) // sprawdzanie, czy użytkownik nacisnął lewy przycisk myszy
//    {
//        if (WindowState == FormWindowState.Maximized) // sprawdzanie, czy okno jest w trybie maksymalizacji
//        {

//            WindowState = FormWindowState.Normal; // przywrócenie okna do stanu normalnego
//        }
//        isDragging = true; // ustawienie zmiennej isDragging na true, aby wskazać, że użytkownik przeciąga formularz
//        lastCursor = Cursor.Position; // zapisanie aktualnej pozycji kursora myszy w zmiennej lastCursor
//        lastForm = this.Location; // zapisanie aktualnej pozycji formularza w zmiennej lastForm
//        startLocation = e.Location; ; // zapisanie początkowej pozycji kursora myszy
//        if (WindowState == FormWindowState.Maximized) // sprawdzanie, czy okno jest w trybie maksymalizacji
//        {

//            WindowState = FormWindowState.Normal; // przywrócenie okna do stanu normalnego
//        }

//    }
//}

////////////// Dalej to samo 
///     //private bool isDragging = false; // zmienna, która wskazuje, czy użytkownik aktualnie przeciąga formularz
//private Point lastCursor; // zmienna przechowująca pozycję kursora myszy w momencie naciśnięcia przycisku myszy
//private Point lastForm; // zmienna przechowująca pozycję formularza w momencie naciśnięcia przycisku myszy

//// Obsługa zdarzenia MouseMove dla menuStrip1
//private void menuStrip1_MouseMove(object sender, MouseEventArgs e)
//{
//    if (isDragging) // sprawdzanie, czy użytkownik aktualnie przeciąga formularz
//    {
//        // obliczenie różnicy między aktualną pozycją kursora myszy a pozycją kursora myszy w momencie naciśnięcia przycisku myszy
//        int dx = Cursor.Position.X - lastCursor.X;
//        int dy = Cursor.Position.Y - lastCursor.Y;

//        // ustawienie nowej pozycji formularza na podstawie pozycji formularza w momencie naciśnięcia przycisku myszy oraz różnicy między pozycją kursora myszy w momencie naciśnięcia przycisku myszy a aktualną pozycją kursora myszy
//        this.Location = new Point(lastForm.X + dx, lastForm.Y + dy);
//    }
//}

//// Obsługa zdarzenia MouseUp dla menuStrip1
//private void menuStrip1_MouseUp(object sender, MouseEventArgs e)
//{
//    if (e.Button == MouseButtons.Left) // sprawdzanie, czy użytkownik puścił lewy przycisk myszy
//    {
//        isDragging = false; // ustawienie zmiennej isDragging na false, aby wskazać, że użytkownik przestał przeciągać formularz
//    }
//}

//// Obsługa zdarzenia MouseDown dla menuStrip1
//private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
//{
//    if (e.Button == MouseButtons.Left) // sprawdzanie, czy użytkownik nacisnął lewy przycisk myszy
//    {
//        if (WindowState == FormWindowState.Maximized) // sprawdzanie, czy okno jest w trybie maksymalizacji
//        {
//            WindowState = FormWindowState.Normal; // przywrócenie okna do stanu normalnego
//        }
//        isDragging = true; // ustawienie zmiennej isDragging na true, aby wskazać, że użytkownik przeciąga formularz
//        lastCursor = Cursor.Position; // zapisanie aktualnej pozycji kursora myszy w zmiennej lastCursor
//        lastForm = this.Location; // zapisanie aktualnej pozycji formularza w zmiennej lastForm
//    }
//}

///

//Kontroler zarządza zdarzeniami i w zależności od tego, jakie to zdarzenia, decyduje,
//co z nimi zrobić. Jeśli zdarzenie wymaga zmiany w modelu, kontroler zmienia stan modelu,
//a jeśli wymaga zmiany w widoku, kontroler informuje widok o zmianie.
//Widok odpowiada za prezentację danych użytkownikowi, ale nie powinien sam decydować o tym,
//co się dzieje po zdarzeniu, tylko powinien poinformować kontroler o tym, co się stało.
//Model natomiast zajmuje się logiką biznesową i nie powinien sam decydować o tym,
//jak prezentowane są dane użytkownikowi.

//W przypadku dodawania pliku, zdarzenie kliknięcia przycisku powinno być obsługiwane przez kontroler.
//Kontroler może wywołać odpowiednią metodę w modelu,
//która zajmie się dodaniem pliku do kolekcji plików lub innej odpowiedniej operacji.
//Jeśli operacja ta wpływa na wygląd widoku,
//kontroler powinien poinformować widok o zmianach i przekazać mu nowe dane.
