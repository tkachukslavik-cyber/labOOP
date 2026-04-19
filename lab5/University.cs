using System;

namespace lab5oop
{
    class University : Enterprise
    {
        public double ScientificIncome { get; set; }
        public double ConsultingIncome { get; set; }
        public int FacultiesNumber { get; set; }

        public University() : base()
        {
            Sphere = "Освіта і наука";
        }

        public University(string name, string city, string sphere, double ratingValue, int workersCount,
            double scientificIncome, double consultingIncome, int facultiesNumber)
            : base(name, city, sphere, ratingValue, workersCount)
        {
            ScientificIncome = scientificIncome;
            ConsultingIncome = consultingIncome;
            FacultiesNumber = facultiesNumber;
        }

        public University(University other) : base(other)
        {
            ScientificIncome = other.ScientificIncome;
            ConsultingIncome = other.ConsultingIncome;
            FacultiesNumber = other.FacultiesNumber;
        }

        public override double CalculateProfit(double percent, double averageSalary)
        {
            double fullIncome = ScientificIncome + ConsultingIncome;
            TotalProfit = (fullIncome * percent / 100.0) - (WorkersCount * averageSalary);
            return TotalProfit;
        }

        public override double CalculateProfit(double percent, double averageSalary, double additionalIncome)
        {
            double fullIncome = ScientificIncome + ConsultingIncome + additionalIncome;
            TotalProfit = (fullIncome * percent / 100.0) - (WorkersCount * averageSalary);
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
            Console.WriteLine("===== Університет =====");
            base.Display();
            Console.WriteLine($"Сумарний дохід: {ScientificIncome + ConsultingIncome}");
            Console.WriteLine($"Кількість факультетів: {FacultiesNumber}");
        }
    }
}