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
            if (report.Timestamp.Year < 2020 || report.Timestamp > DateTime.Now) { return ValidationResult.Failure("Wrong timestamp"); }
            if (report.Latitude < 29.5000 || report.Latitude > 33.5000) { return ValidationResult.Failure("Wrong latitude"); }
            if (report.Longitude < 34.0000 || report.Longitude > 36.0000) { return ValidationResult.Failure("Wrong longitude"); }
            if (report.Description.Length < 10 || report.Description.Length > 500) { return ValidationResult.Failure("Invalid length of 'description'."); }

            return ValidationResult.Success();
        }
        protected abstract ValidationResult ValidateSpecificFields(Report report);
    }
}