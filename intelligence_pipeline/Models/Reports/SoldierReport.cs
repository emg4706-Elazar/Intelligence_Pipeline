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
            const int BASESCORE = 4;
            int score = BASESCORE + ConfidenceLevel;
            string[] KEYWORDS = { "weapon", "vehicle", "movement", "explosion" };
            if (IsInDescription(KEYWORDS))
                {
                score += 1;
                }

            return score;
        }

        private bool IsInDescription(string[] KEYWORDS)
        {
            bool found = false;
            foreach (string word in KEYWORDS)
            {
                if (Description.Contains(word, StringComparison.OrdinalIgnoreCase))
                {
                    found = true;
                    break;
                }      
            }
            return found;
        }
    }
}