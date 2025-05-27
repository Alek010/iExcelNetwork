// Ignore Spelling: Visjs

using VisjsNetworkLibrary.Interfaces;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using System;

namespace VisjsNetworkLibrary
{
    public class NetworkHtmlContent : IFileContent
    {
        private string _nodesJson { get; set; }
        private string _edgesJson { get; set; }
        private bool NetworkDataIsScalable;
        private bool NetworkDataLinksHasTitles;

        public NetworkHtmlContent(INetworkData networkData)
        {
            var settings = new JsonSerializerSettings
            {
                StringEscapeHandling = StringEscapeHandling.EscapeNonAscii
            };

            _nodesJson = JsonConvert.SerializeObject(networkData.GetNodes(), Formatting.Indented, settings);
            _edgesJson = JsonConvert.SerializeObject(networkData.GetEdges(), Formatting.Indented);
            NetworkDataIsScalable = networkData.NodesEdgesAreScalable;
            NetworkDataLinksHasTitles = networkData.EdgesLinksHasTitle;
        }

        public string GenerateFileContent()
        {
            string VisJsScript = GetEmbeddedResource("VisjsNetworkLibrary.Resources.vis-network.min.js");

            string htmlTemplate = GetEmbeddedResource("VisjsNetworkLibrary.Resources.VisJsNetworkTemplate.html");

            string fontAwesomeCss = GetEmbeddedResource("VisjsNetworkLibrary.Resources.FontsAwesome.css.all.css");
            // Process the CSS to replace font URLs with data URIs.
            // (You may need to add a call for each font file used in your CSS.)
            fontAwesomeCss = EmbedFontReferences(fontAwesomeCss);

            string VisJsCss = GetEmbeddedResource("VisjsNetworkLibrary.Resources.vis-network.css");

            var result = htmlTemplate
               .Replace("{{VisJsScript}}", VisJsScript)
               .Replace("{{nodesJson}}", _nodesJson)
               .Replace("{{edgesJson}}", _edgesJson)
               .Replace("{{FontAwesomeCss}}", fontAwesomeCss)
               .Replace("{{VisJsCss}}", VisJsCss);

            if (NetworkDataIsScalable)
            {
                result = result.Replace("scaling: { min: 1, max: 1 },", "");
            }

            if (NetworkDataLinksHasTitles)
            {
                result = result.Replace(".vis-tooltip { display: none !important; }", "");
            }

            return result;
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

        /// <summary>
        /// Scans the CSS content for font URLs and replaces them with Base64 data URIs.
        /// </summary>
        private string EmbedFontReferences(string cssContent)
        {
            // Example: Replace a reference to '../webfonts/fa-solid-900.woff2'
            // with its Base64 data URI.
            cssContent = ReplaceFontReference(
                cssContent,
                "../webfonts/fa-solid-900.woff2",
                "VisjsNetworkLibrary.Resources.FontsAwesome.webfonts.fa-solid-900.woff2",
                "font/woff2");

            // Add additional calls here for any other fonts referenced in your CSS.
            // For example:
            cssContent = ReplaceFontReference(
                cssContent,
                "../webfonts/fa-regular-400.woff2",
                "VisjsNetworkLibrary.Resources.FontsAwesome.webfonts.fa-regular-400.woff2", 
                "font/woff2");

            cssContent = ReplaceFontReference(
                cssContent,
                "../webfonts/fa-brands-400.woff2",
                "VisjsNetworkLibrary.Resources.FontsAwesome.webfonts.fa-brands-400.woff2",
                "font/woff2");

            cssContent = ReplaceFontReference(
                cssContent,
                "../webfonts/fa-v4compatibility.woff2",
                "VisjsNetworkLibrary.Resources.FontsAwesome.webfonts.fa-v4compatibility.woff2",
                "font/woff2");

            return cssContent;
        }

        /// <summary>
        /// Reads the font file from the embedded resources, converts it to a Base64 string,
        /// and replaces the specified font URL in the CSS content with a data URI.
        /// </summary>
        private string ReplaceFontReference(string cssContent, string fontUrl, string resourceName, string mimeType)
        {
            if (cssContent.Contains(fontUrl))
            {
                byte[] fontData;
                Assembly assembly = Assembly.GetExecutingAssembly();
                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                {
                    if (stream == null)
                        throw new InvalidOperationException($"Resource '{resourceName}' not found.");
                    using (var ms = new MemoryStream())
                    {
                        stream.CopyTo(ms);
                        fontData = ms.ToArray();
                    }
                }
                string base64 = Convert.ToBase64String(fontData);
                string dataUri = $"data:{mimeType};base64,{base64}";
                cssContent = cssContent.Replace(fontUrl, dataUri);
            }
            return cssContent;
        }
    }
}
