using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPayProject
{
    /// <summary>
    /// WorkingHolidayPayRecord class inherits from PayRecord class
    /// </summary>
    public class WorkingHolidayPayRecord:PayRecord
    {
        //prop
        /// <summary>
        ///  Overrides abstract property Tax from base class (PayRecord class), public Getter / no Setter.
        /// </summary>
        public override double Tax
        {
            get { 
            return CalculateWorkingHolidayTax(Gross, YearToDate);
            }
        }

        /// <summary>
        /// property for Visa with public integer getter return employee visa value, and private setter
        /// </summary>
        public int Visa { get; private set; }

        /// <summary>
        /// property for YearToDate with public integer getter return an employee’s year to date pay (how much they have been paid during the financial year) value, and private setter
        /// </summary>
        public int YearToDate { get; private set; }

        //constructor
        /// <summary>
        /// This conctructor calls base constructor in the base class (PayRecord class) have sex arguments int id,double[] hours,double[] rates,int visa, int yearToDate
        /// </summary>
        /// <param name="id">The Employee ID, it's an integer</param>
        /// <param name="hours">The employee's working hours array, it's a double array</param>
        /// <param name="rates">The employee's working rate array, it's a double array</param>
        /// <param name="visa">Visa Number, it's an integer </param>
        /// <param name="yearToDate">It is an employee’s year to date pay (how much they have been paid during the financial year), It's an integer</param>
        public WorkingHolidayPayRecord(int id, double[] hours, double[] rates, int visa, int yearToDate) : base(id, hours, rates)
        {
            Visa = visa;
            YearToDate = yearToDate;
        }


        // Method
        /// <summary>
        /// The GetDetails Method is public override base method with string return.
        /// Is located in WorkingHolidayPayRecord class and used to get all details about the employee such as employee ID, gross, net and tax amounts
        /// </summary>
        /// <returns>Return the values for the Visa and YearToDate properties In addittion to the employee ID, gross, net and tax amounts .</returns>
        public override string GetDetails()
        {
            return $"EmployeeID:{Id},  Gross:{Gross:n},  Net:{Net:n},  Tax:{Tax:n},  Visa:{Visa},  YTD:${(YearToDate+Gross):n}";

           // return $"\n  ---------- EEMPLOYEE: {Id} ---------- \nGROSS:\t${Gross:n}\nNET:\t${Net:n}\nTAX:\t${Tax:n}\nVISA:\t{Visa}\nYTD:\t${(YearToDate+Gross):n}\nHours:\t{String.Join("/", _hours)}\nRates:\t{String.Join("/", _rates)}";
        }
    }
}
