using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Validation
{
    class DroneValidator: BaseValidator
    {
        protected override ValidationResult ValidateSpecificFields(Report report)
        {
            if (report is not DroneReport drone)
            {
                return ValidationResult.Failure("Unsupported report type");
            }

            if (drone.Altitude < 100 || drone.Altitude > 10000)
            {
                return ValidationResult.Failure("Wrong altitude");
            }

            if (drone.ImageQuality < 1 || drone.ImageQuality > 100)
            {
                return ValidationResult.Failure("Wrong ImageQuality");
            }

            return ValidationResult.Success();
        }
    }
}