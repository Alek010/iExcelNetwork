// Ignore Spelling: Json

using iExcelNetwork.Exceptions;
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
                throw new SelectedRangeIsNullException(ExceptionMessage.RangeIsNotSelected());
            }

            if(!VisJsDataValidator.HasValidFieldNames(_jsonFromToRange))
            {
                throw new SelectedRangeJsonColumnNamesNotCorrectException(ExceptionMessage.RangeColumnNamesAreNotCorrect());
            }

            if (!VisJsDataValidator.HasRecords(_jsonFromToRange))
            {
                throw new SelectedRangeJsonHasNoRecordsException(ExceptionMessage.RangeHasNoRecords());
            }

            List<RangeData> FromToRange = JsonConvert.DeserializeObject<List<RangeData>>(_jsonFromToRange);

            FromNodesLabels = FromToRange.Select(range => range.From = string.IsNullOrWhiteSpace(range.From) ? "" : range.From)
                                         .ToList();

            ToNodesLabels = FromToRange.Select(range => range.To =string.IsNullOrWhiteSpace(range.To) ? "" : range.To)
                                       .ToList();

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
                throw new FromNodesEdgeNodesCountNotEqualException(ExceptionMessage.FromToNodesCountNotEqual());
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
