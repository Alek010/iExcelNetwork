// Ignore Spelling: Json


using System.Collections.Generic;
using System.Linq;
using VisJsNetworkLibrary.Models;
using VisJsNetworkLibrary.Validations;

namespace VisJsNetworkLibrary
{
    public class NetworkData
    {
        private readonly List<string> _fromColumnValues;
        private readonly List<string> _toColumnValues;
        private readonly List<string> _linksCount;

        private readonly List<Node> NodesList = new List<Node>();
        private readonly List<Edge> EdgesList = new List<Edge>();

        public NetworkData(DataRange dataRange)
        {
            _fromColumnValues = dataRange.GetFromColumnValues();
            _toColumnValues = dataRange.GetToColumnValues();
            _linksCount = dataRange.GetLinksCount();
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
            var fromEdgeId = GetEdgesIds(_fromColumnValues, NodesList);

            var toEdgeId = GetEdgesIds(_toColumnValues, NodesList);

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

            nodesLabels.AddRange(_fromColumnValues);
            nodesLabels.AddRange(_toColumnValues);

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
