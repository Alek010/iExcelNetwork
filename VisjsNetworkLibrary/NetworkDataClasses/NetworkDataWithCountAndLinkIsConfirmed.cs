// Ignore Spelling: Visjs

using System.Data;
using VisjsNetworkLibrary.Interfaces;

namespace VisjsNetworkLibrary.NetworkDataClasses
{
    public class NetworkDataWithCountAndLinkIsConfirmed : NetworkData, INetworkData
    {
        public NetworkDataWithCountAndLinkIsConfirmed(DataTable dataTable) : base(dataTable)
        {
        }
    }
}
