
using GraphAlgorithmsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisJsNetworkLibrary.Models;
using VisJsNetworkLibrary.Validations;

namespace VisJsNetworkLibrary
{
    public class NetworkAnalytics
    {
        private List<Node> _nodes;
        private List<Edge> _edges;
        private GraphBase _graph;

        public NetworkAnalytics(NetworkData networkData, GraphBase graph)
        {
            _nodes = networkData.GetNodes();
            _edges = networkData.GetEdges();
            _graph = graph;
        }

        public Task<List<List<int>>> FindAllPaths(string sourceNodeName, string destinationNodeName)
        {
            AddEdgesToGraph();

            return _graph.DFS_FindAllPathsAsync(GetNodeId(sourceNodeName), GetNodeId(destinationNodeName));
        }

        private void AddEdgesToGraph()
        {
            for (int i = 0; i < _edges.Count; i++)
            {
                _graph.AddEdge(_edges.Select(x => x.From).ToList()[i],
                               _edges.Select(x => x.To).ToList()[i]);
            }
        }

        private int GetNodeId(string nodeLabel)
        {
            int nodeId = _nodes
                .Where(x => x.Label.Equals(nodeLabel, StringComparison.OrdinalIgnoreCase))
                .Select(x => x.Id)
                .FirstOrDefault();

            VisJsDataValidator.ValidateNodeIdIsFound(nodeId, nodeLabel);

            return nodeId;
        }
    }
}
