using System;

namespace lab5oop
{
    class OilGasCompany : Enterprise
    {
        public double ProductionAmount { get; set; }

        public OilGasCompany() : base()
        {
            Sphere = "Нафтогазова галузь";
        }

        public OilGasCompany(string name, string city, string sphere, double ratingValue, int workersCount, double productionAmount)
            : base(name, city, sphere, ratingValue, workersCount)
        {
            ProductionAmount = productionAmount;
        }

        public OilGasCompany(OilGasCompany other) : base(other)
        {
            ProductionAmount = other.ProductionAmount;
        }

        public override double CalculateProfit(double percent, double averageSalary)
        {
            TotalProfit = (ProductionAmount * percent / 100.0) - (WorkersCount * averageSalary);
            return TotalProfit;
        }

        public override double CalculateProfit(double percent, double averageSalary, double additionalIncome)
        {
            TotalProfit = (ProductionAmount * percent / 100.0) + additionalIncome - (WorkersCount * averageSalary);
            return TotalProfit;
        }

        public override int CalculateEmployees(double salaryFund, double averageYearSalary)
        {
            if (averageYearSalary <= 0)
                return 0;

            WorkersCount = (int)(salaryFund / averageYearSalary);
            return WorkersCount;
        }

        public override int CalculateEmployees(double salaryFund, double averageYearSalary, int additionalWorkers)
        {
            if (averageYearSalary <= 0)
                return 0;

            WorkersCount = (int)(salaryFund / averageYearSalary) + additionalWorkers;
            return WorkersCount;
        }

        public override void Display()
        {
            Console.WriteLine("===== Нафтогазова компанія =====");
            base.Display();
            Console.WriteLine($"Обсяг видобутку: {ProductionAmount}");
        }
    }
}