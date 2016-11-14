using System;
using System.Linq;

namespace Chess
{
    public static class ReadFromConsole
    {
        public static int ReadInt(string errorMessage, int minValue, int maxValue)
        {
            int value = 0;
            do
            {
                try
                {
                    value = int.Parse(Console.ReadLine());
                    if (value < minValue || value > maxValue)
                        throw new Exception();
                }
                catch (Exception)
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
                try
                {
                    value = Console.ReadLine();
                    if (value == "КОНЬ" || value == "КОРОЛЕВА" || value == "СЛОН") { }
                    else
                        throw new Exception();
                }
                catch (Exception)
                {
                    value = "";
                    Console.WriteLine(errorMessage);
                }
            } while (value == "");
            return value;
        }

        public static Position ReadPosition(string errorMessage, int minValue, int maxValue)
        {
            Position position = new Position(0, 0);
            do
            {
                try
                {
                    string value = Console.ReadLine();
                    string[] splitString = value.Split(' ');

                    if(splitString.Length == 2)
                    {
                        position.X = int.Parse(splitString[0]);
                        position.Y = int.Parse(splitString[1]);
                    }
                    else throw new Exception();


                    if (position.X < minValue || position.X > maxValue || position.Y < minValue || position.Y > maxValue)
                        throw new Exception();
                }
                catch (Exception)
                {
                    position.X = 0;
                    position.Y = 0;
                    Console.WriteLine(errorMessage);
                }
            } while (position.X == 0 || position.Y == 0);
            return position;
        }
    }
}
