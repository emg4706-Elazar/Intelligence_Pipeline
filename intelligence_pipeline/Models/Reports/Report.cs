using IntelligencePipeline.Models.Enums;


namespace IntelligencePipeline.Models.Reports
{
    abstract class Report
    {
        public int ReportId { get; }
        public DateTime Timestamp { get; protected set; }
        public double Latitude { get;protected set; }
        public double Longitude { get;protected set; }
        public string Description { get;protected set; }
        public ReportStatus Status { get; set; }
        public Priority Priority { get; set; }
        public Classification Classification { get; set; }
        public int ReliabilityScore { get; set; }
        public string RejectionReason { get; set; }

        protected Report(int reportId, DateTime timestamp,
            double latitude, double longitude, string description)
        {
            ReportId = reportId;
            Timestamp = timestamp;
            Latitude = latitude;
            Longitude = longitude;
            Description = description;
            Status = ReportStatus.New;
            Priority = Priority.Low;
            Classification = Classification.Unclassified;
            ReliabilityScore = 1;
            RejectionReason = string.Empty;

        }

        protected Report(Report other)
        {
            ReportId = other.ReportId;
            Timestamp = other.Timestamp;
            Latitude = other.Latitude;
            Longitude = other.Longitude;
            Description = other.Description;
            Status = other.Status;
            Priority = other.Priority;
            Classification = other.Classification;
            ReliabilityScore = other.ReliabilityScore;
            RejectionReason = other.RejectionReason;
        }

        public abstract Report Clone();
        public abstract string GetSourceType();
        public abstract int CalculateReliabilityScore();
        public virtual string GetSummary()
        {
            return $"Id: {ReportId} | Type:  {GetSourceType()} | Status: {Status} | Priority: {Priority}" +
                $" | Reliability: {ReliabilityScore} | Classification: {Classification}\n";
        }
        public override string ToString()
        {
            return $"ID: #{ReportId} | Status: {Status} | Timestamp: {Timestamp} | Description: {Description}";
        }
        
    }
}