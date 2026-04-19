using lab5oop;
using System;
using System.Text;

namespace lab5oop
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            InsuranceCompany companyA = new InsuranceCompany(
                "ARX", "Київ", "Страхування", 8.7, 120, 500000);

            InsuranceCompany companyB = new InsuranceCompany(
                "ТАС", "Львів", "Страхування", 8.3, 90, 400000);

            OilGasCompany oilCompany = new OilGasCompany(
                "УкрНафта", "Полтава", "Нафтогазова галузь", 9.1, 300, 1200000);

            Factory factoryCompany = new Factory(
                "Інтерпайп", "Дніпро", "Виробництво", 8.9, 450, 2000000);

            University universityCompany = new University(
                "КНУ", "Київ", "Освіта і наука", 9.5, 700, 900000, 500000, 12);

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine();
                Console.WriteLine("========== МЕНЮ ==========");
                Console.WriteLine("1 - Показати всі об'єкти");
                Console.WriteLine("2 - Обчислити прибуток");
                Console.WriteLine("3 - Обчислити кількість працівників");
                Console.WriteLine("4 - Продемонструвати бінарні оператори");
                Console.WriteLine("5 - Продемонструвати унарні оператори");
                Console.WriteLine("6 - Робота з індексатором");
                Console.WriteLine("0 - Вихід");
                Console.Write("Ваш вибір: ");

                string command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        ShowAllEnterprises(companyA, companyB, oilCompany, factoryCompany, universityCompany);
                        break;
                    case "2":
                        ShowProfits(companyA, companyB, oilCompany, factoryCompany, universityCompany);
                        break;
                    case "3":
                        ShowEmployees(companyA, oilCompany, factoryCompany, universityCompany);
                        break;
                    case "4":
                        DemonstrateBinaryOperators(companyA, companyB);
                        break;
                    case "5":
                        DemonstrateUnaryOperators(companyA);
                        break;
                    case "6":
                        DemonstrateIndexer(companyA, oilCompany, factoryCompany, universityCompany);
                        break;
                    case "0":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }
            }
        }

        static void ShowAllEnterprises(InsuranceCompany companyA, InsuranceCompany companyB,
            OilGasCompany oilCompany, Factory factoryCompany, University universityCompany)
        {
            Console.Write("Введіть % прибутку: ");
            double percent = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть середню зарплату: ");
            double averageSalary = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\n===== УСІ ПІДПРИЄМСТВА =====\n");

            companyA.CalculateProfit(percent, averageSalary);
            companyA.Display();
            Console.WriteLine();

            companyB.CalculateProfit(percent, averageSalary);
            companyB.Display();
            Console.WriteLine();

            oilCompany.CalculateProfit(percent, averageSalary);
            oilCompany.Display();
            Console.WriteLine();

            factoryCompany.CalculateProfit(percent, averageSalary);
            factoryCompany.Display();
            Console.WriteLine();

            universityCompany.CalculateProfit(percent, averageSalary);
            universityCompany.Display();
            Console.WriteLine();
        }

        static void ShowProfits(InsuranceCompany companyA, InsuranceCompany companyB,
            OilGasCompany oilCompany, Factory factoryCompany, University universityCompany)
        {
            Console.Write("Введіть % прибутку: ");
            double percent = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть середню зарплату: ");
            double averageSalary = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть додатковий дохід: ");
            double additionalIncome = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\n===== ПРИБУТОК =====\n");

            Console.WriteLine($"Страхова компанія 1: {companyA.CalculateProfit(percent, averageSalary)}");
            Console.WriteLine($"Страхова компанія 2: {companyB.CalculateProfit(percent, averageSalary, additionalIncome)}");
            Console.WriteLine($"Нафтогазова компанія: {oilCompany.CalculateProfit(percent, averageSalary)}");
            Console.WriteLine($"Завод: {factoryCompany.CalculateProfit(percent, averageSalary, additionalIncome)}");
            Console.WriteLine($"Університет: {universityCompany.CalculateProfit(percent, averageSalary, additionalIncome)}");
        }

        static void ShowEmployees(InsuranceCompany companyA, OilGasCompany oilCompany,
            Factory factoryCompany, University universityCompany)
        {
            Console.Write("Введіть фонд заробітної плати: ");
            double salaryFund = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть середню річну зарплату: ");
            double averageYearSalary = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть додаткову кількість працівників: ");
            int additionalWorkers = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n===== КІЛЬКІСТЬ ПРАЦІВНИКІВ =====\n");

            Console.WriteLine($"Страхова компанія: {companyA.CalculateEmployees(salaryFund, averageYearSalary)}");
            Console.WriteLine($"Нафтогазова компанія: {oilCompany.CalculateEmployees(salaryFund, averageYearSalary, additionalWorkers)}");
            Console.WriteLine($"Завод: {factoryCompany.CalculateEmployees(salaryFund, averageYearSalary)}");
            Console.WriteLine($"Університет: {universityCompany.CalculateEmployees(salaryFund, averageYearSalary, additionalWorkers)}");
        }

        static void DemonstrateBinaryOperators(InsuranceCompany companyA, InsuranceCompany companyB)
        {
            Console.Write("Введіть % прибутку: ");
            double percent = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть середню зарплату: ");
            double averageSalary = Convert.ToDouble(Console.ReadLine());

            companyA.CalculateProfit(percent, averageSalary);
            companyB.CalculateProfit(percent, averageSalary);

            Console.WriteLine("\n===== БІНАРНІ ОПЕРАТОРИ =====\n");

            InsuranceCompany combinedCompany = companyA + companyB;

            Console.WriteLine("Результат companyA + companyB:");
            combinedCompany.Display();
            Console.WriteLine();

            Console.WriteLine($"companyA > companyB : {companyA > companyB}");
            Console.WriteLine($"companyA < companyB : {companyA < companyB}");
            Console.WriteLine($"companyA == companyB : {companyA == companyB}");
            Console.WriteLine($"companyA != companyB : {companyA != companyB}");
        }

        static void DemonstrateUnaryOperators(InsuranceCompany companyA)
        {
            Console.Write("Введіть % прибутку: ");
            double percent = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть середню зарплату: ");
            double averageSalary = Convert.ToDouble(Console.ReadLine());

            companyA.CalculateProfit(percent, averageSalary);

            Console.WriteLine("\n===== УНАРНІ ОПЕРАТОРИ =====\n");

            Console.WriteLine("Початковий об'єкт:");
            companyA.Display();

            ++companyA;
            Console.WriteLine("\nПісля оператора ++");
            companyA.Display();

            --companyA;
            Console.WriteLine("\nПісля оператора --");
            companyA.Display();

            InsuranceCompany reversedProfit = -companyA;
            Console.WriteLine("\nПісля зміни знака прибутку:");
            reversedProfit.Display();
        }

        static void DemonstrateIndexer(InsuranceCompany companyA, OilGasCompany oilCompany,
            Factory factoryCompany, University universityCompany)
        {
            Console.Write("Введіть % прибутку: ");
            double percent = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть середню зарплату: ");
            double averageSalary = Convert.ToDouble(Console.ReadLine());

            companyA.CalculateProfit(percent, averageSalary);
            oilCompany.CalculateProfit(percent, averageSalary);
            factoryCompany.CalculateProfit(percent, averageSalary);
            universityCompany.CalculateProfit(percent, averageSalary);

            Console.WriteLine("\n===== ІНДЕКСАТОР =====\n");

            EnterpriseArray enterprises = new EnterpriseArray(4);

            enterprises[0] = companyA;
            enterprises[1] = oilCompany;
            enterprises[2] = factoryCompany;
            enterprises[3] = universityCompany;

            enterprises.DisplayAll();

            Console.WriteLine("\nЕлемент за індексом 2:");
            enterprises[2].Display();
        }
    }
}