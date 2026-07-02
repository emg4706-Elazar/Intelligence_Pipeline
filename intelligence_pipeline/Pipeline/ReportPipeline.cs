using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Storage;
using IntelligencePipeline.Validation;
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
            _validatedReports = ;
            _rejectedReports = ;
            _nextReportId = ;
        }
        public void ProcessReport(Report report)
        {
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
        }
        public ReportRepository GetValidatedReports() { }
        public RejectedReportRepository GetRejectedReports() { }
        public void DisplayStatistics() { }
        private IValidator GetValidator(Report report)
        {
            /* Returns appropriate IValidator
             */
        }
        private void ValidateReport(Report report)
        {
            /* returns ValidationResult with 'isValid' and sometimes 'ErrorMessage'. */
        }
        private void CalculateMetrics(Report report) { }
        private void StoreReport(Report report) { }
    }
}