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
            Console.WriteLine(d1.ToString());
        }
        //private static void DisplayReport(Report report) { }
        //private static void DisplayValidatedReports(ReportRepository repository) { }
        //private static void DisplayRejectedReports(RejectedReportRepository repository) { }
    }
}
