using System;

namespace Lab_6_OOP
{
    class SmartAssistant : SmartGlasses
    {
        private string assistantName;
        private bool isActive;

        public string AssistantName
        {
            get => assistantName;
            set => assistantName = string.IsNullOrWhiteSpace(value) ? "Assistant" : value;
        }

        public bool IsActive
        {
            get => isActive;
            private set => isActive = value;
        }

        public SmartAssistant()
        {
            AssistantName = "Voice Assistant";
            IsActive = true;
        }

        public SmartAssistant(string assistantName)
        {
            AssistantName = assistantName;
            IsActive = true;
        }

        public void VoiceCommand(string command)
        {
            if (!IsActive)
            {
                Console.WriteLine("Помічник вимкнений.");
                return;
            }

            if (string.IsNullOrWhiteSpace(command))
            {
                Console.WriteLine("Команда не введена.");
                return;
            }

            command = command.ToLower();

            Console.WriteLine($"{AssistantName}: виконую команду \"{command}\"");

            switch (command)
            {
                case "повідомлення":
                case "message":
                    ShowMessage("Повідомлення через помічника");
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

                case "вимкнути":
                    TurnAssistantOff();
                    break;

                case "увімкнути":
                    TurnAssistantOn();
                    break;

                default:
                    Console.WriteLine("Невідома команда.");
                    break;
            }
        }

        public void TurnAssistantOff()
        {
            IsActive = false;
            Console.WriteLine($"{AssistantName} вимкнений.");
        }

        public void TurnAssistantOn()
        {
            IsActive = true;
            Console.WriteLine($"{AssistantName} увімкнений.");
        }
    }
}