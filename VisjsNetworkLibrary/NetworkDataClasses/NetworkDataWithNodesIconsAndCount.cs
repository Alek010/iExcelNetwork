// Ignore Spelling: Visjs

using System.Data;
using VisjsNetworkLibrary.Interfaces;

namespace VisjsNetworkLibrary.NetworkDataClasses
{
    public class NetworkDataWithNodesIconsAndCount : NetworkData, INetworkData
    {
        public NetworkDataWithNodesIconsAndCount(DataTable dataTable) : base(dataTable)
        {
        }
    }
}
