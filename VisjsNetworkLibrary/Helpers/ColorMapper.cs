
// Ignore Spelling: Visjs

using System.Collections.Generic;
using System;

namespace VisjsNetworkLibrary.Helpers
{
    public static class ColorMapper
    {
        // A case-insensitive dictionary mapping color names to hex color codes.
        private static readonly Dictionary<string, string> _colorMapping = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        // Default color
        { "default", "#3d85c6" },
        // Additional mappings
        { "blue", "#3498db" },
        { "green", "#2ecc71" },
        { "red", "#e74c3c" },
        { "purple", "#9b59b6" },
        { "orange", "#e67e22" },
        { "black", "#000000" }
        // Add more mappings as needed.
    };

        /// <summary>
        /// Returns the hex color code for the given color name.
        /// If the provided colorName is null, empty, or not found in the dictionary,
        /// the default color "#f39c12" is returned.
        /// </summary>
        public static string GetColor(string colorName)
        {
            if (string.IsNullOrWhiteSpace(colorName))
                return _colorMapping["default"];

            return _colorMapping.ContainsKey(colorName) ? _colorMapping[colorName] : _colorMapping["default"];
        }
    }
}
