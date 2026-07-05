using IntelligencePipeline.Models.Reports;


namespace IntelligencePipeline.Validation
{
    abstract class BaseValidator: IValidator
    {
        public ValidationResult Validate(Report report)
        {
            ValidationResult res;

            res = ValidateCommonFields(report);
            if (! res.IsValid)
            {
                return res;
            }

            res = ValidateSpecificFields(report);
            return res;
        }

        protected ValidationResult ValidateCommonFields(Report report)
        {
            if (report.Timestamp.Year < 2020 || report.Timestamp > DateTime.Now)
            { 
                return ValidationResult.Failure("Wrong timestamp");
            }

            if (report.Latitude < 29.5000 || report.Latitude > 33.5000)
            { 
                return ValidationResult.Failure("Wrong latitude");
            }

            if (report.Longitude < 34.0000 || report.Longitude > 36.0000)
            { 
                return ValidationResult.Failure("Wrong longitude"); 
            }

            if (report.Description is null)
            {
                return ValidationResult.Failure("Description must be not null.");
            }

            if (report.Description.Length < 10 || report.Description.Length > 500) 
            {
                return ValidationResult.Failure("Invalid length of 'description'.");
            }

            return ValidationResult.Success();
        }
        protected abstract ValidationResult ValidateSpecificFields(Report report);
    }
}