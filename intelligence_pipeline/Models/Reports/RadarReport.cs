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

        public RadarReport(RadarReport other)
            : base(other)
        {
            Speed = other.Speed;
            Direction = other.Direction;
            Distance = other.Distance;
        }

        public override Report Clone()
        {
            return new RadarReport(this);
        }
        public override string GetSourceType() => "Radar";

        public override int CalculateReliabilityScore()
        {
            const int BaseScore = 6;
            int score = BaseScore;
            if (Distance >= 500 && Distance <= 30000) { score += 2; }
            if (Speed >= 10 && Speed <= 900) { score += 1; }
            if (Distance > 70000) { score -= 2; }
            if (Speed > 1500) { score -= 2; }

            return score;
        }
    }
}