using IntelligencePipeline.Models.Enums;
using System.Reflection.Metadata;

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
        public SignalReport(SignalReport other)
            : base(other)
        {
            Frequency = other.Frequency;
            Content = other.Content;
            Language = other.Language;
            SignalStrength = other.SignalStrength;
        }

        public override Report Clone()
        {
            return new SignalReport(this);
        }
        public override string GetSourceType() => "Signal";

        public override int CalculateReliabilityScore()
        {
            const int BaseScore = 5;
            int score = BaseScore;
            if (SignalStrength >= -40) { score += 3; }
            if (SignalStrength >= -70) { score += 2; }
            if (IsInContent("attack", "target", "border", "vehicle")) { score += 1; }
            if (SignalStrength < -100) { score -= 2; }

            return score;
        }

        private bool IsInContent(params string[] Keywords)
        {
            bool found = false;
            foreach(string word in Keywords)
            {
                if (Content.Contains(word, StringComparison.OrdinalIgnoreCase))
                {
                    found = true;
                    break;
                }
            }

            return found;
        }
    }
}