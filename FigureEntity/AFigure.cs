using System;
using System.Collections.Generic;

namespace Chess.FigureEntity
{
    public abstract class AFigure: IFigure
    {
        public string FigureType { get; set; }
        public List<Position> MoveTemplates = new List<Position>();

        protected double DistanceBetweenPositions(Position first, Position second)
        {
            return Math.Sqrt(Math.Pow(first.X - second.X, 2) + Math.Pow(first.Y - second.Y, 2));
        }

        protected static bool CorrectPositin(Position position, int sizeOfField)
        {
            return position.X <= sizeOfField && position.Y <= sizeOfField && position.X > 0 && position.Y > 0;
        }

        protected abstract void AddMoveTemplates();

        public abstract Stack<Position> GetPath(Position start, Position end, int fieldSize);
    }
}
