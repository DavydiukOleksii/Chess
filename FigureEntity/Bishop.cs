using System;
using System.Collections.Generic;

namespace Chess.FigureEntity
{
    class Bishop : AbstactFigure, IFigure
    {
        public override Stack<Position> Alghoritm(Position start, Position end, int fieldSize)
        {
            Position currentPosition = start;
            Stack<Position> resoultWay = new Stack<Position>();

            if (CanFindTheWay(start, end)) {

                Stack<Position> tmpWay = new Stack<Position>();
                tmpWay.Push(start);

                while (currentPosition != end)
                {
                    double distance = DistanceBetweenPositions(currentPosition, end);
                    Position tempVector = new Position(0, 0);

                    foreach (Position template in MoveTemplates)
                    {
                        double tmpDistance = DistanceBetweenPositions(template + currentPosition, end);
                        if (distance > tmpDistance && CorrectPositin(template + currentPosition, fieldSize))
                        {
                            tempVector = template;
                            distance = tmpDistance;
                        }
                    }

                    currentPosition += tempVector;

                    while (distance > DistanceBetweenPositions(tempVector + currentPosition, end))
                    {
                        distance = DistanceBetweenPositions(tempVector + currentPosition, end);
                        currentPosition += tempVector;
                    }

                    tmpWay.Push(currentPosition);
                }

                int k = tmpWay.Count - 1;
                for (int i = 0; i < k; i++)
                {
                    resoultWay.Push(tmpWay.Pop());
                }
            }

            return resoultWay;
        }

        public override void AddMoveTemplates()
        {
            MoveTemplates.Add(new Position(-1, -1));
            MoveTemplates.Add(new Position(1, -1));

            MoveTemplates.Add(new Position(-1, 1));
            MoveTemplates.Add(new Position(1, 1));
        }

        public Bishop()
        {
            FigureType = "Bishop";
            AddMoveTemplates();
        }
    }
}