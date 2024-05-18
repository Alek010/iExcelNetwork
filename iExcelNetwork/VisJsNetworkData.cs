// Ignore Spelling: Json

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iExcelNetwork
{
    public class VisJsNetworkData
    {


        private string _jsonFromToRange;
        private List<string> FromNodesLabels;
        private List<string> ToNodesLabels;

        private List<Node> NodesList = new List<Node>();
        private List<Edge> EdgesList = new List<Edge>();


        public VisJsNetworkData(string jsonFromToRange)
        {
            _jsonFromToRange = jsonFromToRange;
        }

        public void ProcessJson()
        {
            if (_jsonFromToRange == null)
            {
                throw new Exception("Range is not selected!");
            }

            if(!VisJsDataFieldsValidator.ValidateFieldNames(_jsonFromToRange))
            {
                throw new Exception($@"Column names are not correct. Change ColumnName1 = 'from', ColumnName2 = 'to'. Select Range again!");
            }

            List<RangeData> FromToRange = JsonConvert.DeserializeObject<List<RangeData>>(_jsonFromToRange);

            FromNodesLabels = FromToRange.Select(range => range.From).ToList();
            ToNodesLabels = FromToRange.Select(range => range.To).ToList();

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
            var fromEdgeId = GetEdgesIds(FromNodesLabels, NodesList);

            var toEdgeId = GetEdgesIds(ToNodesLabels, NodesList);

            int count;

            if (fromEdgeId.Count != toEdgeId.Count)
            {
                throw new Exception("From and To Edges count is not equal.");
            }
            else
            {
                count = fromEdgeId.Count;
            }

            for (int i = 0; i < count; i++)
            {
                Edge edge = new Edge()
                {
                    From = fromEdgeId[i],
                    To = toEdgeId[i]
                };

                EdgesList.Add(edge);
            }

            return EdgesList;
        }

        private List<string> GetNodesLabels()
        {
            List<string> nodesLabels = new List<string>();

            nodesLabels.AddRange(FromNodesLabels);
            nodesLabels.AddRange(ToNodesLabels);

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
