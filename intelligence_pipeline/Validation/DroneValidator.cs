using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Validation
{
    class DroneValidator: BaseValidator
    {
        protected override ValidationResult ValidateSpecificFields(Report report)
        {
            if (report is DroneReport drone)
            {
                if (drone.Altitude < 100 || drone.Altitude > 1000) { return ValidationResult.Failure("Wrong altitude"); }
                if (drone.ImageQuality < 1 || drone.ImageQuality > 100) { return ValidationResult.Failure("Wrong ImageQuality"); }
            }

            return ValidationResult.Success();
        }
    }
}