using System.Collections.Generic;
using Chess.FigureEntity;

namespace Chess
{
    public class Field
    {
        #region Singleton
        private static Field instance;

        private Field() {}

        public static Field Instance
       {
          get 
          {
             if (instance == null)
             {
                instance = new Field();
             }
             return instance;
          }
       }
        #endregion

        public int SizeOfField { get; set; }

        //List that contains figures` position on the chess field
        public Dictionary<string, Position> CurrentFigurePositions = new Dictionary<string, Position>();
    }
}
