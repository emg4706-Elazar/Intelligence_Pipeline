using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Validation
{
    abstract class BaseValidator: IValidator
    {
        public ValidationResult Validate(Report report)
        {

        }
        protected ValidationResult ValidateCommonFields(Report report)
        {

        }
        protected abstract ValidationResult ValidateSpecificFields(Report report);
    }
}