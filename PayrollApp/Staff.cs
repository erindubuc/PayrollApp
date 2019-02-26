using System;

namespace PayrollApp
{
    class Staff
    {
        private float hourlyRate;
        private int hWorked;

        public float TotalPay { get; protected set; }
        public float BasicPay { get; private set; }
        public string NameOfStaff { get; private set; }

        public int HoursWorked
        {
            get
            {
                return hWorked;
            }
            set
            {
                if (hWorked > 0)
                    hWorked = value;
                else
                    hWorked = 0;
            }
        }

        // Constructor
        public Staff(string name, float rate)
        {
            this.NameOfStaff = name;
            this.hourlyRate = rate;
        }

        // Methods
        // virtual tells compiler that this method may be overridden by derived classes
        public virtual void CalculatePay()
        {
            Console.WriteLine("Calculating Pay...");
            BasicPay = hWorked * hourlyRate;
            TotalPay = BasicPay;
        }

        public override string ToString()
        {
            return "\nName of Staff: " + NameOfStaff + "\nHourly Rate: " + hourlyRate + "\nHours Worked: " + hWorked 
                + "\nBasic Pay: " + BasicPay + "\nTotal Pay: " + TotalPay;
        }
    }
}
