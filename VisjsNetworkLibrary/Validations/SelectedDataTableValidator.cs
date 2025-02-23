// Ignore Spelling: Visjs Validator


using System.Data;
using VisjsNetworkLibrary.Exceptions;

namespace VisjsNetworkLibrary.Validations
{
    public class SelectedDataTableValidator
    {
        private DataTable _datatable;

        public SelectedDataTableValidator(DataTable dataTable)
        {
            _datatable = dataTable;
        }

        public void ValidateDataTableIsNotNull()
        {
            if(_datatable == null)
            {
                throw new DataTableNullException(SelectedDataTableExceptionMessages.SelectedDataTableIsNull());
            }
        }

        public void ValidateDataTableHasRecords()
        {
            if (_datatable != null && _datatable.Rows.Count == 0)
            {
                throw new DataTableIsEmptyException(SelectedDataTableExceptionMessages.SelectedDataTableHasNoRecords());
            }
        }

        public void ValidateDataTableHasTwoOrMoreColumns()
        {
            if(_datatable != null && _datatable.Columns.Count < 2)
            {
                throw new DataTableColumnsCountException(SelectedDataTableExceptionMessages.SelectedDataTableHasLessThanTwoColumns());
            }
        }
    }
}
