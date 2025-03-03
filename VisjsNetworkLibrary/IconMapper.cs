// Ignore Spelling: Visjs

using System;
using System.Collections.Generic;

namespace VisjsNetworkLibrary
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
        /// Returns the default "person" icon if none is provided or found.
        /// </summary>
        public static string GetIconCode(string iconName)
        {
            if (string.IsNullOrWhiteSpace(iconName))
                return _iconMapping["circle"];

            return _iconMapping.ContainsKey(iconName) ? _iconMapping[iconName] : iconName;
        }
    }

}
