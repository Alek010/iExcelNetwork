
using System.Collections.Generic;

namespace ExcelAddIn.Validations
{
    public static class ExcelDataValidation
    {
        public static Dictionary<string, string> GetColumnValidationListsDictionary(bool normalizeColumnNames = false)
        {
            string colLinkIsConfirmed = normalizeColumnNames ? "Link Is Confirmed" : "linkisconfirmed";
            string colFromIcon = normalizeColumnNames ? "From Icon" : "fromicon";
            string colToIcon = normalizeColumnNames ? "To Icon" : "toicon";
            string colFromColor = normalizeColumnNames ? "From Color" : "fromcolor";
            string colToColor = normalizeColumnNames ? "To Color" : "tocolor";

            return new Dictionary<string, string>
            {
                { colLinkIsConfirmed, "TRUE;FALSE" },
                { colFromIcon,  "Bank account;Cannabis;Car;Cellphone;Circle;Female;Group;Gun;Home;ID-card;Male;Motorcycle;Organization;Passport;Person;Phone;Pills;Truck" },
                { colToIcon,    "Bank account;Cannabis;Car;Cellphone;Circle;Female;Group;Gun;Home;ID-card;Male;Motorcycle;Organization;Passport;Person;Phone;Pills;Truck"},
                { colFromColor, "Default;Blue;Black;Green;Orange;Purple;Red" },
                { colToColor,   "Default;Blue;Black;Green;Orange;Purple;Red" }
            };
        }
    }
}

