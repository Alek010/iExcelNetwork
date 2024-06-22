// Ignore Spelling: Json

using iExcelNetwork.Validations;
using iExcelNetwork.VisJsNetwork.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iExcelNetwork.VisJsNetwork
{
    public class VisJsNetworkData
    {
        private readonly List<string> _fromNodesLabels;
        private readonly List<string> _toNodesLabels;
        private readonly List<string> _linksCount;

        private readonly List<Node> NodesList = new List<Node>();
        private readonly List<Edge> EdgesList = new List<Edge>();

        public VisJsNetworkData(List<string> fromNodesLabels, List<string> toNodesLabels, List<string> linksCount)
        {
            _fromNodesLabels = fromNodesLabels;
            _toNodesLabels = toNodesLabels;
            _linksCount = linksCount;
        }

        public List<Node> GetNodes()
        {
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
            var fromEdgeId = GetEdgesIds(_fromNodesLabels, NodesList);

            var toEdgeId = GetEdgesIds(_toNodesLabels, NodesList);

            VisJsDataValidator.ValidateFromToEdgesIdsCount(fromEdgeId.Count, toEdgeId.Count);

            int count = _linksCount.Count;

            for (int i = 0; i < count; i++)
            {
                Edge edge = new Edge()
                {
                    From = fromEdgeId[i],
                    To = toEdgeId[i],
                    Count = _linksCount[i]
                };

                EdgesList.Add(edge);
            }

            return EdgesList;
        }

        private List<string> GetNodesLabels()
        {
            List<string> nodesLabels = new List<string>();

            nodesLabels.AddRange(_fromNodesLabels);
            nodesLabels.AddRange(_toNodesLabels);

            List<string> uniqueNodesLabels = nodesLabels.Distinct().ToList();

            return uniqueNodesLabels;
        }

        private List<int> GetEdgesIds(List<string> nodesLabels, List<Node> nodesList)
        {
            return nodesLabels.Join(nodesList,
                                    x => x,
                                    y => y.Label,
                                    (x, y) => new { x, y.Id })
                              .Select(x => x.Id)
                              .ToList();
        }
    }
}
