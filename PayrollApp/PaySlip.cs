using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApp
{
    class PaySlip
    {
        private int month;
        private int year;

        enum MonthsOfYear
        {
            JAN = 1,
            FEB = 2,
            MAR,
            APR,
            MAY,
            JUN,
            JUL,
            AUG,
            SEPT,
            OCT,
            NOV,
            DEC
        }


        // Constructor
        public PaySlip(int payMonth, int payYear)
        {
            month = payMonth;
            year = payYear;
        }

        // Methods
        public void GeneratePaySlip(List<Staff> myStaff)
        {
            string path;

            foreach (Staff f in myStaff)
            {
                path = " " + f.NameOfStaff + ".txt";

                // instantiate StreamWriter object and overwrite previous pay months
                StreamWriter sw = new StreamWriter(path);

                if (!File.Exists(path))
                    Console.WriteLine("Error: There is no file to be written to.");

                else
                {
                    // need to cast month to MonthsOfYear enum value so it'll be written as DEC vs 12
                    sw.WriteLine("PAYSLIP FOR {0} {1}",
                        (MonthsOfYear)month, year);
                    sw.WriteLine("==========================");
                    sw.WriteLine("Name of Staff: {0}", f.NameOfStaff);
                    sw.WriteLine("Hours Worked: {0}", f.HoursWorked);
                    sw.WriteLine("");
                    sw.WriteLine("Basic Pay: {0:C}", f.BasicPay);
                    
                    // Need to determine run time type of staff to determine allowance or overtime
                    if (f.GetType() == typeof(Manager))
                        sw.WriteLine("Allowance: {0:C}", ((Manager)f).Allowance);
                    else
                        sw.WriteLine("Overtime: {0:C}", ((Admin)f).Overtime);

                    sw.WriteLine("");
                    sw.WriteLine("==========================");
                    sw.WriteLine("Total Pay: {0:C}", f.TotalPay);
                    sw.WriteLine("==========================");

                    sw.Close();
                }
            }

        }

        public void GenerateSummary(List<Staff> myStaff)
        {
            var result =
                from f in myStaff
                where f.HoursWorked < 10
                orderby f.NameOfStaff ascending
                select new { f.NameOfStaff, f.HoursWorked};

            string path = "summary.txt";

            StreamWriter sw = new StreamWriter(path);

            if (!File.Exists(path))
                Console.WriteLine("Error: There is no file to be written to.");

            else
            {
                sw.WriteLine("Staff with less than 10 working hours");
                sw.WriteLine("");

                // loop through each result in result 
                foreach (var r in result)
                    sw.WriteLine("Name of Staff: {0}, Hours Worked: {1)", r.NameOfStaff, r.HoursWorked);

                sw.Close(); 
            }
        }

        public override string ToString()
        {
            return "Month: " + month + "Year: " + year;
        }
    }
}
