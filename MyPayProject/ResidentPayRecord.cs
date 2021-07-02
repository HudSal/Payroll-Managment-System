using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPayProject
{
    /// <summary>
    /// ResidentPayRecord class inherits from PayRecord class
    /// </summary>
    public class ResidentPayRecord:PayRecord
    {
        //Prop
        /// <summary>
        /// Overrides abstract property Tax from base class (PayRecord class), public Getter / no Setter.
        /// </summary>
        public override double Tax
        {
            get { 
            return CalculateResidentialTax(Gross);
            }
        }

        //Constructor
        /// <summary>
        /// This conctructor calls base constructor in the base class (PayRecord class) have three arguments int id,double[] hours,double[] rates
        /// </summary>
        /// <param name="id">The Employee ID it's an integer</param>
        /// <param name="hours">The employee's working hours array it's a double array</param>
        /// <param name="rates">The employee's working rate array it's a double array</param>
        public ResidentPayRecord(int id, double[] hours,double[] rates):base(id,hours,rates)
        {

        }
    }
}
