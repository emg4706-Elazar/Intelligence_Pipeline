using IntelligencePipeline.Models.Enums;

namespace IntelligencePipeline.Models.Reports
{
    class SignalReport : Report
    {
        public double Frequency { get; protected set; }
        public string Content { get; protected set; }
        public Language Language { get; protected set; }
        public int SignalStrength { get; protected set; }

        public SignalReport(int reportId, DateTime timestamp, double latitude,
            double longitude, string description,
            double frequency, string content, Language language,
            int signalStrength)
            : base(reportId, timestamp, latitude, longitude, description)
        {
            Frequency = frequency;
            Content = content;
            Language = language;
            SignalStrength = signalStrength;
        }
        public override string GetSourceType() => "Signal";
        public override int CalculateReliabilityScore()
        {

        }
    }
}