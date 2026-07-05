using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Storage
{
    class ReportRepository
    {
        private List<Report> _reports;
        public ReportRepository()
        {
            _reports = new List<Report>();
        }
        public void Add(Report report)
        {
            _reports.Add(report);
        }


        public List<Report> GetAll()
        {
            List<Report> result = new List<Report>();

            foreach(Report report in _reports)
            {
                result.Add(report.Clone());
            }

            return result;
        }

        public List<Report> GetByStatus(ReportStatus status)
        {
            List<Report> result = new List<Report>();

            foreach (Report report in _reports)
            {
                if (report.Status == status)
                result.Add(report.Clone());
            }

            return result;
        }

        public List<Report> GetByPriority(Priority priority)
        {
            List<Report> result = new List<Report>();

            foreach (Report report in _reports)
            {
                if (report.Priority == priority)
                result.Add(report.Clone());
            }

            return result;
        }
        public List<Report> Search(string keyword)
        {
            List<Report> result = new List<Report>();

            foreach (Report report in _reports)
            {
                if (report.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(report.Clone());
                }
            }

            return result;
        }


        // Added 'null'
        public Report? GetById(int reportId)
        {
            foreach (Report report in _reports)
            {
                if (report.ReportId == reportId)
                {
                    return report.Clone();
                }
            }

            return null;
        }

        public void UpdateStatus(int reportId, ReportStatus newStatus)
        {
            foreach (Report report in _reports)
            {
                if (report.ReportId == reportId)
                {
                    report.Status = newStatus;
                }
            }
        }
        public int GetTotalCount() 
        {
            return _reports.Count;
        }

        public int GetCountByStatus(ReportStatus status)
        {
            int counter = 0;
            foreach (Report report in _reports)
            {
                if (report.Status == status)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}