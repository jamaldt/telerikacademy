using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public struct Position
    {
        public int x;
        public int y;

        public Position(int x, int y)
            :this()
        {
            this.X = x;
            this.Y = y;
        }

        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                if (value > 7 || value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    this.x = value;
                }
            }

        }

        public int Y
        {
            get
            {
                return this.y;
            }
            set
            {
                if (value > 7 || value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    this.y = value;
                }
            }

        }

    }
}
