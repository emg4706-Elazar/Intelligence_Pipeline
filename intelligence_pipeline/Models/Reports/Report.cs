using IntelligencePipeline.Models.Enums;


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

        protected Report(int reportId, DateTime timestamp,
            double latitude, double longitude, string description)
        {
            ReportId = reportId;
            Timestamp = timestamp;
            Latitude = latitude;
            Longitude = longitude;
            Description = description;
            Status = ReportStatus.New;
            // Temporary Values
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
            return $"ID: #{ReportId} | Status: {Status} | Latitude: {Latitude} | Longitude: {Longitude} | " +
                $"Timestamp: {Timestamp} | Description: {Description}";
        }
        public override string ToString()
        {
            return $"ID: #{ReportId} | Status: {Status} | Timestamp: {Timestamp} | Description: {Description}";
        }
    }
}