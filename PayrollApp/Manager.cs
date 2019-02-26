using System;

namespace PayrollApp
{
    class Manager : Staff
    {
        private const float managerHourlyRate = 50f;

        public int Allowance { get; private set; }

        // Constructor
        // calls base constructor and passes name and field managerHourlyRate
        public Manager(string name) : base(name, managerHourlyRate)
        {
        
        }

        // Method to override CalcPay from Staff
        public override void CalculatePay()
        {
            base.CalculatePay();
            Allowance = 1000;

            if (HoursWorked > 160)
                TotalPay = BasicPay + Allowance;
        }

        public override string ToString()
        {
            return "\nName of Staff: " + NameOfStaff + "\nManager Hourly Rate: " + managerHourlyRate 
                + "\nHours Worked: " + HoursWorked + "\nBasic Pay: " + BasicPay 
                +"\nAllowance: " + Allowance + "\nTotal Pay: " + TotalPay;
        }

    }
}
