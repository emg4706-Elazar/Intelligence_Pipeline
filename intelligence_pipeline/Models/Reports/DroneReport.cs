namespace IntelligencePipeline.Models.Reports
{
    class DroneReport: Report
    {
        public int Altitude { get; protected set; }
        public int ImageQuality { get; protected set; }


        public DroneReport(int reportId, DateTime timestamp, double latitude,
            double longitude, string description,
            int altitude, int imageQuality)
            : base(reportId, timestamp, latitude, longitude, description)
        {
            Altitude = altitude;
            ImageQuality = imageQuality;
        }


        public override string GetSourceType() => "Drone";
        public override int CalculateReliabilityScore()
        {
            const int BASESCORE = 5;
            int score = BASESCORE;
            if (ImageQuality >= 80) { score += 3; }
            if (ImageQuality >= 50) { score += 2; }
            if (Altitude >= 500 && Altitude <= 3000) { score += 2; }
            if (Altitude > 7000) { score -= 2; }

            return score;
        }

    }

}