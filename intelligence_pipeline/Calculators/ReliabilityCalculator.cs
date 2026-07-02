using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Calculators
{
    class ReliabilityCalculator
    {
        public int Calculate(Report report)
        {
            int res = report.CalculateReliabilityScore();
            if (res > 10) { res = 10; }
            if (res < 1) { res = 1; }

            return res;
        }
    }
}