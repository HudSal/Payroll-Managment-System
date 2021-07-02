using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;//CsvReader

namespace MyPayProject
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine(TaxCalculator.CalculateResidentialTax(652));
            //Console.WriteLine(TaxCalculator.CalculateWorkingHolidayTax(418, 47938));

            //double[] hours = new double[6] { 2, 3, 3, 4, 5, 6 };
            //double[] rate = new double[6] { 25, 25, 25, 25, 32, 32 };
            //int id = 1;
            //ResidentPayRecord residentPayRecord = new ResidentPayRecord(id, hours, rate);
            //string first =  residentPayRecord.GetDetails();
            //Console.WriteLine($"Resident emp1 Detailes: {first} ");

            //int id1 = 2;
            //double[] hours1 = new double[8] { 2, 2, 2, 2, 2, 2, 2, 2 };
            //double[] rate1 = new double[8] { 25, 25, 25, 25, 25, 28, 28, 28 };
            //int visa = 417;
            //int yearToDate = 47520;
            //WorkingHolidayPayRecord workingHolidayPayRecord = new WorkingHolidayPayRecord(id1, hours1, rate1, visa, yearToDate);
            //string second = workingHolidayPayRecord.GetDetails();
            //Console.WriteLine($"Working Holiday PayRecord emp2 Detailes: {second} ");


            //double[] hours = new double[8] { 8, 8, 8, 8, 8, 8, 6, 6 };
            //double[] rate = new double[8] { 36, 36, 36, 36, 37.5, 37.5, 37.5, 37.5 };
            //int id = 3;
            //ResidentPayRecord residentPayRecord = new ResidentPayRecord(id, hours, rate);
            //string first = residentPayRecord.GetDetails();
            //Console.WriteLine($"Resident emp1 Detailes: {first} ");


            //int id1 = 4;
            //double[] hours1 = new double[7] { 5, 5, 5, 5, 5, 5, 2 };
            //double[] rate1 = new double[7] { 34.5, 34.5, 34.5, 34.5, 34.5, 34.5, 34.5 };
            //int visa = 462;
            //int yearToDate = 23000;
            //WorkingHolidayPayRecord workingHolidayPayRecord = new WorkingHolidayPayRecord(id1, hours1, rate1, visa, yearToDate);
            //string second = workingHolidayPayRecord.GetDetails();
            //Console.WriteLine($"Working Holiday PayRecord emp2 Detailes: {second} ");




            //double[] hours = new double[7] { 7, 6.5, 7, 7, 7, 3, 3 };
            //double[] rate = new double[7] { 42.5, 42.5, 42.5, 42.5, 42.5, 55.2, 55.2 };
            //int id = 5;
            //ResidentPayRecord residentPayRecord = new ResidentPayRecord(id, hours, rate);
            //string first = residentPayRecord.GetDetails();
            //Console.WriteLine($"Resident emp1 Detailes: {first} ");


            List<PayRecord> myEmployeesList = CsvImporter.ImportPayRecords("Import/employee-payroll-data.csv");
            //foreach (PayRecord e in myEmployeesList)
            //{
            //    Console.WriteLine($"{e.GetDetails()}");
            //}

            //List<PayRecord> myEmployeesList = CsvImporter.ReadCSVHelper("Import/employee-payroll-data.csv");
            //foreach (PayRecord e in myEmployeesList)
            //{
            //    Console.WriteLine($"{e.GetDetails()}");
            //}

            //List<PayRecord> employees = CsvImporter.ReadCSVHelper("Import/employee-payroll-data.csv");
            //foreach (PayRecord e in employees)
            //{
            //    Console.WriteLine($"ID:{e.Id} |  Gross: {e.Gross} | TAX: {e.Tax} |  NET: {e.Net}");
            //}

            PayRecordWriter.Write($"{DateTime.Now.Ticks}-MyData.csv", myEmployeesList, true);




            Console.Read();
        }

     
    }
}
