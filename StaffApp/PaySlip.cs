
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StaffApp
{
    class PaySlip
    {
        private int month, year;

        enum MonthOfYear
        {
            JAN = 1, FEB = 2, MAR, APR, MAY, JUN, JUL, AUG, SEPT, OCT, NOV, DEC
        }

        public PaySlip(int payMonth, int payYear)
        {
            month = payMonth;
            year = payYear;
        }

        public void GeneratePaySlip(List<Staff> list)
        {
            string path;
            foreach (Staff staff in list)
            {
                path = staff.Name + ".txt";
                using (StreamWriter writer = new StreamWriter(path))
                {
                    var monthName = Enum.GetNames(typeof(MonthOfYear))[month];
                    writer.WriteLine($"PAYSLIP FOR {monthName} {year}");
                    writer.WriteLine("==============================");
                    writer.WriteLine($"Name of Staff: {staff.Name}");
                    writer.WriteLine($"Hours Worked: {staff.HoursWorked}");
                    writer.WriteLine();
                    writer.WriteLine($"Basic Pay: {staff.BasicPay}");
                    if (staff.GetType() == typeof(Manager))
                    {
                        Manager mgr = (Manager)staff;
                        writer.WriteLine($"Allowance: {mgr.Allowance}");
                    }
                    else
                    {
                        Admin admin = (Admin)staff;
                        writer.WriteLine($"Overtime Pay: {admin.Overtime}");
                    }
                    writer.WriteLine();
                    writer.WriteLine("==============================");
                    writer.WriteLine($"Total Pay: {staff.TotalPay}");
                    writer.Close();
                }
            }
        }

        public void GenerateSummary(List<Staff> list)
        {
            var result = from staff in list
                         where staff.HoursWorked < 10
                         orderby staff.Name ascending
                         select staff;
            string path = "summary.txt";
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("Staff with less than 10 working hours");
                writer.WriteLine();
                foreach (Staff staff in result)
                    writer.WriteLine($"Name of Staff: {staff.Name}, Hours Worked: {staff.HoursWorked}");
                writer.Close();
            }
        }

        public override string ToString()
        {
            var monthName = Enum.GetNames(typeof(MonthOfYear))[month];
            return $"Month = {monthName}, Year = {year}" ;
        }
    }
}