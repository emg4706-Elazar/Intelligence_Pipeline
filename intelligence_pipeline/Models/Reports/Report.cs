using IntelligencePipeline.Models.Enums;
using System.Data;

namespace IntelligencePipeline.Models.Reports
{
    abstract class Report
    {
        public int ReportId { get; }
        public DateTime Timestamp { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }
        public ReportStatus Status { get; set; }
        public Priority Priority { get; set; }
        public Classification Classification { get; set; }
        public int ReliabilityScore { get; set; }
        public string RejectionReason { get; set; }

        protected Report(int reportId, DataTime timestamp, double latitude, double longitude, string description)
        {

        }
        public abstract string GetSourceType();
        public abstract int CalculateReliabilityScore();
        public virtual string GetSummary()
        {

        }
        public override string ToString()
        {

        }
    }
}