using System.Collections.Generic;

namespace Chess.FigureEntity
{
    class Knight : AbstactFigure, IFigure
    {
        public override Stack<Position> Alghoritm(Position start, Position end, int fieldSize)
        {
            Position currentPosition = start;
            Stack<Position> resoultWay = new Stack<Position>();

            if (CorectFieldSize(fieldSize, start, end))
            {
                Queue<Position> tmpWay = new Queue<Position>();
                int[,] mass = new int[fieldSize, fieldSize];
                for (int i = 0; i < fieldSize; i++)
                {
                    for (int j = 0; j < fieldSize; j++)
                    {
                        mass[i, j] = -1;
                    }
                }
                mass[currentPosition.X - 1, currentPosition.Y - 1] = 0;
                tmpWay.Enqueue(currentPosition);


                while (tmpWay.Count > 0 || end != currentPosition)
                {
                    Position current = tmpWay.Dequeue();

                    foreach (Position template in MoveTemplates)
                    {
                        Position newPosition = current + template;
                        if (CorrectPositin(newPosition, fieldSize) && mass[newPosition.X - 1, newPosition.Y - 1] == -1)
                        {
                            mass[newPosition.X - 1, newPosition.Y - 1] = mass[current.X - 1, current.Y - 1] + 1;
                            tmpWay.Enqueue(newPosition);

                            if (end == newPosition)
                            {
                                currentPosition = newPosition;
                                break;
                            }
                        }
                    }
                }

                resoultWay.Push(currentPosition);

                while (start != resoultWay.Peek())
                {
                    Position current = resoultWay.Peek();
                    foreach (Position template in MoveTemplates)
                    {
                        Position newPosition = current + template;
                        if (CorrectPositin(newPosition, fieldSize) && mass[newPosition.X - 1, newPosition.Y - 1] == (mass[current.X - 1, current.Y - 1] - 1))
                        {
                            resoultWay.Push(newPosition);
                            break;
                        }
                    }
                }

                //remove start position
                resoultWay.Pop();
            }
            return resoultWay;
        }

        protected bool CorectFieldSize(int fieldSize, Position start, Position end)
        {
            return (fieldSize > 3) ? 
                true : 
                fieldSize < 3 ? 
                    false : 
                    ((start == new Position(2, 2)) || (end == new Position(2,2))) ? 
                        false: 
                        true;
        }

        public override void AddMoveTemplates()
        {
            MoveTemplates.Add(new Position(-1, -2));
            MoveTemplates.Add(new Position(1, -2));

            MoveTemplates.Add(new Position(2, -1));
            MoveTemplates.Add(new Position(2, 1));

            MoveTemplates.Add(new Position(1, 2));
            MoveTemplates.Add(new Position(-1, 2));

            MoveTemplates.Add(new Position(-2, 1));
            MoveTemplates.Add(new Position(-2, -1));
        }

        public Knight()
        {
            FigureType = "Knight";
            AddMoveTemplates();
        }
    }
}
