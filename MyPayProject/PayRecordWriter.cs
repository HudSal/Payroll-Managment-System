using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;// to use Streamreader
using System.Globalization;//CultureInfo
using CsvHelper;//CsvReader


namespace MyPayProject
{
    /// <summary>
    /// PayRecordWriter is a public class has one method to create and write csv file using CsvHelper and CsvWriter class
    /// </summary>
    public class PayRecordWriter
    {

        // WRITE Method
        /// <summary>
        /// The Write method must accept a list of PayRecord objects and write the ID, Gross, Net and Tax amounts to a comma delimited values (.csv) file.
        /// It has an optional Boolean parameter named writeToConsole, with the default value false. If a true argument is passed in, the Write method must also write the values to the console.
        /// </summary>
        /// <param name="file">It's a string determines the file name and path for the new csv file</param>
        /// <param name="records">list of PayRecord objects</param>
        /// <param name="writeToConsole">It is a boolean with default value false,used to write the values to the console.</param>

        public static void Write(string file, List<PayRecord> records, bool writeToConsole =false)
        {
            
            StreamWriter writer = new StreamWriter(file);
            CsvWriter csvW = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csvW.WriteRecords(records);
            if (writeToConsole)
            {
                foreach (PayRecord e in records)
                {
                   
                    if (e.Id==2||e.Id==4)
                    {
                        var se = (WorkingHolidayPayRecord)e;
                        Console.WriteLine($"\n  ---------- EEMPLOYEE: {se.Id} ---------- \nGROSS:\t${se.Gross:n}\nNET:\t${se.Net:n}\nTAX:\t${se.Tax:n}\nVISA:\t{se.Visa}\nYTD:\t${(se.YearToDate+se.Gross):n}");

                    }
                    else 
                    {
                        Console.WriteLine($"\n  ---------- EEMPLOYEE: {e.Id} ---------- \nGROSS:\t${e.Gross:n}\nNET:\t${e.Net:n}\nTAX:\t${e.Tax:n}");
                    }
                }

            }
            csvW.Dispose();
            writer.Dispose(); 
        }

        
    }
}
