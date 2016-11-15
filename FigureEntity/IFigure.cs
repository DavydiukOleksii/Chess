using System.Collections.Generic;

namespace Chess.FigureEntity
{
    public interface IFigure
    {
        string FigureType { get; set; }
        Stack<Position> GetPath(Position start, Position end, int fieldSize);
    }
}
