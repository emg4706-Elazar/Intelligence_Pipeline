using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Storage
{
    class RejectedReportRepository
    {
        private List<Report> _rejectedReports;

        public RejectedReportRepository()
        {
            _rejectedReports = new List<Report>();
        }
        public void Add(Report report) { }
        public List<Report> GetAll()
        {
            List<Report> result = new List<Report>();

            foreach (Report report in _rejectedReports)
            {
                result.Add(report.Clone());
            }

            return result;
        }
        public int GetTotalCount()
        {
            return _rejectedReports.Count;
        }
        public List<Report> GetByReason(string reasonKeyword)
        {
            List<Report> result = new List<Report>();

            foreach (Report report in _rejectedReports)
            {
                if (report.RejectionReason.Contains(reasonKeyword, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(report);
                }
            }

            return result;
        }
    }
}