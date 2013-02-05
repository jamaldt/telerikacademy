using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ball_in_Cuboid
{
    class Cuboid
    {
        private static int Width;
        private static int Height;
        private static int Depth;
        private static Cube[, ,] cube;

        static void Main(string[] args)
        {
            string[] input = (Console.ReadLine()).Split(' ');
            Width = int.Parse(input[0]);
            Height= int.Parse(input[1]);
            Depth = int.Parse(input[2]);

            cube = new Cube[Width, Height, Depth];

            InitCube();
            //PrintCube();

            //read ball position
            input = (Console.ReadLine()).Split(' ');
            int ballW = int.Parse(input[0]);
            int ballD = int.Parse(input[1]);
            int[] ballPos = new int[] { ballW, 0, ballD };

            int[] pos;
            while (true)
            {
                pos = cube[ballPos[0], ballPos[1], ballPos[2]].Move(ballPos);
                if (pos == null)
                {
                    // we are in a basket
                    PrintBallPosition(ballPos, false);
                    break;
                }
                else
                {
                    // check where we are
                    // width
                    if (pos[0] >= Width)
                    {
                        if (pos[1] == (Height - 1))
                        {
                            PrintBallPosition(ballPos, true);
                            break;
                        }
                        else
                        {
                            PrintBallPosition(ballPos, false);
                            break;
                        }
                    }
                    // depth
                    if (pos[2] >= Depth)
                    {
                        if (pos[1] == (Height - 1))
                        {
                            PrintBallPosition(ballPos, true);
                            break;
                        }
                        else
                        {
                            PrintBallPosition(ballPos, false);
                            break;
                        }
                    }
                    // height
                    if (pos[1] >= Height)
                    {
                        PrintBallPosition(ballPos, true);
                        break;
                    }

                    ballPos = pos;
                    //PrintBallPosition(ballPos, true);
                    
                    
                }
            }
        }

        private static void PrintBallPosition(int[] ballPos, bool success)
        {
            if(success)
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
            Console.WriteLine("{0} {1} {2}",ballPos[0], ballPos[1], ballPos[2]);
        }


        private static void PrintCube()
        {
            for (int h = 0; h < Height; h++)
            {
                for (int d = 0; d < Depth; d++)
                {
                    for (int w = 0; w < Width; w++)
                    {
                        Console.Write(cube[w, h, d] + " ");
                    }
                    Console.Write(" | ");
                }
                Console.WriteLine();
            }
        }

        private static void InitCube()
        {
            Regex regexDepthSeq = new Regex(@"\s\|\s");
            Regex regexWidthSeq = new Regex(@"\)\(");//(@"\([S,T,E,B]\s[A-Z]{1,2})\");

            string tmp;
            string[] depthSeq;
            string[] widthSeq;
            for (int h = 0; h < Height; h++)
            {
                tmp = Console.ReadLine();
                depthSeq = regexDepthSeq.Split(tmp);
                for (int d = 0; d < depthSeq.Length; d++)
                {
                    widthSeq = regexWidthSeq.Split(depthSeq[d]);
                    for (int w = 0; w < widthSeq.Length; w++)
                    {
                        widthSeq[w] = widthSeq[w].Trim(new char[] { '(', ')' });
                        //Console.Write(widthSeq[w] + ":");
                        cube[w, h, d] = new Cube(widthSeq[w]);
                    }
                    //Console.WriteLine();
                }
            }
        }
    }

    class Cube
    {
        string type;
        int[] move; // w h d 


        public override string ToString()
        {
            if (move == null)
                return String.Format("{0}", type);
            else
                return String.Format("{0}:{1}:{2}:{3}", type, move[0], move[1], move[2]);
        }


        public Cube(string inp)
        {
            string[] input = inp.Split(' ');
            type = input[0];
            if ( type.Equals("S"))
            {
                // SLIDE CUBE
                SlideDirection(input);
            }
            else if (type.Equals("T"))
            {
                // teleport direction
                int w = int.Parse(input[1]);
                int d = int.Parse(input[2]);
                move = new int[] { w, 0, d };
            }
            else if (type.Equals("E"))
            {
                move = new int[] { 0, 1, 0 };
            }
            else if (type.Equals("B"))
            {
                move = null;
            }           
        }

        private void SlideDirection(string[] input)
        {
            if (input[1].Equals("L"))
            {
                //move left
                move = new int[] { -1, 1, 0 };
            }
            else if (input[1].Equals("R"))
            {
                //move right
                move = new int[] { 1, 1, 0 };
            }
            else if (input[1].Equals("F"))
            {
                //move forward
                move = new int[] { 0, 1, -1 };
            }
            else if (input[1].Equals("B"))
            {
                //move backward
                move = new int[] { 0, 1, 1 };
            }
            else if (input[1].Equals("FL"))
            {
                //move front left
                move = new int[] { -1, 1, -1 };
            }
            else if (input[1].Equals("FR"))
            {
                //move front right
                move = new int[] { 1, 1, -1 };
            }
            else if (input[1].Equals("BL"))
            {
                //move back left
                move = new int[] { -1, 1, 1 };
            }
            else if (input[1].Equals("BR"))
            {
                //move back right
                move = new int[] { 1, 1, 1 };
            }
        }

        internal int[] Move(int[] ballPos)
        {
            int[] newPos = new int[]{0,0,0};
            //add new pos
            if (type.Equals("B"))
            {
                return null;
            }
            else if (type.Equals("T"))
            {
                newPos[0] = move[0];
                newPos[1] = ballPos[1];
                newPos[2] = ballPos[2];
                return newPos;
            }
            else
            {
                for (int i = 0; i < ballPos.Length; i++)
                {
                    newPos[i] = ballPos[i] + move[i];
                }
                return newPos;
            }
        }
    }
}
