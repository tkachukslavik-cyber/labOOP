using System;

namespace lab5oop
{
    class Enterprise
    {
        private string name;
        private string city;
        private string sphere;
        private double ratingValue;

        protected int workersCount;
        protected double totalProfit;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string Sphere
        {
            get { return sphere; }
            set { sphere = value; }
        }

        public double RatingValue
        {
            get { return ratingValue; }
            set { ratingValue = value; }
        }

        public int WorkersCount
        {
            get { return workersCount; }
            set { workersCount = value; }
        }

        public double TotalProfit
        {
            get { return totalProfit; }
            protected set { totalProfit = value; }
        }

        public Enterprise()
        {
            Name = "Невідомо";
            City = "Невідомо";
            Sphere = "Невідомо";
            RatingValue = 0;
            WorkersCount = 0;
            TotalProfit = 0;
        }

        public Enterprise(string name, string city, string sphere, double ratingValue, int workersCount)
        {
            Name = name;
            City = city;
            Sphere = sphere;
            RatingValue = ratingValue;
            WorkersCount = workersCount;
            TotalProfit = 0;
        }

        public Enterprise(Enterprise other)
        {
            Name = other.Name;
            City = other.City;
            Sphere = other.Sphere;
            RatingValue = other.RatingValue;
            WorkersCount = other.WorkersCount;
            TotalProfit = other.TotalProfit;
        }

        public virtual void Display()
        {
            Console.WriteLine($"Назва: {Name}");
            Console.WriteLine($"Місто: {City}");
            Console.WriteLine($"Сфера діяльності: {Sphere}");
            Console.WriteLine($"Рейтинг: {RatingValue}");
            Console.WriteLine($"Кількість працівників: {WorkersCount}");
            Console.WriteLine($"Прибуток: {TotalProfit}");
        }

        public virtual double CalculateProfit(double percent, double averageSalary)
        {
            TotalProfit = -WorkersCount * averageSalary;
            return TotalProfit;
        }

        public virtual double CalculateProfit(double percent, double averageSalary, double additionalIncome)
        {
            TotalProfit = additionalIncome - WorkersCount * averageSalary;
            return TotalProfit;
        }

        public virtual int CalculateEmployees(double salaryFund, double averageYearSalary)
        {
            if (averageYearSalary <= 0)
                return 0;

            WorkersCount = (int)(salaryFund / averageYearSalary);
            return WorkersCount;
        }

        public virtual int CalculateEmployees(double salaryFund, double averageYearSalary, int additionalWorkers)
        {
            if (averageYearSalary <= 0)
                return 0;

            WorkersCount = (int)(salaryFund / averageYearSalary) + additionalWorkers;
            return WorkersCount;
        }

        public override string ToString()
        {
            return $"Назва: {Name}, Місто: {City}, Сфера: {Sphere}, Рейтинг: {RatingValue}, Працівники: {WorkersCount}, Прибуток: {TotalProfit}";
        }
    }
}