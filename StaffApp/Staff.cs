using System;

namespace StaffApp
{
    class Staff
    {
        private float hourlyRate;
        private int hoursWorked;

        public Staff(string name, float rate)
        {
            Name = name;
            hourlyRate = rate;
        }

        public float TotalPay { get; protected set; }
        public float BasicPay { get; private set; }
        public string Name { get; private set; }
        public int HoursWorked { set { hoursWorked = value >= 0 ? value : 0; } get { return hoursWorked; } }

        public virtual void CalculatePay()
        {
            Console.WriteLine("Calculating Pay...");
            TotalPay = BasicPay = hourlyRate * hoursWorked;
        }

        public override string ToString()
        {
            return "hourly rate : " + hourlyRate + "hours worked :" + hoursWorked;
        }
    }
}
