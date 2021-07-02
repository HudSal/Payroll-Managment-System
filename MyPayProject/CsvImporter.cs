using System;
using System.IO;
using System.Collections.Generic;// List
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.Globalization;

namespace MyPayProject
{
    /// <summary>
    /// CsvImporter class has two methods one for opening and reading from CSV file and another one for instantiating a new pay record object.
    /// </summary>
    public class CsvImporter
    {
        /// <summary>
        /// This is ImportPayRecords method which is a public static with ListPayRecord return. It has one string argument file_name.
        /// This method uses a StreamReader class from the reusable System.IO component
        /// </summary>
        /// <param name="file">CSV file name and location, It's a string</param>
        /// <returns>Return the PayRecord list</returns>
        public static List<PayRecord> ImportPayRecords(string file)
        {

            List<PayRecord> records = new List<PayRecord>();
            try
            {
                StreamReader reader = new StreamReader(file);
                reader.ReadLine();
                List<double> hours = new List<double>();
                List<double> rate = new List<double>();
                int prevID = -1;
                string prevVisa = "";
                string prevYTD = "";
                while (!reader.EndOfStream)
                {

                    string line = reader.ReadLine();
                    string[] strLine = line.Split(',');

                    int id = int.Parse(strLine[0]);
                    string visa = strLine[3];
                    string yToD = strLine[4];
                    double h = double.Parse(strLine[1]);
                    double r = double.Parse(strLine[2]);

                    if (prevID != -1 && prevID != id)
                    {
                        PayRecord currEmp = CreatePayRecord(prevID, hours.ToArray(), rate.ToArray(), prevVisa, prevYTD);
                        hours.Clear(); //empty the hours list
                        rate.Clear(); // empty the rate list
                        hours.Add(h);
                        rate.Add(r);
                        records.Add(currEmp); //add to records list
                    }
                    //add hours to hours list and rate to Rate list
                    if (prevID == id || prevID == -1)
                    {
                        hours.Add(h);
                        rate.Add(r);
                    }

                    //store prev line
                    prevID = id;
                    prevVisa = visa;
                    prevYTD = yToD;

                }
                //create and add last employee
                PayRecord lastEmp = CreatePayRecord(prevID, hours.ToArray(), rate.ToArray(), prevVisa, prevYTD);
                hours.Clear(); //empty the hours list
                rate.Clear();// empty the rate list
                records.Add(lastEmp); //add to records list

                reader.Dispose();

            }
            catch (Exception)
            {
                Console.WriteLine("ERROR");
            }
            return records;
        }

        //Method
        /// <summary>
        /// This CreatePayRecord method is used for instantiating a new pay record object from the data in csv file either a ResidentPayRecord or WorkingHolidayPayRecord, as appropriate. 
        /// </summary>
        /// <param name="id">The Employee ID it's an integer</param>
        /// <param name="hours">The employee's working hours array it's a double array</param>
        /// <param name="rates">The employee's working rate array it's a double array</param>
        /// <param name="visa">Visa Number, it's a string</param>
        /// <param name="yearToDate">It is an employee’s year to date pay (how much they have been paid during the financial year), It's a string</param>
        /// <returns>Return a new PayRecord object either a ResidentPayRecord or WorkingHolidayPayRecord, as appropriate.</returns>
        public static PayRecord CreatePayRecord(int id, double[] hours, double[] rates, string visa, string yearToDate)
        {
            if (visa == "" || yearToDate == "")
            {
                ResidentPayRecord rPR = new ResidentPayRecord(id, hours, rates);
                return rPR;
            }
            else
            {

                WorkingHolidayPayRecord wHPR = new WorkingHolidayPayRecord(id, hours, rates, int.Parse(visa), int.Parse(yearToDate));
                return wHPR;
            }

        }

        /// <summary>
        /// This is ReadCSVHelper method which is a public static with ListPayRecord return. It has one string argument file_name.
        /// This method uses a StreamReader class from the reusable System.IO component and a CsvReader class from reusable CsvHelper. 
        /// </summary>
        /// <param name="fileName">CSV file name and location, It's a string</param>
        /// <returns>Return the PayRecord list</returns>
        public static List<PayRecord> ReadCSVHelper(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            List<double> hours = new List<double>();
            List<double> rate = new List<double>();
            int prevID = -1;
            string prevVisa = "";
            string prevYTD = "";
            CsvReader csvR = new CsvReader(reader, CultureInfo.InvariantCulture);
            List<PayRecord> records = new List<PayRecord>();
           try { 
                csvR.Read();
                csvR.ReadHeader();
                while (csvR.Read())
                {
                    int id = csvR.GetField<int>("EmployeeId");
                    string visa = csvR.GetField<string>("Visa");
                    string yToD = csvR.GetField<string>("YearToDate");
                    double h = csvR.GetField<double>("Hours");
                    double r = csvR.GetField<double>("Rate");

                    if (prevID != -1 && prevID != id)
                    {
                        PayRecord currEmp = CreatePayRecord(prevID, hours.ToArray(), rate.ToArray(), prevVisa, prevYTD);
                        hours.Clear(); 
                        rate.Clear(); 
                        hours.Add(h);
                        rate.Add(r);
                        records.Add(currEmp); 
                    }
                    if (prevID == id || prevID == -1)
                    {
                        hours.Add(h);
                        rate.Add(r);
                    }
                    prevID = id;
                    prevVisa = visa;
                    prevYTD = yToD;
                }
              
                PayRecord lastEmp = CreatePayRecord(prevID, hours.ToArray(), rate.ToArray(), prevVisa, prevYTD);
                hours.Clear(); 
                rate.Clear();
                records.Add(lastEmp); 
                csvR.Dispose();
                reader.Dispose();
           }
           catch (Exception)
           {
               Console.WriteLine("ERROR");
           }
                return records;
        }


        
    }
}
