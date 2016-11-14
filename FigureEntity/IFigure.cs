using System.Collections.Generic;

namespace Chess.FigureEntity
{
    public interface IFigure
    {
        string FigureType { get; set; }
        Stack<Position> Alghoritm(Position start, Position end, int fieldSize);
    }
}
