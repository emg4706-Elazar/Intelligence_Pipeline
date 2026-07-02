using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Validation
{
    interface IValidator
    {
        ValidationResult Validate(Report report);
    }
}