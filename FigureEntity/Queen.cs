using System;
using System.Collections.Generic;

namespace Chess.FigureEntity
{
    class Queen : AFigure, IFigure
    {
        public override Stack<Position> GetPath(Position start, Position end, int fieldSize)
        {
            Position currentPosition = start;
            Stack<Position> tmpWay = new Stack<Position>();

            Position prevVector = new Position(0, 0);

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

                if(prevVector != tempVector)
                {
                    tmpWay.Push(currentPosition);
                }
                else
                {
                    tmpWay.Pop();
                    tmpWay.Push(currentPosition);
                }
                    
                prevVector = tempVector;
            }



            Stack<Position> resoultWay = new Stack<Position>();
            int k = tmpWay.Count - 1;
            for (int i = 0; i < k; i++)
            {
                resoultWay.Push(tmpWay.Pop());
            }

            return resoultWay;
        }

        protected override void AddMoveTemplates()
        {
            MoveTemplates.Add(new Position(-1, -1));
            MoveTemplates.Add(new Position(0, -1));
            MoveTemplates.Add(new Position(1, -1));

            MoveTemplates.Add(new Position(-1, 1));
            MoveTemplates.Add(new Position(1, 0));

            MoveTemplates.Add(new Position(-1, 1));
            MoveTemplates.Add(new Position(0, 1));
            MoveTemplates.Add(new Position(1, 1));
        }

        public Queen()
        {
            FigureType = "Queen";
            AddMoveTemplates();
        }
    }
}
