// Ignore Spelling: Visjs

using System.Data;
using VisjsNetworkLibrary.Interfaces;

namespace VisjsNetworkLibrary.Models
{
    public class NetworkDataTableTemplates : INetworkDataTableTemplates
    {

        public DataTable CreateNetworkDataTable(bool normalizeColumnNames = false)
        {
            string colFrom = normalizeColumnNames ? "From" : "from";
            string colTo = normalizeColumnNames ? "To" : "to";

            DataTable dt = new DataTable();
            dt.Columns.Add(colFrom, typeof(string));
            dt.Columns.Add(colTo, typeof(string));

            return dt;
        }

        public DataTable CreateNetworkDataWithCountTable(bool normalizeColumnNames = false)
        {
            string colFrom = normalizeColumnNames ? "From" : "from";
            string colTo = normalizeColumnNames ? "To" : "to";
            string colCount = normalizeColumnNames ? "Count" : "count";

            DataTable dt = new DataTable();
            dt.Columns.Add(colFrom, typeof(string));
            dt.Columns.Add(colTo, typeof(string));
            dt.Columns.Add(colCount, typeof(string));

            return dt;
        }

        public DataTable CreateNetworkDataLinkIsConfirmedTable(bool normalizeColumnNames = false)
        {
            string colFrom = normalizeColumnNames ? "From" : "from";
            string colTo = normalizeColumnNames ? "To" : "to";
            string colLinkConfirmed = normalizeColumnNames ? "Link Is Confirmed" : "linkisconfirmed";

            DataTable dt = new DataTable();
            dt.Columns.Add(colFrom, typeof(string));
            dt.Columns.Add(colTo, typeof(string));
            dt.Columns.Add(colLinkConfirmed, typeof(string));

            return dt;
        }

        public DataTable CreateNetworkDataWithCountAndLinkIsConfirmedTable(bool normalizeColumnNames = false)
        {
            string colFrom = normalizeColumnNames ? "From" : "from";
            string colTo = normalizeColumnNames ? "To" : "to";
            string colCount = normalizeColumnNames ? "Count" : "count";
            string colLinkConfirmed = normalizeColumnNames ? "Link Is Confirmed" : "linkisconfirmed";

            DataTable dt = new DataTable();
            dt.Columns.Add(colFrom, typeof(string));
            dt.Columns.Add(colTo, typeof(string));
            dt.Columns.Add(colCount, typeof(string));
            dt.Columns.Add(colLinkConfirmed, typeof(string));

            return dt;
        }

        public DataTable CreateNetworkDataWithNodesIconsTable(bool normalizeColumnNames = false)
        {
            string colFrom = normalizeColumnNames ? "From" : "from";
            string colTo = normalizeColumnNames ? "To" : "to";
            string colFromIcon = normalizeColumnNames ? "From Icon" : "fromicon";
            string colToIcon = normalizeColumnNames ? "To Icon" : "toicon";

            DataTable dt = new DataTable();
            dt.Columns.Add(colFrom, typeof(string));
            dt.Columns.Add(colFromIcon, typeof(string));
            dt.Columns.Add(colTo, typeof(string));
            dt.Columns.Add(colToIcon, typeof(string));

            return dt;
        }

        public DataTable CreateNetworkDataWithNodesIconsAndLinkIsConfirmedTable(bool normalizeColumnNames = false)
        {
            string colFrom = normalizeColumnNames ? "From" : "from";
            string colTo = normalizeColumnNames ? "To" : "to";
            string colFromIcon = normalizeColumnNames ? "From Icon" : "fromicon";
            string colToIcon = normalizeColumnNames ? "To Icon" : "toicon";
            string colLinkConfirmed = normalizeColumnNames ? "Link Is Confirmed" : "linkisconfirmed";

            DataTable dt = new DataTable();
            dt.Columns.Add(colFrom, typeof(string));
            dt.Columns.Add(colFromIcon, typeof(string));
            dt.Columns.Add(colTo, typeof(string));
            dt.Columns.Add(colToIcon, typeof(string));
            dt.Columns.Add(colLinkConfirmed, typeof(string));

            return dt;
        }

        public DataTable CreateNetworkDataWithNodesIconsAndCountTable(bool normalizeColumnNames = false)
        {
            string colFrom = normalizeColumnNames ? "From" : "from";
            string colTo = normalizeColumnNames ? "To" : "to";
            string colFromIcon = normalizeColumnNames ? "From Icon" : "fromicon";
            string colToIcon = normalizeColumnNames ? "To Icon" : "toicon";
            string colCount = normalizeColumnNames ? "Count" : "count";

            DataTable dt = new DataTable();
            dt.Columns.Add(colFrom, typeof(string));
            dt.Columns.Add(colFromIcon, typeof(string));
            dt.Columns.Add(colTo, typeof(string));
            dt.Columns.Add(colToIcon, typeof(string));
            dt.Columns.Add(colCount, typeof(string));

            return dt;
        }

        public DataTable CreateNetworkDataWithNodesIconsInColorTable(bool normalizeColumnNames = false)
        {
            string colFrom = normalizeColumnNames ? "From" : "from";
            string colTo = normalizeColumnNames ? "To" : "to";
            string colFromIcon = normalizeColumnNames ? "From Icon" : "fromicon";
            string colToIcon = normalizeColumnNames ? "To Icon" : "toicon";
            string colFromColor = normalizeColumnNames ? "From Color" : "fromcolor";
            string colToColor = normalizeColumnNames ? "To Color" : "tocolor";

            DataTable dt = new DataTable();
            dt.Columns.Add(colFrom, typeof(string));
            dt.Columns.Add(colFromIcon, typeof(string));
            dt.Columns.Add(colFromColor, typeof(string));
            dt.Columns.Add(colTo, typeof(string));
            dt.Columns.Add(colToIcon, typeof(string));
            dt.Columns.Add(colToColor, typeof(string));

            return dt;
        }

        public DataTable CreateNetworkDataScalingNodesAndEdges(bool normalizeColumnNames = false)
        {
            string colFrom = normalizeColumnNames ? "From" : "from";
            string colTo = normalizeColumnNames ? "To" : "to";
            string colFromValue = normalizeColumnNames ? "From Value" : "fromvalue";
            string colToValue = normalizeColumnNames ? "To Value" : "tovalue";

            DataTable dt = new DataTable();
            dt.Columns.Add(colFrom, typeof(string));
            dt.Columns.Add(colFromValue, typeof(string));
            dt.Columns.Add(colTo, typeof(string));
            dt.Columns.Add(colToValue, typeof(string));

            return dt;
        }
    }
}
