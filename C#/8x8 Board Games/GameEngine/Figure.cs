using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine
{
    public abstract class Figure
    {
        protected FigureColor color;
        protected FigureType type;
        protected Position position;
        protected String draw;
        protected List<Position> validMoves = new List<Position>();

        internal Figure(FigureColor color, FigureType type, Position position)
        {
            this.color = color;
            this.type = type;
            this.position = position;
            CalculateValidMoves(position);
        }

        public string Draw { get { return draw; } }
        public int X { get { return position.X; } }
        public int Y { get { return position.Y; } }
        public FigureColor Color { get { return color; } }
        public FigureType Type { get { return type; } }
        public List<Position> ValidMoves { get { return this.validMoves; } set { this.validMoves = value; } }

        public abstract void CalculateValidMoves(Position currentPosition);

        public virtual void Move(Position newPosition)
        {
            if (validMoves.Contains(newPosition))
            {
                this.position = newPosition;
                this.validMoves.Clear();
                CalculateValidMoves(this.position);
            }
        }
        public static void AddHorizontalMoves(Position currentPosition, Figure fig)
        {
            for (int i = 0; i < currentPosition.X; i++)
            {
                Position p = new Position(i, currentPosition.Y);
                fig.validMoves.Add(p);
            }

            for (int i = currentPosition.X + 1; i <= 7; i++)
            {
                Position p = new Position(i, currentPosition.Y);
                fig.validMoves.Add(p);
            }


        }

        public static void AddVerticalMoves(Position currentPosition, Figure fig)
        {
            for (int i = 0; i < currentPosition.Y; i++)
            {
                Position p = new Position(currentPosition.X, i);
                fig.validMoves.Add(p);
            }

            for (int i = currentPosition.Y + 1; i <= 7; i++)
            {
                Position p = new Position(currentPosition.X, i);
                fig.validMoves.Add(p);
            }
            
        }

        public static void VerticalPositions(Position currentPosition)
        {
            List<Position> positions = new List<Position>();
            
        }

        public static void AddDiagonalMoves(Position currentPosition, Figure fig)
        {
            for (int i = 1; i <= currentPosition.X; i++)
            {
                if (currentPosition.Y - i >= 0)
                    {
                        Position p = new Position(currentPosition.X - i, (currentPosition.Y - i));
                        fig.validMoves.Add(p);
                    }

                if (currentPosition.Y + i <= 7)
                    {
                        Position p = new Position(currentPosition.X - i, (currentPosition.Y + i));
                        fig.validMoves.Add(p);
                    }
            }

            for (int i = 1; i <= 7 - currentPosition.X; i++)
            {
               
                    if (currentPosition.Y - i >= 0)
                    {
                        Position p = new Position(currentPosition.X + i, (currentPosition.Y - i));
                        fig.validMoves.Add(p);
                    }

                    if (currentPosition.Y + i <= 7)
                    {
                        Position p = new Position(currentPosition.X + i, (currentPosition.Y + i));
                        fig.validMoves.Add(p);
                    }


            }

            
        }
    }
}
