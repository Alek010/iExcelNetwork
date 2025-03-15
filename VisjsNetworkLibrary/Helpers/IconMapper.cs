// Ignore Spelling: Visjs

using System;
using System.Collections.Generic;
using System.Globalization;

namespace VisjsNetworkLibrary.Helpers
{
    public static class IconMapper
    {
        // A case-insensitive mapping of meaningful names to Font Awesome Unicode codes.
        private static readonly Dictionary<string, string> _iconMapping = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "circle", "\uf111"}, // Default value if icon type is not set.
            { "person", "\uf007" },
            { "male", "\uf183" },
            { "female", "\uf182" },
            { "group", "\uf0c0" },
            { "cellphone", "\uf10b" },
            { "phone", "\uf098" },
            { "home", "\uf015" },
            { "organization", "\uf0f7" },
            { "gun", "\ue19b" },
            { "car", "\uf1b9" },
            { "truck", "\uf0d1" },
            { "motorcycle", "\uf21c" },
            { "passport", "\uf5ab" },
            { "id-card", "\uf2c2" },
            { "bank account", "\uf571" },
            { "cannabis", "\uf55f" },
            { "pills", "\uf490" }

            // Add other mappings as needed.
        };

        /// <summary>
        /// Gets the corresponding Unicode icon code for a given icon name.
        /// Returns the default "circle" icon if none is provided.
        /// If the provided icon name is not found in the mapping and appears to be a hex value (e.g. "f025"),
        /// it is converted to the corresponding Unicode character.
        /// </summary>
        public static string GetIconCode(string iconName)
        {
            // Return default if null or whitespace.
            if (string.IsNullOrWhiteSpace(iconName))
                return _iconMapping["circle"];

            // If the icon name exists in the mapping, return its corresponding value.
            if (_iconMapping.ContainsKey(iconName))
                return _iconMapping[iconName];

            // If the icon name does not start with "\u", then it is not a hex code; return default.
            if (!iconName.Trim().StartsWith("\\u", StringComparison.OrdinalIgnoreCase))
                return _iconMapping["circle"];

            // At this point, we assume the icon name is a Unicode hex code starting with "\u".
            // Remove the "\u" prefix.
            string hexValue = iconName.Trim().Substring(2);

            // Try to parse the remainder as a hex number.
            if (int.TryParse(hexValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int codePoint))
            {
                // Convert the code point to its corresponding Unicode character.
                return char.ConvertFromUtf32(codePoint);
            }

            // If parsing fails, return the default icon.
            return _iconMapping["circle"];
        }
    }

}
