using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;

namespace iExcelNetwork.SheetDataWriter
{
    public class DataWriter
    {
        public void PopulateData(List<string[]> data, Excel.Range startCell)
        {
            int startRow = startCell.Row;
            int startColumn = startCell.Column;

            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    startCell.Worksheet.Cells[startRow + i, startColumn + j].Value2 = data[i][j];
                }
            }
        }
    }
}
