// Ignore Spelling: Visjs

using System.Data;
using VisjsNetworkLibrary.Interfaces;

namespace VisjsNetworkLibrary.NetworkDataClasses
{
    public class NetworkDataWithNodesIconsAndLinkIsConfirmedAndCount : NetworkData, INetworkData
    {
        public NetworkDataWithNodesIconsAndLinkIsConfirmedAndCount(DataTable dataTable) : base(dataTable)
        {
        }
    }
}
