using System;

namespace lab5oop
{
    class EnterpriseArray
    {
        private Enterprise[] enterprises;

        public EnterpriseArray(int size)
        {
            enterprises = new Enterprise[size];
        }

        public Enterprise this[int index]
        {
            get { return enterprises[index]; }
            set { enterprises[index] = value; }
        }

        public void DisplayAll()
        {
            for (int i = 0; i < enterprises.Length; i++)
            {
                Console.WriteLine($"\n--- Елемент {i} ---");
                enterprises[i]?.Display();
            }
        }
    }
}