namespace StaffApp
{
    class Admin : Staff
    {

        private const float overtimeRate = 15.5F;
        private const float adminHourlyRate = 30F;

        public Admin(string name) : base(name, adminHourlyRate) { }

        public float Overtime { get; private set; }

        public override void CalculatePay()
        {
            base.CalculatePay();
            if (HoursWorked >= 160)
            {
                Overtime = overtimeRate * (HoursWorked - 160);
                TotalPay += Overtime;
            }
        }

        public override string ToString()
        {
            return "Total Pay : " + TotalPay + " | Overtime : " + Overtime;
        }
    }
}
