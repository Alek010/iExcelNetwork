// Ignore Spelling: Visjs

using System.Collections.Generic;
using System.Data;
using System.Linq;
using VisjsNetworkLibrary.Interfaces;
using VisjsNetworkLibrary.Models;

namespace VisjsNetworkLibrary
{
    public class NetworkDataWithCount : NetworkData, INetworkData
    {
        public NetworkDataWithCount(DataTable dataTable) : base(dataTable)
        {
        }

        public override List<Edge> GetEdges()
        {
            var nodeDict = GetNodes().ToDictionary(n => n.Label, n => n.Id);

            var edgesList = _dataTable.AsEnumerable()
                .GroupBy(row => new
                {
                    From = row.Field<string>("from"),
                    To = row.Field<string>("to")
                })
                .Select(g => new Edge
                {
                    From = nodeDict[g.Key.From],
                    To = nodeDict[g.Key.To],
                    Count = g.Sum(row => int.Parse(row.Field<string>("count"))).ToString()
                })
                .ToList();

            return edgesList;
        }
    }
}
