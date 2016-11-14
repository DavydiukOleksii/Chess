using System;
using System.Collections;
using System.Collections.Generic;

namespace Chess.FigureEntity
{
    public abstract class AbstactFigure: IFigure
    {
        public string FigureType { get; set; }
        public List<Position> MoveTemplates = new List<Position>();

        protected static bool CanFindTheWay(Position curent, Position final)
        {
            return (curent.X + curent.Y) % 2 == (final.X + final.Y) % 2;
        }

        protected double DistanceBetweenPositions(Position first, Position second)
        {
            return Math.Sqrt(Math.Pow(first.X - second.X, 2) + Math.Pow(first.Y - second.Y, 2));
        }

        protected static bool CorrectPositin(Position position, int sizeOfField)
        {
            return position.X <= sizeOfField && position.Y <= sizeOfField && position.X > 0 && position.Y > 0;
        }

        public abstract void AddMoveTemplates();

        public abstract Stack<Position> Alghoritm(Position start, Position end, int fieldSize);
    }
}
