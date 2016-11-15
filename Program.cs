using Chess.PlayerEntity;
using System;
using System.Collections.Generic;

namespace Chess
{
    //internal enum FigureType
    //{
    //    КОНЬ,
    //    СЛОН,
    //    КОРОЛЕВА
    //}

    class Program
    {
        static void Main()
        {
            int sizeOfField;
            Position start, end;
            string figureType = "";
            IPlayer player = new Player();
            Stack<Position> way;

            #region EnterInitialData
            //enter size of field
            sizeOfField = ReadFromConsole.ReadInt("Not correct size, try again.", 1, int.MaxValue);
            //enter type of figure
            figureType = ReadFromConsole.ReadString("Not correct type of figure, try again.");
            //enter start position
            start = ReadFromConsole.ReadPosition("Not correct position, try again.", 1, sizeOfField);
            //enter final position
            end = ReadFromConsole.ReadPosition("Not correct position, try again.", 1, sizeOfField);
            #endregion

            //Add size of field and add figure to this field
            player.SetFieldSize(sizeOfField);
            player.AddFigure(figureType, start.X, start.Y, end.X, end.Y);

            //Try to search the way to final position
            way = player.MoveFigureToFinalPosition();

            //Check and display the found way
            if (way.Count > 0)
            {
                Console.WriteLine(way.Count);

                while (way.Count > 0)
                {
                    Console.WriteLine(way.Pop());
                }
            }
            else
            {
                Console.WriteLine("Error, the way can't found! Please check the initial data!");
            }

            //end of program
            Console.ReadLine();
        }
    }
}
