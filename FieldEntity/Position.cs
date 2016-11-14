namespace Chess
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Position operator+ (Position a, Position b)
        {
            return new Position(a.X + b.X, a.Y + b.Y);
        }

        public static Position operator- (Position a, Position b)
        {
            return new Position(a.X - b.X, a.Y - b.Y);
        }

        public static bool operator == (Position a, Position b)
        {
            if(a.X == b.X && a.Y == b.Y)
                return true;
            return false;
        }

        public static bool operator != (Position a, Position b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            return X + " " + Y;
        }
    }
}
