// Ignore Spelling: Json Validator

using iExcelNetwork.Exceptions;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;


namespace iExcelNetwork.VisJsNetwork.Validations
{
    public static class VisJsDataValidator
    {
        public static void JsonStringIsNotNull(string jsonString)
        {
            if (jsonString == null)
                throw new SelectedRangeIsNullException(ExceptionMessage.RangeIsNotSelected());
        }

        public static void JsonFieldNamesAreValid(string jsonString)
        {
            if (!HasValidFieldNames(jsonString))
                throw new SelectedRangeJsonColumnNamesNotCorrectException(ExceptionMessage.RangeColumnNamesAreNotCorrect());
        }

        public static void JsonStringHasData(string jsonString)
        {
            if (!HasRecords(jsonString))
                  throw new SelectedRangeJsonHasNoRecordsException(ExceptionMessage.RangeHasNoRecords());
        }

        public static void ValidateFromToEdgesIdsCount(int fromNodesIdsCount, int toNodesIdsCount)
        {
            if (fromNodesIdsCount != toNodesIdsCount)
            {
                throw new FromNodesEdgeNodesCountNotEqualException(ExceptionMessage.FromToNodesCountNotEqual());
            }
        }

        public static void ValidateIfListOfIntegersAsStringsContainsNonIntegerValue(List<string> listofIntegersAsStrings)
        {
            if (listofIntegersAsStrings.Any(value => !int.TryParse(value, out _)))
                throw new ListOfIntegersAsStringsContainsNonIntegerValuesException(ExceptionMessage.NotAllValuesAreIntegersInCountColumn());
        }

        private static readonly List<string> ValidFieldNames = new List<string>
        {
            "from",
            "to",
            "count"
        };

        private static bool HasValidFieldNames(string jsonString)
        {
            foreach (var property in JArray.Parse(jsonString)
                                           .OfType<JObject>()
                                           .ToList()
                                           .Properties())
            {
                if (!ValidFieldNames.Contains(property.Name.ToLower().Trim()))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool HasRecords(string jsonString)
        {
           return JArray.Parse(jsonString)
                        .OfType<JObject>()
                        .ToList()
                        .Count > 0;
        }
    }
}
