using Chess.FigureEntity;
using Chess.PlayerEntity;
using System;
using System.Collections.Generic;

namespace Chess
{
    public class Player: IPlayer
    {
        #region ProtectedValue
        protected readonly Field _field = Field.Instance;
        protected Position _finalPositions;
        protected IFigure _figure;
        #endregion

        #region ProtectedMethods
        //Method for changing position of the figure on chess field
        protected void MoveFigure(IFigure figure, Position moveTemplate)
        {
            if (_field.CurrentFigurePositions.ContainsKey(figure.FigureType))
            {
                _field.CurrentFigurePositions[figure.FigureType] += moveTemplate;
            }
        }

        //Method for initial positions of figures on the chess field
        protected void AddFigureToField(IFigure figure, Position startPosition)
        {
            _field.CurrentFigurePositions.Add(figure.FigureType, startPosition);
        }
        #endregion

        #region PublicMethods
        //Method for set initial size of the chess field
        public void SetFieldSize(int sizeOfField)
        {
            _field.SizeOfField = sizeOfField;
        }

        //Method for adding basic figure
        public void AddFigure(string figureType, int startPositionX, int startPositionY, int finalyPositionX, int finalyPositionY)
        {
            _figure = FigureFactory.Get(figureType);
            AddFigureToField(_figure, new Position(startPositionX, startPositionY));
            _finalPositions = new Position(finalyPositionX, finalyPositionY);
        }

        //Methods for finding the way to final position from start
        public Stack<Position> MoveFigureToFinalPosition()
        {
            Stack<Position> resoultWay = _figure.GetPath(_field.CurrentFigurePositions[_figure.FigureType], _finalPositions, _field.SizeOfField);
            foreach (Position posit in resoultWay)
            {
                MoveFigure(_figure, posit);
            }
            return resoultWay;
        }
        #endregion
    }
}
