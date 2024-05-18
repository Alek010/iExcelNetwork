// Ignore Spelling: Json

using System.Diagnostics;
using System.IO;

namespace iExcelNetwork
{
    public class VisJsNetworkBuilder
    {
        private string _nodesJson { get; set; }
        private string _edgesJson { get; set; }

        private string HtmlContent { get; set; }
        private string TempFilePath { get; set; }

        public VisJsNetworkBuilder(string nodesJson, string edgesJson)
        {
            _nodesJson = nodesJson;
            _edgesJson = edgesJson;
        }

        public void ShowNetwork()
        {
            CreateHtmlContent();
            CreateTempFilePath();
            WriteHtmlContentToFile();
            OpenHtmlFile();
        }

        private void CreateHtmlContent()
        {
            // Prepare the HTML content with Vis.js network graph
            HtmlContent = $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <title>Vis.js Network</title>
                    <script src='https://unpkg.com/vis-network/standalone/umd/vis-network.min.js'></script>
                    <style type='text/css'>
                        html, body {{height: 100%;
                            margin: 0;
                            overflow: hidden; /* Prevent scrollbars */
                        }}
                        #networkContainer {{
                            width: 100%;
                            height: 100%;
                            border: 1px solid lightgray;
                        }}
                    </style>
                </head>
                <body>
                    <div id='networkContainer'></div>
                    <script type='text/javascript'>
                        // Define nodes and edges variables
                        var nodes = {_nodesJson};
                        var edges = {_edgesJson};

                        // Create Vis.js network graph
                        var container = document.getElementById('networkContainer');
                        var data = {{ nodes: nodes, edges: edges }};
                        var options = {{}};
                        var network = new vis.Network(container, data, options);
                    </script>
                </body>
                </html>";
        }

        private void CreateTempFilePath()
        {
            TempFilePath = Path.Combine(Path.GetTempPath(), "visjs_network.html");
        }

        private void WriteHtmlContentToFile()
        {
            File.WriteAllText(TempFilePath, HtmlContent);
        }

        private void OpenHtmlFile()
        {
            // Open the temporary HTML file in the default web browser
            Process.Start(TempFilePath);
        }




    }
}
