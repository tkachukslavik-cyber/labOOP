using System;
using System.Text;

namespace Lab_6_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("Студент: Ткачук Святослав, група ІПЗ-11, варіант 5");

            SmartAssistant glasses = new SmartAssistant("Smart Glasses");

            glasses.LowBattery += OnEvent;
            glasses.PersonDetected += OnEvent;

            while (true)
            {
                Console.WriteLine("\n========== МЕНЮ ==========");
                Console.WriteLine("1 - Увімкнути пристрій");
                Console.WriteLine("2 - Вивести повідомлення");
                Console.WriteLine("3 - Розпізнати особу");
                Console.WriteLine("4 - AR режим");
                Console.WriteLine("5 - Список осіб");
                Console.WriteLine("6 - Голосова команда");
                Console.WriteLine("7 - Заряд батареї");
                Console.WriteLine("0 - Вихід");
                Console.Write("Оберіть пункт: ");

                string choice = Console.ReadLine();

                try
                {
                    if (string.IsNullOrWhiteSpace(choice))
                        throw new SmartGlassesException("Пункт меню не введено!");

                    switch (choice)
                    {
                        case "1":
                            glasses.TurnOn();
                            break;

                        case "2":
                            Console.Write("Введіть текст: ");
                            string message = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(message))
                                throw new SmartGlassesException("Повідомлення не може бути пустим!");

                            glasses.ShowMessage(message);
                            break;

                        case "3":
                            glasses.RecognizePerson();
                            break;

                        case "4":
                            glasses.UseAR();
                            break;

                        case "5":
                            glasses.ShowAllPeople();
                            break;

                        case "6":
                            Console.WriteLine("Доступні команди: message, person, ar, charge");
                            Console.Write("Введіть команду: ");
                            string command = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(command))
                                throw new SmartGlassesException("Команда не введена!");

                            glasses.VoiceCommand(command.ToLower());
                            break;

                        case "7":
                            glasses.ChargeBattery();
                            break;

                        case "0":
                            Console.WriteLine("Завершення програми...");
                            return;

                        default:
                            throw new SmartGlassesException("Невірний вибір меню!");
                    }
                }
                catch (SmartGlassesException ex)
                {
                    Console.WriteLine("Помилка: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Системна помилка: " + ex.Message);
                }
                finally
                {
                    Console.WriteLine("Дія виконана.\n");
                }
            }
        }

        static void OnEvent(string message)
        {
            Console.WriteLine(">>> ПОДІЯ: " + message);
        }
    }
}