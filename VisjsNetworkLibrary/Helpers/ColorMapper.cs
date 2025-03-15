
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
        /// the default color is returned.
        /// If the passed value appears to be a hex color code, it is normalized and returned.
        /// </summary>
        public static string GetColor(string colorName)
        {
            if (string.IsNullOrWhiteSpace(colorName))
                return _colorMapping["default"];

            // If the dictionary contains the key, return its mapped value.
            if (_colorMapping.ContainsKey(colorName))
                return _colorMapping[colorName];

            // If the passed value does not start with '#', return default.
            if (!colorName.Trim().StartsWith("#"))
                return _colorMapping["default"];

            // At this point, the colorName is expected to be a hex color code.
            string hex = colorName.Trim().Substring(1);

            // Check for valid lengths (3, 4, 6, or 8 characters)
            if (hex.Length == 3 || hex.Length == 4 || hex.Length == 6 || hex.Length == 8)
            {
                bool valid = true;
                foreach (char c in hex)
                {
                    if (!Uri.IsHexDigit(c))
                    {
                        valid = false;
                        break;
                    }
                }
                if (valid)
                {
                    // Normalize by adding '#' and converting to lower case.
                    return "#" + hex.ToLower();
                }
            }

            // Fall-back: return default color.
            return _colorMapping["default"];
        }
    }
}
