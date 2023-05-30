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
  
        private ViewFormController viewFormController;
        private ViewController viewController;
        public FormController1()
        {
            InitializeComponent();
            viewController = new ViewController(this);
          viewFormController = new ViewFormController(this);
            UpdateWebBrowser();
            Singleton.Instance.FilePath = null;
        }

        /// //////////////////////////////////////dodwanie plku po przez wybór windows 
        public void AddPdfBt_Click(object sender, EventArgs e)
        {
            ViewController.OpenFileDialog();
          
            UpdateWebBrowser();
        }
        public void UpdateWebBrowser()
        {
            viewController.UpdateWebBrowser();
        }
        private void FormController1_DragDrop(object sender, DragEventArgs e)
        {
            UpdateWebBrowser();
        }

        public void ConvertBt_Click(object sender, EventArgs e)
        { 
            while (Singleton.Instance.FilePath ==null)
            {
                AddPdfBt_Click(sender, e);
            };
            
            var modelConvert = new ModelConvertAndSize();
            modelConvert.HowTOConvetPdf(this);//potem model ma sprawdzac która opcja zaznaczona i wywoływac odpowiednią metode 

            string outputDirectory = Singleton.Instance.OutPutDirectory;
            string outFilleName = $"{outputDirectory}" + "/" + $"{System.IO.Path.GetFileNameWithoutExtension(Singleton.Instance.FilePath)}_page1.png";
            Singleton.Instance.OutFilleName = outFilleName;
            Singleton.Instance.NewFilleName = outFilleName;
            // Utworzenie nowego obiektu Form2
            FormController2 form2 = new FormController2
            {
                // Wywołanie metody Show() lub ShowDialog() na nowym obiekcie Form2
                TopLevel = true
            };
            form2.Show();
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

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void ConvertFastAndSlowToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            viewController.CheckedMenuOption(sender);
        }
    }
}

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

//private void checkBox1_CheckedChanged(object sender, EventArgs e)
//{

//    if (textBox1.Text != null)
//    {
//        // odczytanie wartości pola FilePath z klasy Singleton
//        string filePath = Singleton.Instance.FilePath;
//        string filenameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(filePath);
//        string outputDirctory = Singleton.Instance.OutPutDirectory;
//        string where = System.IO.Path.Combine(outputDirctory, $"{filenameWithoutExtension}_page{textBox1.Text}.png");
//        ModelCusttomMesage modelCusttomMesage = new ModelCusttomMesage(where);
//        modelCusttomMesage.ShowCustomMessageBox();
//        ModelSize model = new ModelSize();

//        //  w zależność od wyboru w menu
//        model.Sizefor4(where);
//        // model.SizeforA3(where);  // add somfthig 

//    }
//}