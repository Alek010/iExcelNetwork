// Ignore Spelling: Visjs

using System.Data;

namespace VisjsNetworkLibrary.Interfaces
{
    public interface INetworkDataTableTemplates
    {
        DataTable CreateNetworkDataLinkIsConfirmedTable(bool normalizeColumnNames = false);
        DataTable CreateNetworkDataTable(bool normalizeColumnNames = false);
        DataTable CreateNetworkDataWithCountTable(bool normalizeColumnNames = false);
        DataTable CreateNetworkDataWithCountAndLinkIsConfirmedTable(bool normalizeColumnNames = false);
        DataTable CreateNetworkDataWithNodesIconsInColorTable(bool normalizeColumnNames = false);
        DataTable CreateNetworkDataWithNodesIconsTable(bool normalizeColumnNames = false);
        DataTable CreateNetworkDataWithNodesIconsAndLinkIsConfirmedTable(bool normalizeColumnNames = false);
        DataTable CreateNetworkDataScalingNodesAndEdges(bool normalizeColumnNames = false);
    }
}