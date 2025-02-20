// Ignore Spelling: Visjs

using VisjsNetworkLibrary.Interfaces;
using System.IO;
using System.Reflection;

namespace VisjsNetworkLibrary
{
    public class NetworkHtmlContent : IFileContent
    {
        private string _nodesJson { get; set; } = "[\r\n      { id: 1, label: 'Node 1' },\r\n      { id: 2, label: 'Node 2' },\r\n      { id: 3, label: 'Node 3' },\r\n      { id: 4, label: 'Node 4' },\r\n      { id: 5, label: 'Node 5' }\r\n    ]";
        private string _edgesJson { get; set; } = "[\r\n      { from: 1, to: 2 },\r\n      { from: 1, to: 3 },\r\n      { from: 2, to: 4 },\r\n      { from: 2, to: 5 }\r\n    ]";

        public NetworkHtmlContent()
        {

        }

        public string GenerateFileContent()
        {
            string VisJsScript = GetEmbeddedResource("VisjsNetworkLibrary.Resources.vis-network.min.js");

            string htmlTemplate = GetEmbeddedResource("VisjsNetworkLibrary.Resources.VisJsNetworkTemplate.html");

            return htmlTemplate
                .Replace("{{VisJsScript}}", VisJsScript)
                .Replace("{{nodesJson}}", _nodesJson)
                .Replace("{{edgesJson}}", _edgesJson)
                .Replace("selectedEdgesDirection", "to");
        }

        public string GetFilePath()
        {
            return Path.Combine(Path.GetTempPath(), "VisjsNetwork") + ".html";
        }

        private string GetEmbeddedResource(string resourceName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
