using IntelligencePipeline.Models.Reports;
using System.Data;

namespace IntelligencePipeline.Validation
{
    class SoldierValidator: BaseValidator
    {
        protected override ValidationResult ValidateSpecificFields(Report report)
        {
            if (report is not SoldierReport soldier)
            {
                return ValidationResult.Failure("Unsupported report type");
            }

            if (soldier.SoldierName.Length < 2 || soldier.SoldierName.Length > 50)
            {
                return ValidationResult.Failure("Invalid length of name.");
            }

            if (soldier.SoldierID.Length != 7)
            {
                return ValidationResult.Failure("Invalid length of ID.");
            }

            if (!ContainsOnlyDigits(soldier.SoldierID))
            {
                return ValidationResult.Failure("Soldier ID must contain digits only.");
            }

            if (soldier.Unit.Length < 2 || soldier.Unit.Length > 50)
            {
                return ValidationResult.Failure("Invalid length of Unit.");
            }

            if (soldier.ConfidenceLevel < 1 || soldier.ConfidenceLevel > 5)
            {
                return ValidationResult.Failure("Wrong ConfidenceLevel");
            }

            return ValidationResult.Success();
        }
        private static bool ContainsOnlyDigits(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            foreach(char c in text)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }
    }
}