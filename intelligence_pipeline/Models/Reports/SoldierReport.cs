namespace IntelligencePipeline.Models.Reports
{
    class SoldierReport: Report
    {
        public string SoldierName { get; protected set; }
        public string SoldierID { get; protected set; }
        public string Unit { get; protected set; }
        public int ConfidenceLevel { get; protected set; }

        public SoldierReport(int reportId, DateTime timestamp, double latitude,
            double longitude, string description,
            string soldierName, string soldierID, string unit, int confidenceLevel)
            : base(reportId, timestamp, latitude, longitude, description)
        {
            SoldierID = soldierID;
            SoldierName = soldierName;
            Unit = unit;
            ConfidenceLevel = confidenceLevel;
        }
        public override string GetSourceType() => "Soldier";
        public override int CalculateReliabilityScore()
        {

        }
    }
}