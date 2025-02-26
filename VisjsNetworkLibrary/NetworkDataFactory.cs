
// Ignore Spelling: Visjs

using System.Collections.Generic;
using System.Data;
using System.Linq;
using VisjsNetworkLibrary.Exceptions;
using VisjsNetworkLibrary.Interfaces;

namespace VisjsNetworkLibrary
{
    public class NetworkDataFactory
    {
        private readonly DataTable _dataTable;
        private readonly int _columnCount;
        private readonly List<string> _columnNames;

        public NetworkDataFactory(DataTable dataTable)
        {
            _dataTable = dataTable;
            _columnCount = GetColumnCount(dataTable);
            _columnNames = GetColumnNames(dataTable);
        }

        public INetworkData CreateNetworkData()
        {
            if(_columnCount == 2 && _columnNames.Contains("from") && _columnNames.Contains("to"))
            {
                return new NetworkData(_dataTable);
            }
            else
            {
                throw new DataTableStructureException(SelectedDataTableExceptionMessages.NotMatchPattern());
            }

        }

        private int GetColumnCount(DataTable dataTable)
        {
            return dataTable.Columns.Count;
        }

        private List<string> GetColumnNames(DataTable dataTable)
        {
            return dataTable.Columns.Cast<DataColumn>()
                                    .Select(c => c.ColumnName)
                                    .ToList();
        }        
    }
}
