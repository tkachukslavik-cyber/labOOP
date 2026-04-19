using System;

namespace lab5oop
{
    class InsuranceCompany : Enterprise
    {
        private double insuranceAmount;

        public double InsuranceAmount
        {
            get { return insuranceAmount; }
            set { insuranceAmount = value; }
        }

        public InsuranceCompany() : base()
        {
            InsuranceAmount = 0;
            Sphere = "Страхування";
        }

        public InsuranceCompany(string name, string city, string sphere, double ratingValue, int workersCount, double insuranceAmount)
            : base(name, city, sphere, ratingValue, workersCount)
        {
            InsuranceAmount = insuranceAmount;
        }

        public InsuranceCompany(InsuranceCompany other) : base(other)
        {
            InsuranceAmount = other.InsuranceAmount;
        }

        public override double CalculateProfit(double percent, double averageSalary)
        {
            TotalProfit = (InsuranceAmount * percent / 100.0) - (WorkersCount * averageSalary);
            return TotalProfit;
        }

        public override double CalculateProfit(double percent, double averageSalary, double additionalIncome)
        {
            TotalProfit = (InsuranceAmount * percent / 100.0) + additionalIncome - (WorkersCount * averageSalary);
            return TotalProfit;
        }

        public override void Display()
        {
            Console.WriteLine("===== Страхова компанія =====");
            base.Display();
            Console.WriteLine($"Страховий продукт: {InsuranceAmount}");
        }

        public static InsuranceCompany operator +(InsuranceCompany first, InsuranceCompany second)
        {
            InsuranceCompany result = new InsuranceCompany(first);
            result.WorkersCount += (int)((first.TotalProfit + second.TotalProfit) / 100000.0);
            return result;
        }

        public static InsuranceCompany operator -(InsuranceCompany first, InsuranceCompany second)
        {
            InsuranceCompany result = new InsuranceCompany(first);
            result.WorkersCount -= (int)((first.TotalProfit + second.TotalProfit) / 100000.0);

            if (result.WorkersCount < 0)
                result.WorkersCount = 0;

            return result;
        }

        public static bool operator >(InsuranceCompany first, InsuranceCompany second)
        {
            return first.TotalProfit > second.TotalProfit;
        }

        public static bool operator <(InsuranceCompany first, InsuranceCompany second)
        {
            return first.TotalProfit < second.TotalProfit;
        }

        public static bool operator ==(InsuranceCompany first, InsuranceCompany second)
        {
            if (ReferenceEquals(first, second)) return true;
            if (first is null || second is null) return false;
            return first.TotalProfit == second.TotalProfit;
        }

        public static bool operator !=(InsuranceCompany first, InsuranceCompany second)
        {
            return !(first == second);
        }

        public static InsuranceCompany operator ++(InsuranceCompany company)
        {
            company.TotalProfit += company.TotalProfit * 0.1;
            return company;
        }

        public static InsuranceCompany operator --(InsuranceCompany company)
        {
            company.TotalProfit -= company.TotalProfit * 0.1;
            return company;
        }

        public static InsuranceCompany operator -(InsuranceCompany company)
        {
            InsuranceCompany result = new InsuranceCompany(company);
            result.TotalProfit = -result.TotalProfit;
            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj is InsuranceCompany other)
                return this == other;
            return false;
        }

        public override int GetHashCode()
        {
            return TotalProfit.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString() + $", Страховий продукт: {InsuranceAmount}";
        }
    }
}