using System.Collections.Generic;

namespace Chess.PlayerEntity
{
    public interface IPlayer
    {
        void AddFigure(string figureType, int startX, int startY, int finalX, int finalY);
        void SetFieldSize(int sizeOfField);
        Stack<Position> MoveFigureToFinalPosition();
    }
}
