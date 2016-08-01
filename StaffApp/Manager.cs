
namespace StaffApp
{
    class Manager : Staff
    {
        private const float managerHourlyRate = 50f;
        public int Allowance { get; private set; }
        public Manager(string name) : base(name, managerHourlyRate) { }

        public override void CalculatePay()
        {
            base.CalculatePay();
            Allowance = 1000;
            if (HoursWorked >= 160)
            {
                TotalPay += Allowance;
            }
        }

        public override string ToString()
        {
            return "Total Pay : " + TotalPay + " | Allowance : " + Allowance;
        }
    }
}
