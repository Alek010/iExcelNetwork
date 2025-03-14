// Ignore Spelling: Visjs

using System.Data;

namespace VisjsNetworkLibrary.NetworkDataClasses
{
    public class NetworkDataTableTemplates
    {

        public DataTable CreateNetworkDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));

            return dt;
        }

        public DataTable CreateNetworkDataWithCountTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));
            dt.Columns.Add("count", typeof(string));

            return dt;
        }

        public DataTable CreateNetworkDataLinkIsConfirmedTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));
            dt.Columns.Add("linkisconfirmed", typeof(string));

            return dt;
        }

        public DataTable CreateNetworkDataWithNodesIconsTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));
            dt.Columns.Add("fromicon", typeof(string));
            dt.Columns.Add("toicon", typeof(string));

            return dt;
        }

        public DataTable CreateNetworkDataWithNodesIconsInColorTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));
            dt.Columns.Add("fromicon", typeof(string));
            dt.Columns.Add("toicon", typeof(string));
            dt.Columns.Add("fromcolor", typeof(string));
            dt.Columns.Add("tocolor", typeof(string));

            return dt;
        }

        public DataTable NetworkDataScalingNodesAndEdges()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("to", typeof(string));
            dt.Columns.Add("fromicon", typeof(string));
            dt.Columns.Add("toicon", typeof(string));
            dt.Columns.Add("fromcolor", typeof(string));
            dt.Columns.Add("tocolor", typeof(string));

            return dt;
        }


    }
}
