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

        #region SampleData NetworkData

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

            dt.Rows.Add("A", "B");
            dt.Rows.Add("A", "B");
            dt.Rows.Add("C", "B");

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
            dt.Rows.Add("C", "B", "10", "FALSE");

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

        public DataTable CreateNetworkDataWithNodesIconsInColorAndLinkIsConfirmedTable(bool normalizeColumnNames = false)
        {
            var dt = _tableTemplate.CreateNetworkDataWithNodesIconsInColorAndLinkIsConfirmedTable(normalizeColumnNames);

            dt.Rows.Add("+37128989924", "Cellphone", "Green", "B", "Person", "Red", "TRUE");
            dt.Rows.Add("XX123456", "ID-card", "Blue", "B", "Person", "Red", "TRUE");
            dt.Rows.Add("B", "Person", "Red", "C", "Group", "Black", "FALSE");

            return dt;
        }

        public DataTable CreateNetworkDataWithNodesIconsInColorAndCountTable(bool normalizeColumnNames = false)
        {
            var dt = _tableTemplate.CreateNetworkDataWithNodesIconsInColorAndCountTable(normalizeColumnNames);

            dt.Rows.Add("+37128989924", "Cellphone", "Green", "B", "Person", "Red", "1");
            dt.Rows.Add("XX123456", "ID-card", "Blue", "B", "Person", "Red", "1");
            dt.Rows.Add("B", "Person", "Red", "C", "Group", "Black", "10");

            return dt;
        }

        public DataTable CreateNetworkDataWithNodesIconsInColorAndCountAndLinkIsConfirmedTable(bool normalizeColumnNames = false)
        {
            var dt = _tableTemplate.CreateNetworkDataWithNodesIconsInColorAndCountAndLinkIsConfirmedTable(normalizeColumnNames);

            dt.Rows.Add("+37128989924", "Cellphone", "Green", "B", "Person", "Red", "1", "True");
            dt.Rows.Add("XX123456", "ID-card", "Blue", "B", "Person", "Red", "1", "TRUE");
            dt.Rows.Add("B", "Person", "Red", "C", "Group", "Black", "10", "False");

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

        public DataTable CreateNetworkDataWithNodesIconsAndLinkIsConfirmedTable(bool normalizeColumnNames = false)
        {
            var dt = _tableTemplate.CreateNetworkDataWithNodesIconsAndLinkIsConfirmedTable(normalizeColumnNames);

            dt.Rows.Add("+37128989924", "Cellphone", "B", "Person", "True");
            dt.Rows.Add("XX123456", "ID-card", "B", "Person", "TRUE");
            dt.Rows.Add("B", "Person", "C", "Group", "False");

            return dt;
        }

        public DataTable CreateNetworkDataWithNodesIconsAndCountTable(bool normalizeColumnNames = false)
        {
            var dt = _tableTemplate.CreateNetworkDataWithNodesIconsAndCountTable(normalizeColumnNames);

            dt.Rows.Add("A", "phone", "B", "person", "2");
            dt.Rows.Add("A", "phone", "B", "person", "1");
            dt.Rows.Add("C", "gun", "B", "person", "10");

            return dt;
        }

        public DataTable CreateNetworkDataWithNodesIconsAndLinkIsConfirmedAndCountTable(bool normalizeColumnNames = false)
        {
            var dt = _tableTemplate.CreateNetworkDataWithNodesIconsAndLinkIsConfirmedAndCountTable(normalizeColumnNames);

            dt.Rows.Add("A", "phone", "B", "person", "2", "TRUE");
            dt.Rows.Add("A", "phone", "B", "person", "1", "TRUE");
            dt.Rows.Add("C", "gun", "B", "person", "10", "FALSE");

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
        #endregion

        #region SampleData FinancialNetwork

        public DataTable CreateFinancialNetworkDataWithCountTable(bool normalizeColumnNames = false)
        {
            var dt = _tableTemplate.CreateNetworkDataWithCountTable(normalizeColumnNames);

            dt.Rows.Add("A", "B", "2.5");
            dt.Rows.Add("A", "B", "1");
            dt.Rows.Add("B", "D", "7");
            dt.Rows.Add("C", "B", "10.5");
            dt.Rows.Add("B", "A", "5");
            dt.Rows.Add("B", "D", "1");
            dt.Rows.Add("D", "F", "3");
            dt.Rows.Add("F", "A", "7.5");
            dt.Rows.Add("F", "X", "6.3");

            return dt;
        }

        public DataTable CreateFinancialNetworkDataWithNodesIconsAndCountTable(bool normalizeColumnNames = false)
        {
            var dt = _tableTemplate.CreateNetworkDataWithNodesIconsAndCountTable(normalizeColumnNames);

            dt.Rows.Add("A", "Bank account", "B", "Bank account", "2.5");
            dt.Rows.Add("A", "Bank account", "B", "Bank account", "1");
            dt.Rows.Add("B", "Bank account", "D", "Bank account", "7");
            dt.Rows.Add("C", "Bank account", "B", "Bank account", "10.5");
            dt.Rows.Add("B", "Bank account", "A", "Bank account", "5");
            dt.Rows.Add("B", "Bank account", "D", "Bank account", "1");
            dt.Rows.Add("D", "Bank account", "F", "Bank account", "3");
            dt.Rows.Add("F", "Bank account", "A", "Bank account", "7.5");
            dt.Rows.Add("F", "Bank account", "X", "Bank account", "6.3");

            return dt;
        }

        public DataTable CreateFinancialNetworkDataWithNodesIconsInColorAndCountTable(bool normalizeColumnNames = false)
        {
            var dt = _tableTemplate.CreateNetworkDataWithNodesIconsInColorAndCountTable(normalizeColumnNames);

            dt.Rows.Add("A", "Bank account", "blue", "B", "Bank account", "red", "2.5");
            dt.Rows.Add("A", "Bank account", "blue", "B", "Bank account", "red", "1");
            dt.Rows.Add("B", "Bank account", "red", "D", "Bank account", "", "7");
            dt.Rows.Add("C", "Bank account", "", "B", "Bank account", "red", "10.5");
            dt.Rows.Add("B", "Bank account", "red", "A", "Bank account", "blue", "5");
            dt.Rows.Add("B", "Bank account", "red", "D", "Bank account", "", "1");
            dt.Rows.Add("D", "Bank account", "", "F", "Bank account", "orange", "3");
            dt.Rows.Add("F", "Bank account", "orange", "A", "Bank account", "", "7.5");
            dt.Rows.Add("F", "Bank account", "orange", "X", "Bank account", "", "6.3");

            return dt;
        }

        #endregion
    }
}
