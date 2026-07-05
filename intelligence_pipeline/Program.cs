using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Pipeline;

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
        public static ReportPipeline pipeline = new ReportPipeline();
        public static void Main(string[] args)
        {
            
            DroneReport d1 = new DroneReport(pipeline.GetNewId(), DateTime.Now, 30, 34, "Hello Elazar", 105, 7);
            RadarReport r1 = new RadarReport(pipeline.GetNewId(), DateTime.Now, 33, 35, "Good Morning", 7, 0, 100);
            SignalReport s1 = new SignalReport(pipeline.GetNewId(), DateTime.Now, 29.5000, 34.0000, "Hi everyone", 890,
                "Yuston  We Have a problem", Models.Enums.Language.English, -64);
            SoldierReport sol1 = new SoldierReport(pipeline.GetNewId(), DateTime.Now, 33.5000, 36.0000, "I wish it will work", "Moshe", "9037077", "8200", 3);

            List<Report> reports = [d1, r1, s1, sol1];
            foreach (Report report in reports)
            {
                pipeline.ProcessReport(report);
                Console.WriteLine($"{report.ReportId} | {report.GetSourceType()} | {report.Priority} | {report.ReliabilityScore} | {report.Classification}");
                Console.WriteLine();

            }
                
        }
        //private static void DisplayReport(Report report) { }
        //private static void DisplayValidatedReports(ReportRepository repository) { }
        //private static void DisplayRejectedReports(RejectedReportRepository repository) { }
    }
}
