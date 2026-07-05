using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Calculators
{
    class ClassificationCalculator
    {
        public Classification Calculate(Report report)
        {
            // Check 'Top Secret'
            // 1. 
            if (report.Priority == Priority.Critical) 
            {
                return Classification.TopSecret;
            }
            // 2.
            if (report is SignalReport signal)
            {
                if (ContainsKeyword(signal.Content, "target", "attack", "missile"))
                {
                    return Classification.TopSecret;
                }
            }

            // Check 'Secret'
            // 1.
            if (report.Priority == Priority.High)
            {
                return Classification.Secret;
            }
            // 2. 
            if (report.GetSourceType() == "Signal")
            {
                return Classification.Secret;
            }
            // 3.
            if (ContainsKeyword(report.Description, "weapon", "border"))
            {
                return Classification.Secret;
            }

            // Check 'Restricted'
            // 1.
            if (report.Priority == Priority.Medium)
            {
                return Classification.Restricted;
            }
            // 2.
            if (report.GetSourceType() == "Soldier")
            {
                return Classification.Restricted;
            }

            // Otherwise
            return Classification.Unclassified;

        }

        private bool ContainsKeyword(string text, params string[] keywords)
        {
            bool isContain = false;
            foreach (string word in keywords)
            {
                if (text.Contains(word, StringComparison.OrdinalIgnoreCase))
                {
                    isContain = true;
                    return isContain;
                }  
            }
            return isContain;
        }
    }
}