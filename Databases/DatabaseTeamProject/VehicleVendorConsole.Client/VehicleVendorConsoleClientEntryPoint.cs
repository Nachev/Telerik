namespace VehicleVendorConsole.Client
{
    using System;

    using PdfReportCreator;

    using VehicleVendor.Data;
    using VehicleVendor.Data.Repositories;
    using VehicleVendor.DataAceessData.Repository;
    using VehicleVendor.Reports;
    using VehicleVendor.Reports.JsonReportSQLServerGenerator;
    using VehicleVendor.Reports.MySqlDataJsonGenerator;
    using VehicleVendor.Reports.XmlReportSqlServerGenerator;
    using VehicleVendorConsole.Client.XmlInput;
    using VehicleVendorSqLite.Model;

    public class VehicleVendorConsoleClientEntryPoint
    {
        public static void Main()
        {
            using (var repo = new VehicleVendorRepository(
                new IVehicleVendorDbContext[]
                { 
                    new VehicleVendorDbContext()
                }))
            {
                var nissanMongoDb = new VehicleVendorMongoDb();
                var mongoLoader = new MongoLoader(repo, nissanMongoDb);
                Console.Write("Loading MongoDb data to SQL DB... ");
                mongoLoader.LoadRepository();
                repo.SaveChanges();
                Console.WriteLine("Done.");

                var xmlParser = new XmlParser(repo);
                Console.Write("Parsing XML data... ");
                var parseResult = xmlParser.ParseDiscounts(@"..\..\..\Discounts.xml", @"..\..\..\Discounts.xsd");
                var xmlLoader = new XmlLoader(repo, parseResult);
                Console.WriteLine("Done.");
                Console.Write("Loading XML data to SQL DB... ");
                xmlLoader.LoadRepository();
                repo.SaveChanges();
                Console.WriteLine("Done.");

                var zipExLoader = new ZipExcelLoaderNonCom(repo);
                Console.Write("Loading Excel zipped data... ");
                zipExLoader.LoadRepository();
                repo.SaveChanges();
                Console.WriteLine("Done.");

                var pdfReporter = new PdfReportSQLServerGenerator(repo);
                Console.Write("Generating pdf report... ");
                pdfReporter.GenerateReport();
                Console.WriteLine("Done.");

                var xmlReporter = new XmlReportGenerator(repo, new DateTime(2014, 01, 01), DateTime.Now);
                Console.Write("Generating xml report... ");
                xmlReporter.GenerateReport();
                Console.WriteLine("Done.");

                var jsonReporter = new JsonReportSQLServerGenerator(repo);
                Console.Write("Generating JSON report... ");
                jsonReporter.GenerateReport();
                Console.WriteLine("Done.");

                using (var repoMySql = new VehicleVendorMySqlRepository())
                {
                    var jsonToMySql = new MySqlDataJsonLoader(repo, repoMySql);
                    Console.Write("Loading JSON to MySQL... ");
                    jsonToMySql.WriteJsonsReportsToMySql();
                    Console.WriteLine("Done.");

                    using (var sqliteDb = new SqLiteContext())
                    {
                        var excelReporter = new ExcelReportsSQLiteGenerator(repoMySql, sqliteDb, new DateTime(2014, 8, 1), new DateTime(2014, 9, 1));
                        Console.Write("Generating Excel report... ");
                        excelReporter.GenerateReport();
                        Console.WriteLine("Done.");
                    }
                }
            }
        }
    }
}