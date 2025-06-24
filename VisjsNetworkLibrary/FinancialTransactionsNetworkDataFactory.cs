// Ignore Spelling: Visjs

using System.Data;
using VisjsNetworkLibrary.Exceptions;
using VisjsNetworkLibrary.FinancialTransactionsNetworkData;
using VisjsNetworkLibrary.Interfaces;

namespace VisjsNetworkLibrary
{
    public class FinancialTransactionsNetworkDataFactory : NetworkDataFactory
    {
        public FinancialTransactionsNetworkDataFactory(DataTable dataTable) : base(dataTable)
        {
        }

        public override INetworkData CreateNetworkData()
        {
            if (_columnCount == 3 && _columnNames.Contains("from") && _columnNames.Contains("to") && _columnNames.Contains("count"))
            {
                return new FinancialNetworkDataWithCount(_dataTable);
            }
            else if (_columnCount == 5 && _columnNames.Contains("from") && _columnNames.Contains("fromicon") && _columnNames.Contains("to") && _columnNames.Contains("toicon") && _columnNames.Contains("count"))
            {
                return new FinancialNetworkDataWithNodesIconsAndCount(_dataTable);
            }
            else
            {
                throw new DataTableStructureException(SelectedDataTableExceptionMessages.NotMatchPattern());
            }
        }
    }
}
