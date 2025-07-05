
// Ignore Spelling: Visjs

using System.Collections.Generic;
using System.Data;
using VisjsNetworkLibrary.Interfaces;
using VisjsNetworkLibrary.Models;
using VisjsNetworkLibrary.NetworkDataClasses;

namespace VisjsNetworkLibrary.FinancialNetworkData
{
    public class FinancialNetworkDataWithCount : NetworkData, INetworkData
    {
        public FinancialNetworkDataWithCount(DataTable dataTable) : base(dataTable)
        {
            base.EdgesLinksHasTitle = true;
            base.NodesEdgesAreScalable = true;
        }

        public override List<Edge> GetEdges()
        {
            return FinancialNetworkEdgesList.GetList(_dataTable, GetNodes());
        }
    }
}
