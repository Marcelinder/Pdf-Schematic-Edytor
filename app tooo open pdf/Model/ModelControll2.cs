using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PdfSchematicEditor
{
    internal class ModelControll2
    {
        private const string FileNamePattern = @"_page(\d+)\.\w+$";
        private const string PageNumberReplacementPattern = "_page{0}.";
        readonly string outFilleName = Singleton.Instance.OutFilleName;
        readonly int maxPage = Singleton.Instance.MaxPage;
        int pageNumber;

        public ModelControll2() {  }

    
        public void BTNext()
        {
            int currentPageNumber = GetCurrentPageNumber(outFilleName);
            int nextPageNumber = currentPageNumber + 1;
            pageNumber = File.Exists(GetFilePathForPageNumber(nextPageNumber)) ? nextPageNumber : 1;
            SingletonUpdate();
        }

        public void BtPrevious()
        {
            int currentPageNumber = GetCurrentPageNumber(outFilleName);
            int previousPageNumber = currentPageNumber - 1;
            pageNumber = File.Exists(GetFilePathForPageNumber(previousPageNumber)) ? previousPageNumber : maxPage;
            SingletonUpdate();
        }

        private void SingletonUpdate()
        {
            Singleton.Instance.Page = pageNumber;
            Singleton.Instance.NewFilleName = GetFilePathForPageNumber(pageNumber);
        }

        private int GetCurrentPageNumber(string fileName)
        {
            Match match = Regex.Match(fileName, FileNamePattern);
            int currentPageNumber = int.Parse(match.Groups[1].Value);
            return currentPageNumber;
        }

        private string GetFilePathForPageNumber(int pageNumber)
        {
            return Regex.Replace(outFilleName, string.Format(PageNumberReplacementPattern, GetCurrentPageNumber(outFilleName)), string.Format(PageNumberReplacementPattern, pageNumber));
        }
    }

}
//public void BTNext(FormController2 formController)
//{
//    // Pobranie numeru aktualnej strony z nazwy pliku
//    Match match = Regex.Match(outFilleName, @"_page(\d+)\.\w+$");
//    int currentPageNumber = int.Parse(match.Groups[1].Value);

//    // Obliczenie numeru następnej strony
//    int nextPageNumber = currentPageNumber + 1;

//    // Zbudowanie nowej ścieżki do pliku z następną stroną
//    newFilePath = Regex.Replace(outFilleName, $"_page{currentPageNumber}\\.", $"_page{nextPageNumber}.");

//    // Sprawdzenie, czy plik z następną stroną istnieje
//    if (File.Exists(newFilePath))
//    {
//        // Jeśli istnieje, to wyświetlenie obrazu z następnej strony
//        ViewCallSet(formController, nextPageNumber);
//    }
//    else
//    {
//        // Jeśli nie istnieje, to wyświetlenie pierwszej strony
//        newFilePath = Regex.Replace(outFilleName, $"_page{currentPageNumber}\\.", $"_page{1}.");
//        ViewCallSet(formController, 1);
//    }
//}
//public void BtPrevious(FormController2 formController)
//{
//    // Pobranie numeru aktualnej strony z nazwy pliku
//    Match match = Regex.Match(outFilleName, @"_page(\d+)\.\w+$");
//    int currentPageNumber = int.Parse(match.Groups[1].Value);

//    // Obliczenie numeru poprzedniej strony
//    int previousPageNumber = currentPageNumber - 1;

//    // Zbudowanie nowej ścieżki do pliku z poprzednią stroną
//    newFilePath = Regex.Replace(outFilleName, $"_page{currentPageNumber}\\.", $"_page{previousPageNumber}.");

//    // Sprawdzenie, czy plik z poprzednią stroną istnieje
//    if (File.Exists(newFilePath))
//    {
//        ViewCallSet(formController, previousPageNumber);
//    }
//    else
//    {
//        // Jeśli nie istnieje, to wyświetlenie ostatniej strony
//        newFilePath = Regex.Replace(outFilleName, $"_page{currentPageNumber}\\.", $"_page{maxPage}.");
//        ViewCallSet(formController, maxPage);
//    }
//}