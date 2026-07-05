using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Validation
{
    class RadarValidator: BaseValidator
    {
        protected override ValidationResult ValidateSpecificFields(Report report)
        {
            if (report is not RadarReport radar)
            {
                return ValidationResult.Failure("Unsupported report type");
            }

            if (radar.Speed < 0 || radar.Speed > 2000)
            {
                return ValidationResult.Failure("Wrong speed");
            }

            if (radar.Direction < 0 || radar.Direction > 360)
            {
                return ValidationResult.Failure("Wrong direction");
            }

            if (radar.Distance < 100 || radar.Distance > 100000)
            {
                return ValidationResult.Failure("Wrong distance");
            }

            return ValidationResult.Success();
        }
    }
}