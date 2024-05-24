using System.Collections.Generic;

namespace iExcelNetwork.SheetDataWriter
{
    public static class HowItWorksData
    {
        public static readonly List<string[]> FromToTable = new List<string[]>
        {
            new string[] { "From", "To"},
            new string[] { "A", "B" },
            new string[] { "B", "C" },
            new string[] { "C", "D" },
            new string[] { "D", "C" },
            new string[] { "E", "C" },
            new string[] { "F", "B" }
        };

        public static readonly List<string[]> InstructionsToBuildNetwork = new List<string[]>
        {
            new string[] { "How to build a basic link network:"},
            new string[] { ""},
            new string[] { "1. Select a range A1:B5. First row is column names. Column names always should have the same values and order. "},
            new string[] { "2. Press the Select Range button." },
            new string[] { "3. Press the Build Network button." },
            new string[] { "4. Should to open HTML file which is saved locally in temporary directory. File name is visjs_network.html" },
        };

        public static readonly List<string[]> InstructionsToSaveJson = new List<string[]>
        {
            new string[] { "How to save a range as JSON file:"},
            new string[] { ""},
            new string[] { "1. Select a range A1:B5. First raw is always column names. Columns names and count is not important."},
            new string[] { "2. Press the Select Range button." },
            new string[] { "3. Press the Range To JSON button." },
            new string[] { "4. Select pass where file will be saved." },
        };
    }
}
