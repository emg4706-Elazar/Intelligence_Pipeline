using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Calculators
{
    class PriorityCalculator
    {
        public Priority Calculate(Report report)
        {
            string[] KEYWORDS1 = { "missile", "explosion", "attack", "fire" };

            // Check Critical
            // 1.
            foreach (string word in KEYWORDS1)
            {
                if (report.Description.Contains(word, StringComparison.OrdinalIgnoreCase))
                {
                    return Priority.Critical;
                }
            }
            // 2.
            if (report is SignalReport signal)
            {
                if (signal.Content.Contains("target", StringComparison.OrdinalIgnoreCase) &&
                signal.Content.Contains("attack", StringComparison.OrdinalIgnoreCase))
                {
                    return Priority.Critical;
                }

            }
            // 3.
            if (report is RadarReport radar)
            {
                if (radar.Speed >= 800)
                {
                    return Priority.Critical;
                }
            }
            // Check High
            // 1.
            string[] KEYWORDS2 = { "weapon", "suspicious", "border" };
            foreach(string word in KEYWORDS2)
            {
                if (report.Description.Contains(word, StringComparison.OrdinalIgnoreCase))
                {
                    return Priority.High;
                }
            }
            // 2.
            if (report is DroneReport drone)
            {
                if (drone.Altitude < 500)
                {
                    return Priority.High;
                }
            }
            // 3.
            if (report is RadarReport radar1)
            {
                if (radar1.Speed >= 400)
                {
                    return Priority.High;
                }
            }
            // 4.
            if (report is SoldierReport soldier)
            {
                if (soldier.ConfidenceLevel >= 4 &&
                    report.Description.Contains("movement", StringComparison.OrdinalIgnoreCase))
                {
                    return Priority.High;
                }
            }
            // Check Medium
            // 1.
            string[] KEYWORDS3 = {"movement", "vehicle", "activity" };
            foreach (string word in KEYWORDS3)
            {
                if (report.Description.Contains(word, StringComparison.OrdinalIgnoreCase))
                {
                    return Priority.Medium;
                }
            }
            // 2.
            if (report is RadarReport radar2)
            {
                if (radar2.Speed >= 120)
                {
                    return Priority.Medium;
                }
            }
            // 3.
            if (report.ReliabilityScore >= 7)
            {
                return Priority.Medium;
            }

            return Priority.Low;
        }
    }
}