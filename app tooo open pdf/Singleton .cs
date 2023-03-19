using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace app_tooo_open_pdf
{
    public class Singleton  /// klasa zarządzająca zmiennymi zapisywanie ich w jedym miejscu by były dostepne w każdej klasie 
    {
        private static Singleton instance;
        private static string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        private static string filename = "AllVaribles.txt";
        public string VariableStoragePath = Path.Combine(directory, filename);
        private int maxPage;
        private int page;
        private string filePath;
        public string outPutDirectory = "C:\\ConvertedImages";
        private string outFilleName;
        
        private Singleton()
        {
            // konstruktor prywatny, aby uniemożliwić tworzenie nowych instancji
        }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }

        public int MaxPage
        {
            get { return maxPage; }
            set { maxPage = value; }
        }

        public int Page
        {
            get { return page; }
            set { page = value; }
        }

        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        public string OutPutDirectory
        {
            get { return outPutDirectory; }
            set { outPutDirectory = value; }
        }
        public string OutFilleName
        {
            get { return outFilleName; }
            set { outFilleName = value; }
        }
        

        public void SaveToFile()
        {
            using (StreamWriter sw = new StreamWriter(VariableStoragePath))
            {
                sw.WriteLine("maxPage=" + maxPage);
                sw.WriteLine("page=" + page);
                sw.WriteLine("filePath=" + filePath);
                sw.WriteLine("outPutDirectory=" + outPutDirectory);
                sw.WriteLine("outFilleName=" +  outFilleName);
            }
            //ModelCusttomMesage model = new ModelCusttomMesage(VariableStoragePath);
            //model.ShowCustomMessageBox();
        }

        public void LoadFromFile()// w przypadku chęci korzystania z tego samego co wcześniej 
        {
            // wczytanie wartości z pliku o ścieżce przechowywanej w polu filePath
            using (StreamReader sr = new StreamReader(VariableStoragePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split('=');
                    if (parts.Length == 2)
                    {
                        string fieldName = parts[0];
                        string fieldValue = parts[1];
                        switch (fieldName)
                        {
                            case "maxPage":
                                maxPage = int.Parse(fieldValue);
                                break;
                            case "page":
                                page = int.Parse(fieldValue);
                                break;
                            case "filePath":
                                filePath = fieldValue;
                                break;
                            case "outPutDirectory":
                                outPutDirectory = fieldValue;
                                break;
                            case "outFilleName":
                                outFilleName = fieldValue;
                                break;
                        }
                    }
                }
            }
        }
    }
}
