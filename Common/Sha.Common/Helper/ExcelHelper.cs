using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
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
        private static DataTable XlsToDataTable2(Stream stream)
        {
            using (HSSFWorkbook workbook = new HSSFWorkbook(stream))
            {
                return ReadDataTableFromSheet(stream, workbook.GetSheetAt(workbook.ActiveSheetIndex));
            }
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
            HSSFRow headerRow = (HSSFRow)sheet.GetRow(0);
            int lastCellNum = (int)headerRow.LastCellNum;
            for (int i = (int)headerRow.FirstCellNum; i < lastCellNum; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }
            int lastRowNum = sheet.LastRowNum;
            for (int i = sheet.FirstRowNum + 1; i < lastRowNum; i++)
            {
                HSSFRow dataRow = (HSSFRow)sheet.GetRow(i);
                DataRow tableRow = table.NewRow();
                for (int j = (int)dataRow.FirstCellNum; j < lastCellNum; j++)
                {
                    tableRow[j] = dataRow.GetCell(j);
                }
                table.Rows.Add(tableRow);
            }
            stream.Close();
            return table;
        }

        /// <summary>
        /// EXCEL（2007版）
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private static DataTable XlsxToDataTable2(Stream stream)
        {
            using (XSSFWorkbook workbook = new XSSFWorkbook(stream))
            {
                return ReadDataTableFromSheet(stream, workbook.GetSheetAt(workbook.ActiveSheetIndex));
            }
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
            XSSFRow headerRow = (XSSFRow)sheet.GetRow(0);
            int lastCellNum = (int)headerRow.LastCellNum;
            for (int i = (int)headerRow.FirstCellNum; i < lastCellNum; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }
            int lastRowNum = sheet.LastRowNum;
            for (int i = sheet.FirstRowNum + 1; i < lastRowNum; i++)
            {
                XSSFRow dataRow = (XSSFRow)sheet.GetRow(i);
                DataRow tableRow = table.NewRow();
                for (int j = (int)dataRow.FirstCellNum; j < lastCellNum; j++)
                {
                    tableRow[j] = dataRow.GetCell(j);
                }
                table.Rows.Add(tableRow);
            }
            stream.Close();
            return table;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="sheet"></param>
        /// <returns></returns>
        private static DataTable ReadDataTableFromSheet(Stream stream, ISheet sheet)
        {
            DataTable table = new DataTable();

            IRow headerRow = sheet.GetRow(0);
            int lastCellNum = headerRow.LastCellNum;

            for (int i = headerRow.FirstCellNum; i < lastCellNum; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }

            int lastRowNum = sheet.LastRowNum;
            for (int i = sheet.FirstRowNum + 1; i < lastRowNum; i++)
            {
                IRow dataRow = sheet.GetRow(i);
                DataRow tableRow = table.NewRow();

                for (int j = dataRow.FirstCellNum; j < lastCellNum; j++)
                {
                    tableRow[j] = dataRow.GetCell(j);
                }

                table.Rows.Add(tableRow);
            }

            return table;
        }
    }
}
