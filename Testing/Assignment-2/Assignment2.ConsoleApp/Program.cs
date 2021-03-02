using System;
using Assignment2.ExtensionMethods;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("John".ChangeCase());
            Console.WriteLine("The quick bROWn fOx jumps OVer the laZY dog".ToTitleCase());
            Console.WriteLine("John".IsLowerCase() ? "All Characters are lower" : "Not all characters are lower");
            Console.WriteLine("john".Capitalize());
            Console.WriteLine("JOHN".IsUpperCase() ? "All Characters are upper" : "Not all characters are upper");
            Console.WriteLine("562p".IsValidNumericValue() ? "Is valid numeric string" : "Is not valid numeric string");
            Console.WriteLine("John Doe".RemoveLastCharacter());
            Console.WriteLine("John Doe".WordCount());
            Console.WriteLine("1987".ToInteger());
            Console.ReadLine();
        }
    }
}
