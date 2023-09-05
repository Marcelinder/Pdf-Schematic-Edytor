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
    internal class LogicButtonAndSave
    {
        private const string FileNamePattern = @"_page(\d+)\.\w+$";
        private const string PageNumberReplacementPattern = "_page{0}.";
        readonly string outFilleName = SingletonInformationStorage.Instance.OutFilleName;
        readonly int maxPage = SingletonInformationStorage.Instance.MaxPage;
        int pageNumber;

        public LogicButtonAndSave() {}

    
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
            SingletonInformationStorage.Instance.Page = pageNumber;
            SingletonInformationStorage.Instance.NewFilleName = GetFilePathForPageNumber(pageNumber);
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
