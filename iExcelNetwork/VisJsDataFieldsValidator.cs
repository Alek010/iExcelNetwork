// Ignore Spelling: Json

using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;


namespace iExcelNetwork
{
    public static class VisJsDataFieldsValidator
    {
        private static readonly List<string> ValidFieldNames = new List<string>
    {
        "from",
        "to"
    };

        public static bool ValidateFieldNames(string jsonString)
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

        public static bool HasRecords(string jsonString)
        {
            JArray jsonArray = JArray.Parse(jsonString);

            var jsonObject = jsonArray.OfType<JObject>().ToList();

           return(jsonObject.Count > 0);
        }
    }


}
