namespace IntelligencePipeline.Models.Reports
{
    class RadarReport: Report
    {
        public int Speed { get; protected set; }
        public int Direction { get; protected set; }
        public int Distance { get; protected set; }

        public RadarReport(int reportId, DateTime timestamp, double latitude,
            double longitude, string description,
            int speed, int direction, int distance)
            : base(reportId, timestamp, latitude, longitude, description)
        {
            Speed = speed;
            Direction = direction;
            Distance = distance;
        }


        public override string GetSourceType() => "Radar";

        public override int CalculateReliabilityScore()
        {
            int BASESCORE = 6;
            int score = BASESCORE;
            if (Distance >= 500 && Distance <= 30000) { score += 2; }
            if (Speed >= 10 && Speed <= 900) { score += 1; }
            if (Distance > 7000) { score -= 2; }
            if (Speed > 1500) { score -= 2; }

            return score;
        }
    }
}