
using System;
using System.Collections.Generic;

namespace StaffApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int month = 0, year = 0;

            List<Staff> list = new List<Staff>();
            list = FileReader.CreateStaffList();
            while(year == 0)
            {
                Console.Write("\nPlease enter the year : ");
                try
                {
                    var read =Console.ReadLine();                    
                    year = Convert.ToInt32(read);
                    if (year == 0)
                        throw new FormatException();
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Cannot read the year value, try again");
                }
            }

            while (month == 0 || month > 12)
            {
                Console.Write("\nPlease enter the month : ");
                try
                {
                    month = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Cannot read the month value, try again");
                }
            }

            for (int i = 0; i < list.Count; i++ )
            {
                try
                {
                    Console.Write($"\nEnter the number of hours worked for {list[i].Name}: ");
                    list[i].HoursWorked = Convert.ToInt32(Console.ReadLine());
                    list[i].CalculatePay();
                    Console.WriteLine(list[i].ToString());
                } catch(Exception e)
                {
                    i--;
                    Console.WriteLine("Error! Try again");
                }
            }

            PaySlip ps = new PaySlip(month, year);
            ps.GeneratePaySlip(list);
            ps.GenerateSummary(list);
            Console.ReadLine();
        }
    }
}
