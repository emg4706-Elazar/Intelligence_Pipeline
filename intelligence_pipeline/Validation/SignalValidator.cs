using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Validation
{
    class SignalValidator: BaseValidator
    {
        protected override ValidationResult ValidateSpecificFields(Report report)
        {
            if (report is not SignalReport signal)
            {
                return ValidationResult.Failure("Unsupported report type");
            }

            if (signal.Frequency < 1.0 || signal.Frequency > 3000.0)
            {
                return ValidationResult.Failure("Wrong frequency");
            }

            if (signal.Content.Length < 5 || signal.Content.Length > 1000)
            {
                return ValidationResult.Failure("Wrong content");
            }

            if (signal.SignalStrength > 0 || signal.SignalStrength < -120)
            {
                return ValidationResult.Failure("Wrong SignalStrength");
            }


            return ValidationResult.Success();
        }
    }
}