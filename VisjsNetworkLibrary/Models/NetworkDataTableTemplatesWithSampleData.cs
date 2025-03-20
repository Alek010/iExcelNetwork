// Ignore Spelling: Visjs

using System.Data;
using VisjsNetworkLibrary.Interfaces;
using VisjsNetworkLibrary.Models;

namespace VisjsNetworkLibrary.Models
{
    public class NetworkDataTableTemplatesWithSampleData : INetworkDataTableTemplates
    {
        NetworkDataTableTemplates _tableTemplate;

        public NetworkDataTableTemplatesWithSampleData(NetworkDataTableTemplates networkDataTableTemplates)
        {
            _tableTemplate = networkDataTableTemplates;
        }

        public DataTable CreateNetworkDataLinkIsConfirmedTable(bool normalizeColumnNames = false)
        {
            var dt = _tableTemplate.CreateNetworkDataLinkIsConfirmedTable(normalizeColumnNames);

            dt.Rows.Add("A", "B", "FALSE");
            dt.Rows.Add("A", "B", "FALSE");
            dt.Rows.Add("C", "B", "TRUE");

            return dt;
        }

        public DataTable CreateNetworkDataTable(bool normalizeColumnNames = false)
        {
            var dt = _tableTemplate.CreateNetworkDataTable(normalizeColumnNames);

            dt.Rows.Add("A", "B" );
            dt.Rows.Add("A", "B" );
            dt.Rows.Add("C", "B" );

            return dt;
        }

        public DataTable CreateNetworkDataWithCountTable(bool normalizeColumnNames = false)
        {
            var dt = _tableTemplate.CreateNetworkDataWithCountTable(normalizeColumnNames);

            dt.Rows.Add("A", "B", "2");
            dt.Rows.Add("A", "B", "1");
            dt.Rows.Add("C", "B", "10");

            return dt;
        }

        public DataTable CreateNetworkDataWithCountAndLinkIsConfirmedTable(bool normalizeColumnNames = false)
        {
            var dt = _tableTemplate.CreateNetworkDataWithCountAndLinkIsConfirmedTable(normalizeColumnNames);

            dt.Rows.Add("A", "B", "2", "TRUE");
            dt.Rows.Add("A", "B", "1", "TRUE");
            dt.Rows.Add("C", "B", "10","FALSE");

            return dt;
        }

        public DataTable CreateNetworkDataWithNodesIconsInColorTable(bool normalizeColumnNames = false)
        {
            var dt = _tableTemplate.CreateNetworkDataWithNodesIconsInColorTable(normalizeColumnNames);

            dt.Rows.Add("+37128989924", "Cellphone", "Green", "B", "Person", "Red");
            dt.Rows.Add("XX123456", "ID-card", "Blue", "B", "Person", "Red");
            dt.Rows.Add("B", "Person", "Red", "C", "Group", "Black");

            return dt;
        }

        public DataTable CreateNetworkDataWithNodesIconsTable(bool normalizeColumnNames = false)
        {
            var dt = _tableTemplate.CreateNetworkDataWithNodesIconsTable(normalizeColumnNames);

            dt.Rows.Add("+37128989924", "Cellphone", "B", "Person");
            dt.Rows.Add("XX123456", "ID-card", "B", "Person");
            dt.Rows.Add("B", "Person", "C", "Group");

            return dt;
        }

        public DataTable CreateNetworkDataScalingNodesAndEdges(bool normalizeColumnNames = false)
        {
            var dt = _tableTemplate.CreateNetworkDataScalingNodesAndEdges(normalizeColumnNames);

            dt.Rows.Add("A", "2", "B", "8");
            dt.Rows.Add("A", "2", "B", "8");
            dt.Rows.Add("C", "1", "D", "5");

            return dt;
        }
    }
}
