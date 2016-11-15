using System;

namespace Chess
{
    public static class ReadFromConsole
    {
        public static int ReadInt(string errorMessage, int minValue, int maxValue)
        {
            int value = 0;
            do
            {
                if (!int.TryParse(Console.ReadLine(), out value) || (value < minValue || value > maxValue))
                {
                   value = 0;
                    Console.WriteLine(errorMessage); 
                }
            } while (value == 0);
            return value;
        }

        public static string ReadString(string errorMessage)
        {
            string value = "";
            do
            {
                value = Console.ReadLine();
                if (!(value == "КОНЬ" || value == "КОРОЛЕВА" || value == "СЛОН"))
                {
                    value = "";
                    Console.WriteLine(errorMessage);
                }              
            } while (value == "");
            return value;
        }

        public static Position ReadPosition(string errorMessage, int minValue, int maxValue)
        {
            int x = 0, y = 0;
            do
            {
                string value = Console.ReadLine();
                string[] splitString = value.Split(' ');
                if (splitString.Length == 2)
                {
                    if (!int.TryParse(splitString[0], out x) || !int.TryParse(splitString[1], out y) || (x < minValue || x > maxValue || y < minValue || y > maxValue))
                    {
                        x = 0;
                        y = 0;
                    }
                    else break;
                }
                Console.WriteLine(errorMessage);
            } while (x == 0 || y == 0);
            return new Position(x, y);
        }
    }
}
