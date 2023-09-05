using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace PdfSchematicEditor
{
    public class SingletonInformationStorage   
    {
        private static SingletonInformationStorage instance;
        private static string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        private static string filename = "AllVaribles.txt";
        public string VariableStoragePath = Path.Combine(directory, filename);
        public string outPutDirectory = "C:\\ConvertedImages";
        private string outFilleName;
        private string newFilleName;
        private string filePath = Path.Combine(directory, "pdfseting.pdf");
        private int maxPage;
        private int page;
        private bool isPageInNumbers;



        private SingletonInformationStorage(){}

        public static SingletonInformationStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonInformationStorage();
                }
                return instance;
            }
        }
        public bool IsPageInNumbers
        {
            get { return isPageInNumbers; }
            set { isPageInNumbers = value; }
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
        public string NewFilleName
        {
            get { return newFilleName; }
            set { newFilleName = value; }
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
                sw.WriteLine("newFilleName=" + newFilleName);
                sw.WriteLine("isPageInNumbers=" + isPageInNumbers);
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
                            case "newFilleName":
                                newFilleName = fieldValue;
                                break;
                            case "isPageInNumbers":
                                isPageInNumbers = bool.Parse(fieldValue);
                                break;

                        }
                    }
                }
            }
        }
    }
}
