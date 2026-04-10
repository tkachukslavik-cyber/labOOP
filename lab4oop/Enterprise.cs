using System;

namespace Lab_4_OOP
{
    class Enterprise : IComparable<Enterprise>
    {
        private string name;
        private string location;
        private string activity;
        private double rating;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public string Activity
        {
            get { return activity; }
            set { activity = value; }
        }

        public double Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        public Enterprise()
        {
            Name = "";
            Location = "";
            Activity = "";
            Rating = 0;
        }

        public Enterprise(string name, string location, string activity, double rating)
        {
            Name = name;
            Location = location;
            Activity = activity;
            Rating = rating;
        }

        public virtual void Display()
        {
            Console.WriteLine("Назва: " + Name);
            Console.WriteLine("Місце: " + Location);
            Console.WriteLine("Сфера: " + Activity);
            Console.WriteLine("Рейтинг: " + Rating);
        }

        public virtual int GetEmployees()
        {
            return 0;
        }

        public int CompareTo(Enterprise other)
        {
            if (other == null)
                return 1;

            return GetEmployees().CompareTo(other.GetEmployees());
        }
    }
}