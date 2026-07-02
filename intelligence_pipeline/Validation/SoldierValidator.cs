using IntelligencePipeline.Models.Reports;
using System.Data;

namespace IntelligencePipeline.Validation
{
    class SoldierValidator: BaseValidator
    {
        protected override ValidationResult ValidateSpecificFields(Report report)
        {
            if (report is SoldierReport soldier)
            {
                if (soldier.SoldierName.Length < 2 || soldier.SoldierName.Length > 50) { return ValidationResult.Failure("Invalid length of name."); }
                if (soldier.SoldierID.Length != 7) { return ValidationResult.Failure("Invalid length of ID."); }
                if (soldier.Unit.Length < 2 || soldier.Unit.Length > 50) { return ValidationResult.Failure("Invalid length of Unit."); }
                if (soldier.ConfidenceLevel < 1 || soldier.ConfidenceLevel > 5) { return ValidationResult.Failure("Wrong ConfidenceLevel"); }
            }
            return ValidationResult.Success();
        }
    }
}