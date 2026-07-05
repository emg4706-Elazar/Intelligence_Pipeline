using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Pipeline;
using IntelligencePipeline.Storage;


namespace IntelligencePipeline
{
    class Program
    {
        public static ReportPipeline pipeline = new ReportPipeline();

        public static void Main(string[] args)
        {
            GetInputForBaseReport();
            DroneReport d1 = new DroneReport(pipeline.GetNewId(), DateTime.Now, 30, 34, "Hello Elazar", 105, 7);
            RadarReport r1 = new RadarReport(pipeline.GetNewId(), DateTime.Now, 33, 35, "Good Morning", 7, 0, 100);
            SignalReport s1 = new SignalReport(pipeline.GetNewId(), DateTime.Now, 29.5000, 34.0000, "Hi everyone", 890,
                "Yuston  We Have a problem", Models.Enums.Language.English, -64);
            SoldierReport sol1 = new SoldierReport(pipeline.GetNewId(), DateTime.Now, 33.5000, 36.0000, "I wish it will work", "Moshe", "9037077", "8200", 3);

            List<Report> reports = [d1, r1, s1, sol1];

            foreach(Report report in reports)
            {
                pipeline.ProcessReport(report);
            }

            DisplayValidatedReports(pipeline.GetValidatedReports());
            DisplayRejectedReports(pipeline.GetRejectedReports());

            pipeline.DisplayStatistics();
            
                
        }
        private static void DisplayReport(Report report) 
        {
            Console.WriteLine(report.GetSummary());
        }
        private static void DisplayValidatedReports(ReportRepository repository)
        {
            foreach (Report report in repository.GetAll())
            {
                DisplayReport(report);
            }
        }

        private static void DisplayRejectedReports(RejectedReportRepository repository)
        {
            foreach (Report report in repository.GetAll())
            {
                DisplayReport(report);
            }
        }
        private static string[] GetInputForBaseReport()
        {
            Console.Write("Enter Timestamp: ");
            string timestamp = Console.ReadLine();
            Console.Write("Enter Latitude: ");
            string latitude = Console.ReadLine();
            Console.Write("Enter Longitude: ");
            string longitude = Console.ReadLine();
            Console.Write("Enter Description: ");
            string description = Console.ReadLine();

            string[] newReport = {timestamp, latitude, longitude, description};
            return newReport;
        }  
        private static string GetReportType()
        {
            Console.WriteLine("Choose report type!\n");
            Console.WriteLine("1. Drone\n2. Radar\n3. Soldier\n4. Signal\n");
            Console.Write("Enter number type: ");
            string choice = Console.ReadLine();

            return choice;
        }

        private static string[] GetInputDrone()
        {
            Console.Write("Enter Altitude: ");
            string altitude = Console.ReadLine();
            Console.Write("Enter ImageQuality: ");
            string imageQuality = Console.ReadLine();

            string[] fields = { altitude, imageQuality };
            return fields;
        }

        private static string[] GetInputRadar()
        {
            Console.Write("Enter Speed: ");
            string speed = Console.ReadLine();
            Console.Write("Enter Direction: ");
            string direction = Console.ReadLine();
            Console.Write("Enter Distance: ");
            string distance = Console.ReadLine();

            string[] fields = {speed, direction, distance };
            return fields;
        }
        private static string[] GetInputSoldier()
        {
            Console.Write("Enter SoldierID: ");
            string soldierID = Console.ReadLine();
            Console.Write("Enter SoldierName: ");
            string soldierName = Console.ReadLine();
            Console.Write("Enter Unit: ");
            string unit = Console.ReadLine();
            Console.Write("Enter ConfidenceLevel: ");
            string confidenceLevel = Console.ReadLine();

            string[] fields = { soldierID, soldierName, unit, confidenceLevel };
            return fields;
        }
        private static string[] GetInputSignal()
        {
            Console.Write("Enter Frequency: ");
            string frequency = Console.ReadLine();
            Console.Write("Enter Content: ");
            string content = Console.ReadLine();
            Console.Write("Enter Language: ");
            string language = Console.ReadLine();
            Console.Write("Enter SignalStrength: ");
            string signalStrength = Console.ReadLine();
            
            string[] fields = { frequency, content, language, signalStrength };
            return fields;
        }



        private static string[] GetInputForSpecificReport(string[] newReport, string choice)
        {
            switch (choice)
            {
                case "1":
                    string[] droneFields = GetInputDrone();
                    return droneFields;

                case "2":
                    string[] radarFields = GetInputRadar();
                    return radarFields;

                case "3":
                    string[] soldierFields = GetInputSoldier();
                    return soldierFields;

                case "4":
                    string[] signalFields = GetInputSignal();
                    return signalFields;

                default:
                    throw new ArgumentException("Invalid choice");
            };
        }
    }
}
