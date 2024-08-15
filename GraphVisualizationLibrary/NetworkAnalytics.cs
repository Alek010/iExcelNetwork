
using GraphAlgorithmsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphVisualizationLibrary.Models;
using GraphVisualizationLibrary.Validations;

namespace GraphVisualizationLibrary
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

            AddEdgesToGraph();
        }

        public Task<List<List<int>>> FindAllPathsAsync(string sourceNodeName, string destinationNodeName)
        {
            return _graph.DFS_FindAllPathsAsync(GetNodeId(sourceNodeName), GetNodeId(destinationNodeName));
        }

        public int CountCircularEdges()
        {
            return _graph.CountCircularEdges();
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
