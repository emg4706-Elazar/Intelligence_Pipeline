using IntelligencePipeline.Calculators;
using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Storage;
using IntelligencePipeline.Validation;


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

        public void DisplayStatistics()
        {
            Console.WriteLine("\n===== Statistics ====\n");
            Console.WriteLine($"All Reports: {_validatedReports.GetTotalCount() + _rejectedReports.GetTotalCount()}");
            Console.WriteLine($"Validated: {_validatedReports.GetTotalCount()}");
            Console.WriteLine($"Rejected: {_rejectedReports.GetTotalCount()}");
            Console.WriteLine($"In Progress: {_validatedReports.GetCountByStatus(ReportStatus.InProgress)}");
            Console.WriteLine($"Completed: {_validatedReports.GetCountByStatus(ReportStatus.Completed)}");
        }

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
            if (report.GetSourceType() == "Soldier")
            {
                return new SoldierValidator();
            }
            else
            {
                throw new Exception("Unknown report type");
            }
        }

        private void ValidateReport(Report report)
        /* 
         * Receive appropriate validator through GetValidator().
         * Calls Validate() on the selected IValidator.
         * Receive response from Validate() of ValidationResult whether it failed or success.
         * If fails:
              Set Status = Rejected
              Set RejectionReason
         * If validation succeeds:
              Set Status = Validated
        */

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
        /*  Calculate ReliabilityScore through ReliabilityCalculator().
         *  Calculate Priority through PriorityCalculator().
         *  Calculat Classification through ClasificationCalculator().
         */
        {
            ReliabilityCalculator reliabilityCalculator = new ReliabilityCalculator();
            report.ReliabilityScore = reliabilityCalculator.Calculate(report);

            PriorityCalculator priorityCalculator = new PriorityCalculator();
            report.Priority = priorityCalculator.Calculate(report);

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