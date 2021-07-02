using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPayProject
{
    /// <summary>
    /// PayRecord class Inherits from TaxCalculator class
    /// </summary>
    public abstract class PayRecord:TaxCalculator
    {
        //Fields
        /// <summary>
        /// Both _hours and _rates fields are used as a parallel arrays to store the hours and rate for each shift, both fields are initialled by arguments passed in to the constructor.
        /// They are protected to use it only in the sub classes.
        /// </summary>
        protected double[] _hours;
        /// <summary>
        /// Both _hours and _rates fields are used as a parallel arrays to store the hours and rate for each shift, both fields are initialled by arguments passed in to the constructor.
        /// They are protected to use it only in the sub classes.
        /// </summary>
        protected double[] _rates;

        //Properties
        /// <summary>
        /// property for Id with public integer getter return employee id value, and private setter
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// property for Gross with no setter and with public douple getter return employee Gross value, derived value calculated from the sum of (hours multiplied by rate) for all shifts.
        /// </summary>
        public double Gross
        {
            get {
                double Gross = 0.0;
                for (int i = 0; i < _hours.Length; i++)
                {
                    Gross += _hours[i] * _rates[i];
                }
                return Math.Round(Gross, 2);
            }
        }
        /// <summary>
        ///  property for Tax public abstract double getter / no setter, derived value calculated from the appropriate TaxCalculator method based on the type of pay record(resident or working holiday)
        /// </summary>
        public abstract double Tax { get; }

        /// <summary>
        /// propery for Net public douple getter / no setter, derived value calculated from Gross minus Tax(Net = Gross - Tax)
        /// </summary>
        public double Net
        {
            get {
            double Net = Gross - Tax;
            return Math.Round(Net, 2);
            }
        }

        // Constructors
        /// <summary>
        /// This constructor in PayRecord class have three arguments int id,double[] hours,double[] rates
        /// </summary>
        /// <param name="id">The Employee ID, it's an integer</param>
        /// <param name="hours">The employee's working hours array it's a double array</param>
        /// <param name="rates">The employee's working rate array it's a double array</param>

        public PayRecord(int id,double[] hours,double[] rates)
        {
             Id = id;
            _hours = hours;
            _rates = rates;
        }

        /// <summary>
        /// The GetDetails Method is public virtual string return.
        /// Is located in PayRecord class and used to get all details about the employee such as employee ID, gross, net and tax amounts
        /// </summary>
        /// <returns>return the employee ID, gross, net and tax amounts</returns>
        //Methods GetDetails
        public virtual string GetDetails()
        {
          
           return $"EmployeeID:{Id},  Gross:{Gross:n},  Net:{Net:n},  Tax:{Tax:n}";

           // return $"\n  ---------- EEMPLOYEE: {Id} ---------- \nGROSS:\t${Gross:n}\nNET:\t${Net:n}\nTAX:\t${Tax:n}\nHOURS:\t{String.Join("/",_hours)}\nRATES:\t{String.Join("/", _rates)} ";
        }
       
    }
}
