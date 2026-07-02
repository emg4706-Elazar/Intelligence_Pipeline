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
            int BASESCORE = 5;
            int score = BASESCORE;
            string[] KEYWORDS = {"attack" , "target", "border", "vehicle"};
            if (SignalStrength >= -40) { score += 3; }
            if (SignalStrength >= -70) { score += 2; }
            if (IsInContent(KEYWORDS)) { score += 1; }
            if (SignalStrength < -100) { score -= 2; }

            return score;
        }

        private bool IsInContent(string[] KEYWORDS)
        {
            bool found = false;
            foreach(string word in KEYWORDS)
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