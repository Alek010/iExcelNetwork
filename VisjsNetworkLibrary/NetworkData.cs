// Ignore Spelling: Visjs

using System.Collections.Generic;
using System.Data;
using System.Linq;
using VisjsNetworkLibrary.Models;

namespace VisjsNetworkLibrary
{
    public class NetworkData
    {
        private DataTable _dataTable;

        public NetworkData(DataTable dataTable)
        {
            _dataTable = dataTable;
        }

        public List<Node> GetNodes()
        {
            List<Node> NodesList = new List<Node>();

            var nodesLabels = GetNodesLabels();

            for (int i = 0; i < nodesLabels.Count; i++)
            {
                Node item = new Node()
                {
                    Id = i + 1,
                    Label = nodesLabels[i]
                };

                NodesList.Add(item);
            }

            return NodesList;
        }

        public List<Edge> GetEdges()
        {
            var EdgesList = new List<Edge>();
            List<Node> nodes = GetNodes();

            EdgesList = _dataTable.AsEnumerable()
            .GroupBy(row => new
            {
                From = row.Field<string>("from"),
                To = row.Field<string>("to")
            })
            .Select(g => new Edge
            {
                From = nodes.Where(x => x.Label == g.Key.From).Select(x => x.Id).First(),
                To = nodes.Where(x => x.Label == g.Key.To).Select(x => x.Id).First(),
                Count = g.Count().ToString()
            })
            .ToList();

            return EdgesList;
        }

        private List<string> GetNodesLabels()
        {
            List<string> nodesLabels = new List<string>();

            nodesLabels.AddRange(_dataTable.AsEnumerable().Select(x => x.Field<string>("from")));
            nodesLabels.AddRange(_dataTable.AsEnumerable().Select(x => x.Field<string>("to")));

            List<string> uniqueNodesLabels = nodesLabels.Distinct().ToList();

            return uniqueNodesLabels;
        }
    }
}
