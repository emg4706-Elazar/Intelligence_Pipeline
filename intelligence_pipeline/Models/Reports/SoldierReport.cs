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

        public SoldierReport(SoldierReport other)
            : base(other)
        {
            SoldierID = other.SoldierID;
            SoldierName = other.SoldierName;
            Unit = other.Unit;
            ConfidenceLevel = other.ConfidenceLevel;
        }

        public override Report Clone()
        {
            return new SoldierReport(this);
        }
        public override string GetSourceType() => "Soldier";

        public override int CalculateReliabilityScore()
        {
            const int BaseScore = 4;
            int score = BaseScore + ConfidenceLevel;
            if (IsInDescription("weapon", "vehicle", "movement", "explosion"))
                {
                score += 1;
                }

            return score;
        }

        private bool IsInDescription(params string[] Keywords)
        {
            bool found = false;
            foreach (string word in Keywords)
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