
using GraphAlgorithmsLibrary;
using System.Collections.Generic;
using System.Linq;
using VisJsNetworkLibrary.Models;

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

        public List<List<int>> FindAllPaths(int src, int dst)
        {
            AddEdgesToGraph();

            return _graph.DFS_FindAllPaths(src, dst);
        }

        private void AddEdgesToGraph()
        {
            for (int i = 0; i < _edges.Count; i++)
            {
                _graph.AddEdge(_edges.Select(x => x.From).ToList()[i],
                               _edges.Select(x => x.To).ToList()[i]);
            }
        }




    }
}
