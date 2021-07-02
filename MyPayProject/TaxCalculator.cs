using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPayProject
{
    /// <summary>
    /// TaxCalculator class has two methods to calculate tax amount for both Resident and WorkingHoliday Employee
    /// </summary>
   public class TaxCalculator
    {
        //Method CalculateResidentialTax
        /// <summary>
        /// This is CalculateResidentialTax method to calculate tax amount for resident (employees who live in Australia), which is calculated based on the value of gross pay.
        /// Using the gross amount to specified the coefficient values (A and B),which is used to calculate the tax amount using the formula Tax = A * Gross - B.
        /// Is located in TaxCalculator class.
        /// </summary>
        /// <param name="gross">The gross pay for the employee, It's double</param>
        /// <returns>Return the Tax for a resident employee, It's double</returns>
        public static double CalculateResidentialTax(double gross)
        {
            double A, B ;
            double Tax = 0.0;
            if (gross > -1 && gross <= 72)
            {
                A = 0.19;
                B = 0.19;
                Tax = A * gross - B;
            }
            else if(gross > 72 && gross <= 361)
            {
                A = 0.2342;
                B = 3.213;
                Tax = A * gross - B;
            }
            else if(gross > 361 && gross <= 932)
            {
                A = 0.3477;
                B = 44.2476;
                Tax = A * gross - B;
            }
            else if (gross > 932 && gross <= 1380)
            {
                A = 0.345;
                B = 41.7311;
                Tax = A * gross - B;
            }
            else if (gross > 1380 && gross <= 3111)
            {
                A = 0.39;
                B = 103.8657;
                Tax = A * gross - B;
            }
            else if (gross > 3111 && gross <= 999999)
            {
                A = 0.47;
                B = 352.7888;
                Tax = A * gross - B;
            }

            return Math.Round(Tax, 2);
        }

        /// <summary>
        /// This is CalculateWorkingHolidayTax method to calculate tax amount for wtorking holiday (employees who are visiting Australia and on a working holiday).
        /// Is calculated by multiplying the gross amount by the tax rate using the formula Tax = gross * rate.
        /// Is located in TaxCalculator class.
        /// </summary>
        /// <param name="gross">The gross pay for the employee, It's double</param>
        /// <param name="yearToDate">It is an employee’s year to date pay (how much they have been paid during the financial year), It's double</param>
        /// <returns>Return the Tax for a working holiday employee, It's double</returns>
        //Method CalculateWorkingHolidayTax
        public static double CalculateWorkingHolidayTax(double gross, double yearToDate)
        {
            double rate;
            double Tax = 0.0;
            double TotalGross = gross + yearToDate;
            if (TotalGross > -1 && TotalGross <= 37000)
            {
                rate = 0.15;
                Tax = gross * rate;
            }
            else if (TotalGross > 37000 && TotalGross <= 90000)
            {
                rate = 0.32;
                Tax = gross * rate;
            }
            else if (TotalGross > 90000 && TotalGross <= 180000)
            {
                rate = 0.37;
                Tax = gross * rate;
            }
            else if (TotalGross > 180000 && TotalGross <= 999999)
            {
                rate = 0.45;
                Tax = gross * rate;
            }

            return Math.Round(Tax, 2);
        }


    }
}
