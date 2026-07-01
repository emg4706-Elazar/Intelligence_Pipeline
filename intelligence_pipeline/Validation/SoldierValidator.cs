using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Validation
{
    class SoldierValidator: BaseValidator
    {
        public SoldierValidator(int reportId, DateTime timestamp, double latitude,
            double longitude, string description, string soldierName, string soldierID, string unit, int confidenceLevel)
            :base(reportId, timestamp, latitude, longitude, description)
        {

        }
        protected override ValidationResult ValidateSpecificFields(Report report)
        {

        }
    }
}