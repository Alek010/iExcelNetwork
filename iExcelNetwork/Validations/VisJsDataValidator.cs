// Ignore Spelling: Json Validator

using iExcelNetwork.Exceptions;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;


namespace iExcelNetwork
{
    public static class VisJsDataValidator
    {
        public static void JsonIsNotNull(string jsonString)
        {
            if (jsonString == null)
                throw new SelectedRangeIsNullException(ExceptionMessage.RangeIsNotSelected());
        }

        public static void JsonFieldNamesAreValid(string jsonString)
        {
            if (!HasValidFieldNames(jsonString))
                throw new SelectedRangeJsonColumnNamesNotCorrectException(ExceptionMessage.RangeColumnNamesAreNotCorrect());
        }

        public static void JsonHasData(string jsonString)
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

        private static readonly List<string> ValidFieldNames = new List<string>
        {
            "from",
            "to"
        };

        private static bool HasValidFieldNames(string jsonString)
        {
            JArray jsonArray = JArray.Parse(jsonString);

            var jsonObject = jsonArray.OfType<JObject>().ToList();

            foreach (var property in jsonObject.Properties())
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
            JArray jsonArray = JArray.Parse(jsonString);

            var jsonObject = jsonArray.OfType<JObject>().ToList();

           return(jsonObject.Count > 0);
        }
    }


}
