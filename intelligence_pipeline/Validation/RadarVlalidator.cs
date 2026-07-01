using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Validation
{
    class RadarValidator: BaseValidator
    {
        public RadarValidator(int reportId, DateTime timestamp, double latitude,
            double longitude, string description,
            int speed, int direction, int distance)
            : base(reportId, timestamp, latitude, longitude, description)
        {

        }
        protected override ValidationResult ValidateSpecificFields(Report report)
        {

        }
    }
}