using IntelligencePipeline.Models.Reports;
//using IntelligencePipeline.Storage;
//using IntelligencePipeline.Pipeline;
/* Receive the input from user.
 * Call to the match constructor to build a report object.
 * 
 */
using IntelligencePipeline.Validation;

namespace IntelligencePipeline
{
    class Program
    {
        public static void Main(string[] args)
        {
            DroneReport d1 = new DroneReport(1, DateTime.Now, 30, 34, "Hello Elazar", 105, 7);
            RadarReport r1 = new RadarReport(2, DateTime.Now, 33, 35, "Good Morning", 7, 0, 100);
            SignalReport s1 = new SignalReport(3, DateTime.Now, 29.5000, 34.0000, "Hi everyone", 890,
                "Yuston  We Have a problem", Models.Enums.Language.English, -64);
            SoldierReport sol1 = new SoldierReport(4, DateTime.Now, 33.5000, 36.0000, "I wish it will work", "Moshe", "9037077", "8200", 3);

            IValidator validator1 = new SoldierValidator();
            ValidationResult res1 = validator1.Validate(sol1);
            Console.WriteLine(sol1.GetSummary());
            Console.WriteLine($"{sol1.GetSourceType()} | {res1.IsValid} | {res1.ErrorMessage}\n");

            IValidator validator2 = new DroneValidator();
            ValidationResult res2 = validator2.Validate(d1);
            Console.WriteLine(d1.GetSummary());
            Console.WriteLine($"{d1.GetSourceType()} | {res2.IsValid} | {res2.ErrorMessage}\n");

            IValidator validator3 = new RadarValidator();
            ValidationResult res3 = validator3.Validate(r1);
            Console.WriteLine(r1.GetSummary());
            Console.WriteLine($"{r1.GetSourceType()} | {res3.IsValid} | {res3.ErrorMessage}\n");

            IValidator validator4 = new SignalValidator();
            ValidationResult res4 = validator4.Validate(s1);
            Console.WriteLine(s1.GetSummary());
            Console.WriteLine($"{s1.GetSourceType()} | {res4.IsValid} | {res4.ErrorMessage}\n");




        }
        //private static void DisplayReport(Report report) { }
        //private static void DisplayValidatedReports(ReportRepository repository) { }
        //private static void DisplayRejectedReports(RejectedReportRepository repository) { }
    }
}
