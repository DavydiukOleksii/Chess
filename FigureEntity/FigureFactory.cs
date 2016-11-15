namespace Chess.FigureEntity
{
    static class FigureFactory
    {
        public static AFigure Get(string id)
        {
            switch (id)
            {
                case "КОНЬ":
                    return new Knight();
                case "КОРОЛЕВА":
                    return new Queen();
                case "СЛОН":
                    return new Bishop();
                default:
                    return new Queen();
            }
        }
    }
}
