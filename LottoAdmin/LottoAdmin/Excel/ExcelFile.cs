using System.IO;
using System.Data;
namespace LottoAdmin.Excel
{
    public class ExcelFile
    {

        public string Files(DataSet dataset, string fileName)
        {
            string xlsxFilePath = Path.Combine("C:\\Report", fileName);
            //string xlsxFilePath = Path.Combine(Directory.GetCurrentDirectory(), "DownloadFiles", fileName);
            CreateExcelFile.CreateExcelDocument(dataset, xlsxFilePath);
            return xlsxFilePath;
        }

        public string Files(DataTable datatable, string fileName)
        {
            string xlsxFilePath = Path.Combine("C:\\Report", fileName);
            //string xlsxFilePath = Path.Combine(Directory.GetCurrentDirectory(), "DownloadFiles", fileName);
            CreateExcelFile.CreateExcelDocument(datatable, xlsxFilePath);
            return xlsxFilePath;
        }
    }
}
