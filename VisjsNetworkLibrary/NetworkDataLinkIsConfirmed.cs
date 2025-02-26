// Ignore Spelling: Visjs

using System.Collections.Generic;
using System.Data;
using System.Linq;
using VisjsNetworkLibrary.Interfaces;
using VisjsNetworkLibrary.Models;

namespace VisjsNetworkLibrary
{
    public class NetworkDataLinkIsConfirmed : NetworkData, INetworkData
    {
        public NetworkDataLinkIsConfirmed(DataTable dataTable) : base(dataTable)
        {
        }

        public override List<Edge> GetEdges()
        {
            var nodeDict = GetNodes().ToDictionary(n => n.Label, n => n.Id);

            var edgesList = _dataTable.AsEnumerable()
                .Select(row => new Edge
                {
                    From = nodeDict[row.Field<string>("from")],
                    To = nodeDict[row.Field<string>("to")],
                    // !bool as edge JSON field is dashes with value true or false.
                    // If link is confirmed than dashes are false and link is unconfirmed when dashes are true.
                    LinkIsConfirmed = !bool.Parse(row.Field<string>("linkisconfirmed")) 
                })
                .ToList();

            return edgesList;
        }
    }
}
