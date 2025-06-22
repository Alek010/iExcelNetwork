// Ignore Spelling: Visjs

using System.Data;
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
            return base.CreateNetworkData();
        }
    }
}
