
// Ignore Spelling: Visjs

using System.Collections.Generic;
using System.Data;
using System.Linq;
using VisjsNetworkLibrary.Exceptions;
using VisjsNetworkLibrary.Interfaces;
using VisjsNetworkLibrary.NetworkDataClasses;

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
            else if (_columnCount == 3 && _columnNames.Contains("from") && _columnNames.Contains("to") && _columnNames.Contains("count"))
            {
                return new NetworkDataWithCount(_dataTable);
            }
            else if (_columnCount == 3 && _columnNames.Contains("from") && _columnNames.Contains("to") && _columnNames.Contains("linkisconfirmed"))
            {
                return new NetworkDataLinkIsConfirmed(_dataTable);
            }
            else if (_columnCount == 4 && _columnNames.Contains("from") && _columnNames.Contains("to") && _columnNames.Contains("count") && _columnNames.Contains("linkisconfirmed"))
            {
                return new NetworkDataWithCountAndLinkIsConfirmed(_dataTable);
            }
            else if (_columnCount == 4 && _columnNames.Contains("from") && _columnNames.Contains("fromicon") && _columnNames.Contains("to") && _columnNames.Contains("toicon"))
            {
                return new NetworkDataWithNodesIcons(_dataTable);
            }
            else if (_columnCount == 5 && _columnNames.Contains("from") && _columnNames.Contains("fromicon") && _columnNames.Contains("to") && _columnNames.Contains("toicon") && _columnNames.Contains("linkisconfirmed"))
            {
                return new NetworkDataWithNodesIconsAndLinkIsConfirmed(_dataTable);
            }
            else if (_columnCount == 5 && _columnNames.Contains("from") && _columnNames.Contains("fromicon") && _columnNames.Contains("to") && _columnNames.Contains("toicon") && _columnNames.Contains("count"))
            {
                return new NetworkDataWithNodesIconsAndCount(_dataTable);
            }
            else if (_columnCount == 6 && _columnNames.Contains("from") && _columnNames.Contains("fromicon") && _columnNames.Contains("to") && _columnNames.Contains("toicon") && _columnNames.Contains("count") && _columnNames.Contains("linkisconfirmed"))
            {
                return new NetworkDataWithNodesIconsAndLinkIsConfirmedAndCount(_dataTable);
            }
            else if (_columnCount == 6 && _columnNames.Contains("from") && _columnNames.Contains("fromicon") && _columnNames.Contains("to") && _columnNames.Contains("toicon") && _columnNames.Contains("fromcolor") && _columnNames.Contains("tocolor"))
            {
                return new NetworkDataWithNodesIconsInColor(_dataTable);
            }
            else if (_columnCount == 4 && _columnNames.Contains("from") && _columnNames.Contains("fromvalue") && _columnNames.Contains("to") && _columnNames.Contains("tovalue"))
            {
                return new NetworkDataScalingNodesAndEdges(_dataTable);
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
