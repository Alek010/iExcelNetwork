using System.Data;

namespace ExcelAddIn
{
    public class Dimensions
    {
        public int rowCount;
        public int columnCount;
        public object[,] data;
    }

    public class DataTableDimensions
    {
        private readonly DataTable _dt;
        private readonly Dimensions Dimensions = new Dimensions();

        public DataTableDimensions(DataTable dt)
        {
            _dt = dt;
        }

        public Dimensions GetDataTableDimensions()
        {
            Dimensions.rowCount = _dt.Rows.Count;
            Dimensions.columnCount = _dt.Columns.Count;

            // Determine dimensions for the array (include header row).
            Dimensions.data = new object[Dimensions.rowCount + 1, Dimensions.columnCount];

            // Add DataTable column headers to the first row.
            for (int col = 0; col < Dimensions.columnCount; col++)
            {
                Dimensions.data[0, col] = _dt.Columns[col].ColumnName;
            }

            // Add DataTable rows.
            for (int row = 0; row < Dimensions.rowCount; row++)
            {
                for (int col = 0; col < Dimensions.columnCount; col++)
                {
                    Dimensions.data[row + 1, col] = _dt.Rows[row][col];
                }
            }

            return Dimensions;
        }
    }
}
