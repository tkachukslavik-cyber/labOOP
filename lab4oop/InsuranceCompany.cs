using System;

namespace Lab_4_OOP
{
    class InsuranceCompany : Enterprise
    {
        public int Employees { get; set; }
        public double ProductValue { get; set; }

        public InsuranceCompany(string name, string location, string activity, double rating,
                                int employees, double productValue)
            : base(name, location, activity, rating)
        {
            Employees = employees;
            ProductValue = productValue;
        }

        public double CalculateProfit(double percent, double avgSalary)
        {
            double salaryFund = Employees * avgSalary;
            double profit = (ProductValue * percent / 100) - salaryFund;
            return profit;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("Працівники: " + Employees);
            Console.WriteLine("Вартість продукту: " + ProductValue);
        }

        public override int GetEmployees()
        {
            return Employees;
        }
    }
}