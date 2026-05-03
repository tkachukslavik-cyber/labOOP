using System;

namespace Lab_6_OOP
{
    class Person
    {
        private string name;
        private int age;
        private string status;
        private bool isRecognized;

        public string Name
        {
            get => name;
            set => name = string.IsNullOrWhiteSpace(value) ? "Невідомо" : value;
        }

        public int Age
        {
            get => age;
            set => age = value < 0 ? 0 : value;
        }

        public string Status
        {
            get => status;
            set => status = string.IsNullOrWhiteSpace(value) ? "Нормальний" : value;
        }

        public bool IsRecognized
        {
            get => isRecognized;
            private set => isRecognized = value;
        }

        public Person()
        {
            Name = "Невідомо";
            Age = 0;
            Status = "Нормальний";
            IsRecognized = false;
        }

        public Person(string name, int age, string status)
        {
            Name = name;
            Age = age;
            Status = status;
            IsRecognized = false;
        }

        public void Recognize()
        {
            if (!IsRecognized)
            {
                IsRecognized = true;
                Console.WriteLine($"Людину розпізнано: {Name}");
            }
            else
            {
                Console.WriteLine($"{Name} вже був розпізнаний.");
            }
        }

        public void AnalyzeCondition()
        {
            switch (Status.ToLower())
            {
                case "підозрілий":
                    Console.WriteLine("⚠ Увага! Виявлено підозрілу особу.");
                    break;

                case "небезпечний":
                    Console.WriteLine("❗ Небезпека! Людина становить загрозу.");
                    break;

                default:
                    Console.WriteLine("Стан людини нормальний.");
                    break;
            }
        }

        public void ChangeStatus(string newStatus)
        {
            Status = newStatus;
            Console.WriteLine($"Статус змінено на: {Status}");
        }

        public void ShowInfo()
        {
            Console.WriteLine("\n--- Інформація про людину ---");
            Console.WriteLine($"Ім'я: {Name}");
            Console.WriteLine($"Вік: {Age}");
            Console.WriteLine($"Стан: {Status}");
            Console.WriteLine($"Розпізнано: {(IsRecognized ? "Так" : "Ні")}");
        }
    }
}