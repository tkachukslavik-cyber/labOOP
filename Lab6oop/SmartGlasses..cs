using System;

namespace Lab_6_OOP
{
    class SmartGlasses
    {
        private Camera camera;
        private Display display;
        private Battery battery;
        private Sensor sensor;

        private Person[] people;

        public delegate void GlassesHandler(string message);
        public event GlassesHandler LowBattery;
        public event GlassesHandler PersonDetected;

        public SmartGlasses()
        {
            camera = new Camera();
            display = new Display();
            battery = new Battery();
            sensor = new Sensor();

            people = new Person[]
            {
                new Person("Андрій", 22, "Нормальний"),
                new Person("Максим", 37, "Підозрілий"),
                new Person("Софія", 28, "Нормальний")
            };
        }

        public void TurnOn()
        {
            Console.WriteLine("Смарт-окуляри успішно увімкнені.");
            display.Show("Система готова до роботи");
        }

        public void ShowMessage(string text)
        {
            if (battery.Level <= 0)
                throw new SmartGlassesException("Батарея повністю розряджена!");

            if (string.IsNullOrWhiteSpace(text))
                throw new SmartGlassesException("Повідомлення не може бути порожнім!");

            display.Show(text);
            battery.Use(5);
            CheckBattery();
        }

        public void RecognizePerson()
        {
            if (battery.Level < 10)
                throw new SmartGlassesException("Недостатньо заряду для розпізнавання людини!");

            camera.Capture();
            sensor.Detect();

            Random random = new Random();
            int index = random.Next(people.Length);

            Console.WriteLine("\nРезультат розпізнавання:");
            people[index].Recognize();
            people[index].AnalyzeCondition();

            PersonDetected?.Invoke("Система розпізнала людину.");

            battery.Use(10);
            CheckBattery();
        }

        public void UseAR()
        {
            if (battery.Level < 15)
                throw new SmartGlassesException("Недостатньо заряду для режиму доповненої реальності!");

            display.Show("AR-режим активовано");
            Console.WriteLine("На екрані відображаються додаткові підказки.");

            battery.Use(15);
            CheckBattery();
        }

        public void CheckBattery()
        {
            if (battery.Level <= 20)
            {
                LowBattery?.Invoke("Низький рівень заряду батареї.");
            }
        }

        public void ChargeBattery()
        {
            battery.Charge();
        }

        public void ShowAllPeople()
        {
            Console.WriteLine("\n===== База розпізнавання людей =====");

            foreach (Person person in people)
            {
                person.ShowInfo();
                Console.WriteLine("--------------------------");
            }
        }

        public void VoiceCommand(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
                throw new SmartGlassesException("Голосова команда не введена!");

            switch (command.ToLower())
            {
                case "повідомлення":
                case "message":
                    ShowMessage("Повідомлення через голосову команду");
                    break;

                case "людина":
                case "person":
                    RecognizePerson();
                    break;

                case "ar":
                    UseAR();
                    break;

                case "зарядити":
                case "charge":
                    ChargeBattery();
                    break;

                default:
                    throw new SmartGlassesException("Невідома голосова команда!");
            }
        }
    }
}