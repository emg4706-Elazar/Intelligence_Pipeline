using IntelligencePipeline.Models.Reports;
//using IntelligencePipeline.Storage;
//using IntelligencePipeline.Pipeline;
/* Receive the input from user.
 * Call to the match constructor to build a report object.
 * 
 */

namespace IntelligencePipeline
{
    class Program
    {
        public static void Main(string[] args)
        {
            DroneReport d1 = new DroneReport(1, DateTime.Now, 46, 98, "Hello Elazar", 6, 7);
            RadarReport r1 = new RadarReport(2, DateTime.Now, 48, 90, "Good Morning", 7, 8, 34);
            SignalReport s1 = new SignalReport(3, DateTime.Now, 75, 12, "Hi everyone", 890,
                "Yuston  We Have a problem", Models.Enums.Language.English, -64);
            SoldierReport sol1 = new SoldierReport(4, DateTime.Now, 98, 20, "Save me", "Moshe", "9037077", "8200", 3);

            Report[] reports = { d1, r1, s1, sol1 };
            foreach (Report report in reports)
            {
                Console.WriteLine(report.ToString());
                Console.WriteLine(report.GetSummary());
                Console.WriteLine();
            }
            
        }
        //private static void DisplayReport(Report report) { }
        //private static void DisplayValidatedReports(ReportRepository repository) { }
        //private static void DisplayRejectedReports(RejectedReportRepository repository) { }
    }
}
