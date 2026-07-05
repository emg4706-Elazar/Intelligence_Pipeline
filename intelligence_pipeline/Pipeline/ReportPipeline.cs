using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Storage;
using IntelligencePipeline.Validation;
using IntelligencePipeline.Calculators;
/* This class receive only Report object,
 * Execute validation
 * Store in the appropriate repository
 */

namespace IntelligencePipeline.Pipeline
{
    class ReportPipeline
    {
        private ReportRepository _validatedReports;
        private RejectedReportRepository _rejectedReports;
        private int _nextReportId;

        public ReportPipeline()
        {
            _validatedReports = new ReportRepository(); 
            _rejectedReports = new RejectedReportRepository();
            _nextReportId = 0;
        }
        public void ProcessReport(Report report)
        {
            ValidateReport(report);
            if (report.Status == ReportStatus.Validated)
            {
                CalculateMetrics(report);
            }
            StoreReport(report);

        }
        public ReportRepository GetValidatedReports()
        {
            return _validatedReports;
        }

        public RejectedReportRepository GetRejectedReports()
        {
            return _rejectedReports;
        }

        public void DisplayStatistics() { }

        private IValidator GetValidator(Report report)
        {
            if (report.GetSourceType() == "Drone")
            {
                return new DroneValidator();
            }
            if (report.GetSourceType() == "Radar")
            {
                return new RadarValidator();
            }
            if (report.GetSourceType() == "Signal")
            {
                return new SignalValidator();
            }
            return new SoldierValidator();
        }

        private void ValidateReport(Report report)
        {
            report.Status = ReportStatus.Validating;
            IValidator validator = GetValidator(report);
            ValidationResult result = validator.Validate(report);
            if (! result.IsValid)
            {
                report.Status = ReportStatus.Rejected;
                report.RejectionReason = result.ErrorMessage;
            }
            else
            {
                report.Status = ReportStatus.Validated;
            }
        }
        private void CalculateMetrics(Report report)
        {

            PriorityCalculator priorityCalculator = new PriorityCalculator();
            report.Priority = priorityCalculator.Calculate(report);

            ReliabilityCalculator reliabilityCalculator = new ReliabilityCalculator();
            report.ReliabilityScore = reliabilityCalculator.Calculate(report);

            ClassificationCalculator classificationCalculator = new ClassificationCalculator();
            report.Classification = classificationCalculator.Calculate(report);
        }

        private void StoreReport(Report report)
        {
            if (report.Status == ReportStatus.Rejected)
            {
                _rejectedReports.Add(report);
            }
            else
            {
                _validatedReports.Add(report);
            }
        }

        public int GetNewId()
        {
            int currentId = _nextReportId;
            _nextReportId++;
            return currentId;
        }
    }
}

/* Change 'Status' from NEW to Validating.
             * Receive appropriate validator through GetValidator().
             * Calls Validate() on the selected IValidator.
             * Receive response from Validate() of ValidationResult whether it failed or success.
             * If fails:
             *      Set Status = Rejected
             *      Set RejectionReason
             *      Store in RejectedReportRepository through StoreReport().
             * If validation succeeds:
             *      Set Status = Validated
             *      Calculate ReliabilityScore through ReliabilityCalculator().
             *      Calculate Priority through PriorityCalculator().
             *      Calculat Classification through ClasificationCalculator().
             *      Store in ReportRepository through StoreReport().
             */
