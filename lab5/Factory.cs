using System;

namespace lab5oop
{
    class Factory : Enterprise
    {
        public double ProductionScale { get; set; }

        public Factory() : base()
        {
            Sphere = "Виробництво";
        }

        public Factory(string name, string city, string sphere, double ratingValue, int workersCount, double productionScale)
            : base(name, city, sphere, ratingValue, workersCount)
        {
            ProductionScale = productionScale;
        }

        public Factory(Factory other) : base(other)
        {
            ProductionScale = other.ProductionScale;
        }

        public override double CalculateProfit(double percent, double averageSalary)
        {
            TotalProfit = (ProductionScale * percent / 100.0) - (WorkersCount * averageSalary);
            return TotalProfit;
        }

        public override double CalculateProfit(double percent, double averageSalary, double additionalIncome)
        {
            TotalProfit = (ProductionScale * percent / 100.0) + additionalIncome - (WorkersCount * averageSalary);
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
            Console.WriteLine("===== Завод =====");
            base.Display();
            Console.WriteLine($"Обсяг виробництва: {ProductionScale}");
        }
    }
}