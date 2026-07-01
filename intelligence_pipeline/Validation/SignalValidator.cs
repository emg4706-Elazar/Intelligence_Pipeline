using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Validation
{
    class SignalValidator: BaseValidator
    {
        public SignalValidator(int reportId, DateTime timestamp, double latitude,
            double longitude, string description,
            double frequency, string content, Language language,
            int signalStrength)
            : base(reportId, timestamp, latitude, longitude, description)
        {

        }
        protected override ValidationResult ValidateSpecificFields(Report report)
        {

        }
    }
}