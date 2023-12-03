using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System.Data;

namespace Sha.Common.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public class ExcelHelper
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDataTable(string filePath)
        {
            DataTable table = new DataTable();
            if (!File.Exists(filePath)) { return table; }
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                string fileExtension = Path.GetExtension(filePath);
                if (fileExtension.ToUpper() == ".XLS") { table = XlsToDataTable(fileStream); }
                if (fileExtension.ToUpper() == ".XLSX") { table = XlsxToDataTable(fileStream); }
            }
            return table;
        }

        /// <summary>
        /// EXCEL（2003版）
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private static DataTable XlsToDataTable(Stream stream)
        {
            DataTable table = new DataTable();
            HSSFWorkbook workbook = new HSSFWorkbook(stream);
            HSSFSheet sheet = (HSSFSheet)workbook.GetSheetAt(workbook.ActiveSheetIndex);
            HSSFRow headrow = (HSSFRow)sheet.GetRow(0);
            int lastCellNum = (int)headrow.LastCellNum;
            for (int i = (int)headrow.FirstCellNum; i < lastCellNum; i++)
            {
                DataColumn column = new DataColumn(headrow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }
            int lastRowNum = sheet.LastRowNum;
            for (int i = sheet.FirstRowNum + 1; i < sheet.LastRowNum; i++)
            {
                HSSFRow bodyrow = (HSSFRow)sheet.GetRow(i);
                DataRow row = table.NewRow();
                for (int j = (int)bodyrow.FirstCellNum; j < lastCellNum; j++)
                {
                    row[j] = bodyrow.GetCell(j);
                }
                table.Rows.Add(row);
            }
            stream.Close();
            return table;
        }

        /// <summary>
        /// EXCEL（2007版）
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private static DataTable XlsxToDataTable(Stream stream)
        {
            DataTable table = new DataTable();
            XSSFWorkbook workbook = new XSSFWorkbook(stream);
            XSSFSheet sheet = (XSSFSheet)workbook.GetSheetAt(workbook.ActiveSheetIndex);
            XSSFRow headrow = (XSSFRow)sheet.GetRow(0);
            int lastCellNum = (int)headrow.LastCellNum;
            for (int i = (int)headrow.FirstCellNum; i < lastCellNum; i++)
            {
                DataColumn column = new DataColumn(headrow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }
            int lastRowNum = sheet.LastRowNum;
            for (int i = sheet.FirstRowNum + 1; i < sheet.LastRowNum; i++)
            {
                XSSFRow bodyrow = (XSSFRow)sheet.GetRow(i);
                DataRow row = table.NewRow();
                for (int j = (int)bodyrow.FirstCellNum; j < lastCellNum; j++)
                {
                    row[j] = bodyrow.GetCell(j);
                }
                table.Rows.Add(row);
            }
            stream.Close();
            return table;
        }
    }
}
