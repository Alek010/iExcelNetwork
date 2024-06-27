// Ignore Spelling: Json

using iExcelNetwork.Helpers;
using System;
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
            new string[] { "F", "B" },
            new string[] { "F", "B" }
        };

        public static readonly List<string[]> FromToCountTable = new List<string[]>
        {
            new string[] { "From", "To", "Count"},
            new string[] { "A", "B", "1"},
            new string[] { "B", "C", "2" },
            new string[] { "C", "D", "1" },
            new string[] { "D", "C", "3" },
            new string[] { "E", "C", "1" },
            new string[] { "F", "B", "4" }
        };

        public static readonly List<string[]> InstructionsToBuildNetwork = new List<string[]>
        {
            new string[] { "A. How to build a basic link network:"},
            new string[] { ""},
            new string[] { "1. Select a range A1:B5. First row is column names."},
            new string[] { "    Column names always should have the same values and order."},
            new string[] { "2. Press the Select Range button." },
            new string[] { "3. Press the Build Network button." },
            new string[] { "4. Should to open HTML file which is saved locally in temporary directory." },
            new string[] { "    Press Network Properties button to change HTML file name and output folder." },
            new string[] { "5. You will see a generated network:"},
            new string[] { "    Link has count labels calculated by count of From-To pairs." },
            new string[] { "    Link arrow by default is directed to To nodes." },
            new string[] { "    Press Network Properties button to change link arrow direction." },
            new string[] { "6. Txt file with the same file name is generated in output folder." },
            new string[] { "    Provides HTML file SHA256 hash checksum for data integrity." }
        };

        public static readonly List<string[]> InstructionsToBuildNetworkWithCountColumn = new List<string[]>
        {
            new string[] { "B. How to build a basic link network:"},
            new string[] { ""},
            new string[] { "1. Select a range A15:C21. First row is column names."},
            new string[] { "    Column names always should have the same values and order."},
            new string[] { "    User manually provides From/To pair count in Count column."},
            new string[] { "    Count column values should to be integers."},
            new string[] { "    If there are From-To duplicates than yo will have several arrows."},
            new string[] { "2. Press the Select Range button." },
            new string[] { "3. Press the Build Network button." },
            new string[] { "4. Should to open HTML file which is saved locally in temporary directory." },
            new string[] { "    Press Network Properties button to change HTML file name and output folder." },
            new string[] { "5. You will see a generated network:"},
            new string[] { "    Link has count labels calculated by count of From-To pairs." },
            new string[] { "    Link arrow by default is directed to To nodes." },
            new string[] { "    Press Network Properties button to change link arrow direction." },
            new string[] { "6. Txt file with the same file name is generated in output folder." },
            new string[] { "    Provides HTML file SHA256 hash checksum for data integrity." }
        };

        public static readonly List<string[]> InstructionsToSaveJson = new List<string[]>
        {
            new string[] { "How to save a range as JSON file:"},
            new string[] { ""},
            new string[] { "1. Select a range A1:B5. First raw is always column names."},
            new string[] { "    Columns names and count is not important." },
            new string[] { "2. Press the Select Range button." },
            new string[] { "3. Press the Range To JSON button." },
            new string[] { "4. Select path where file will be saved." }
        };

        public static readonly List<string[]> FromToGeneratedNumbersDescription = new List<string[]>
        {
            new string[] {"                 Generated 500 rows of random numbers:"},
            new string[] {"Between 20000000 and 29999999                    Between 1 and 100"},
            new string[] {"As Latvian cell phone numbers"},
        };

        public static readonly List<string[]> FromToRandomNumbersAsLatvianPhoneNumbers = DataGenerator.GenerateFromToListOfNumbers(500, 20000000, 29999999);
        
        public static readonly List<string[]> FromToRandomNumberBetweenOneAndHundred = DataGenerator.GenerateFromToListOfNumbers(500, 1, 100);

    }
}
