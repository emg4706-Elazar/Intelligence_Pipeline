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

        }

    }

}