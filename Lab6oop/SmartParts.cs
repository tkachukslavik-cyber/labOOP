using System;

namespace Lab_6_OOP
{
    // Камера
    class Camera
    {
        private bool isWorking;

        public bool IsWorking
        {
            get => isWorking;
            set => isWorking = value;
        }

        public Camera()
        {
            IsWorking = true;
        }

        public void Capture()
        {
            if (!IsWorking)
            {
                Console.WriteLine("❌ Камера не працює!");
                return;
            }

            Console.WriteLine("📷 Камера: зображення отримано.");
        }
    }

    // Дисплей
    class Display
    {
        private int brightness;

        public int Brightness
        {
            get => brightness;
            set => brightness = Math.Clamp(value, 0, 100);
        }

        public Display()
        {
            Brightness = 50;
        }

        public void Show(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine("⚠ Немає тексту для відображення.");
                return;
            }

            Console.WriteLine($"💡 Дисплей [{Brightness}%]: {text}");
        }
    }

    // Батарея
    class Battery
    {
        private int level;

        public int Level
        {
            get => level;
            private set => level = Math.Clamp(value, 0, 100);
        }

        public event Action<string> LowBattery;

        public Battery()
        {
            Level = 100;
        }

        public void Use(int amount)
        {
            if (amount <= 0)
                return;

            Level -= amount;

            Console.WriteLine($"🔋 Рівень батареї: {Level}%");

            if (Level <= 20)
                LowBattery?.Invoke("Низький рівень батареї!");
        }

        public void Charge()
        {
            Level = 100;
            Console.WriteLine("🔌 Батарея повністю заряджена.");
        }
    }

    // Сенсор
    class Sensor
    {
        public event Action<string> ObjectDetected;

        public void Detect()
        {
            Console.WriteLine("📡 Сенсор: сканування середовища...");
            ObjectDetected?.Invoke("Виявлено об'єкт поруч!");
        }
    }
}