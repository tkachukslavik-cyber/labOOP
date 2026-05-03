using System;

namespace Lab_6_OOP
{
    class SmartGlassesException : Exception
    {
        public int ErrorCode { get; set; }

        public SmartGlassesException() : base("Помилка смарт-окулярів")
        {
            ErrorCode = 0;
        }

        public SmartGlassesException(string message) : base(message)
        {
            ErrorCode = 1;
        }

        public SmartGlassesException(string message, int errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }

        public SmartGlassesException(string message, Exception inner) : base(message, inner)
        {
            ErrorCode = -1;
        }

        public override string ToString()
        {
            return $"[Код: {ErrorCode}] {Message}";
        }
    }
}