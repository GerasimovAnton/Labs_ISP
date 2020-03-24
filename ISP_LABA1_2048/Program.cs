using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;

using Console = Colorful.Console;

namespace ISP_LABA1_2048
{
    class Program
    {
        static void Main(string[] args)
        {
            Program game = new Program();
            game.Start();
        }

        public const int size  = 4;

        //Custom colors
        public Color[] palette = { Color.FromArgb(250,252,192), //2
                                   Color.FromArgb(249,216,83),  //4
                                   Color.FromArgb(249,188,83),  //8
                                   Color.FromArgb(249,133,83),  //16
                                   Color.FromArgb(255,92,74),   //32
                                   Color.FromArgb(255,247,0),   //64
                                   Color.FromArgb(255,0,0),     //128
                                   Color.FromArgb(196,44,130),  //256
                                   Color.FromArgb(245,0,139),   //512
                                   Color.FromArgb(235,219,0),   //1024
                                   Color.FromArgb(81,222,0)};   //2048

        void Start()
        {
            Game g = new Game(size);

            InitizlizeField(g);
            AddRandomValues(g);
            AddRandomValues(g);

            Console.WriteLine("  Press any key to start", Color.Red);

            while (!IsLose(g) && ! IsWin(g))
            {
                #region Alternative Version
                /*
                switch (Console.ReadKey().Key)
                {
                    //или лучше просто передавать Direction в Game.TranslateValues()(сделать puplic)?
                    case ConsoleKey.UpArrow: g.Up(); break;
                    case ConsoleKey.DownArrow: g.Down(); break;
                    case ConsoleKey.RightArrow: g.Right(); break;
                    case ConsoleKey.LeftArrow: g.Left(); break;
                }*/
                #endregion
                
                Direction dir = Direction.Up;

                switch (Console.ReadKey().Key)
                {

                    case ConsoleKey.UpArrow: dir = Direction.Up; break;
                    case ConsoleKey.DownArrow: dir = Direction.Down; break;
                    case ConsoleKey.RightArrow: dir = Direction.Right; break;
                    case ConsoleKey.LeftArrow: dir = Direction.Left; break;
                }


                g.TranslateValues(dir);
                AddRandomValues(g);
                Draw(g);
            }

            if (IsLose(g)) Console.WriteLine("  Wasted", Color.Red);
            if (IsWin(g)) Console.WriteLine("  Сongratulations!", Color.Green);

            Console.ReadLine();
        }


        void InitizlizeField(Game game)
        {
            Field field = game.GetField();
            for (int i = 0; i < size; i++)
                for (int y = 0; y < size; y++)    
                    field.SetValue(i, y, 0);
                    // game.GetField().Set(i, y, 0);
        }
        
        void AddRandomValues(Game game)
        {
            // var list = new List<ValueTuple<int,int>>();
            // list.Add((0, 0));

            Field field = game.GetField();

            if (game.GetField().IsFilledUp()) return;

            Random random = new Random();
            while (true)
            {
                int x = random.Next(0, size);
                int y = random.Next(0, size);

                if (field.GetValue(x, y) == 0)
                {
                    field.SetValue(x, y, random.Next(1, 3) * 2);
                    break;
                }
            }
        }
        
        void Draw(Game game)
        {
            Console.Clear();
            // Console.ForegroundColor = ConsoleColor.Black;


            for (int i = 0; i < size; i++)
            {
                for (int y = 0; y < size; y++)
                {
                    int val = game.GetField().GetValue(y, i);

                    if (val != 0)
                    {
                        Console.Write(string.Format("{0,6}", val), palette[((int)Math.Log(val, 2) - 1) % palette.Length]);
                    }
                    else
                    {
                        //Console.BackgroundColor = ConsoleColor.Black;
                        //Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(string.Format("{0,6}", "-"),Color.DimGray);
                        
                    }
                }
                Console.Write("\n\n");
            }
        }

        bool IsWin(Game game)
        {
            return (game.GetScore() >= 2048);// Console.WriteLine("You Win! "); 
        }

        bool IsLose(Game game)
        {
            return !game.GetField().IsMovable() &&  game.GetField().IsFilledUp();
        }

    }

    class Game
    {
        private Field field;
        private int score;

        public Game(int size)
        {
            field = new Field(size);
        }

        public Field GetField()
        {
            return field;
        }

        public int GetScore()
        {
            return score;
        }

        //Slide
        public void TranslateValues(Direction dir)
        {
            // field.
            //                                                xy
            //Down  start_X = 0 x++ start_Y = max y--  0110 | 01
            //Up    start_X = 0 x++ start_Y = 0 y++    0101 | 01

            //Right  start_X = max x--start_Y = 0 y++  1001 | 10
            //Left  start_X = 0 x++ start_Y = 0 y++    0101 | 10



            int StartPosX = (dir == Direction.Right) ? field.GetSize() - 1 : 0;
            int StartPosY = (dir == Direction.Down) ? field.GetSize() - 1 : 0;


            Func<int, int> XIterator = (dir == Direction.Right) ? new Func<int, int>(t => t - 1)
                                                                : new Func<int, int>(t => t + 1);

            Func<int, int> YIterator = (dir == Direction.Down) ? new Func<int, int>(t => t - 1)
                                                               : new Func<int, int>(t => t + 1);

            int IsVertical = (dir == Direction.Up || dir == Direction.Down) ? 1 : 0;
            int IsHorizontal = (dir == Direction.Left || dir == Direction.Right) ? 1 : 0;// (IsVertical == 0) ? 1 : 0;


            Func<int, int> XFunc = ((x) => IsHorizontal * XIterator(x) + x * IsVertical); //хз как назвать
            Func<int, int> YFunc = ((y) => IsVertical * YIterator(y) + y * IsHorizontal);


            int XMax = (IsVertical == 0) ? field.GetSize() - 1 : field.GetSize();
            int YMax = (IsHorizontal == 0) ? field.GetSize() - 1 : field.GetSize();


            for (int n = 0; n < field.GetSize(); n++)
            {
                for (int x = StartPosX; x != ((StartPosX == 0) ? XMax : 0); x = XIterator(x))
                {
                    for (int y = StartPosY; y != ((StartPosY == 0) ? YMax : 0); y = YIterator(y))
                    {
                        if (field.GetValue(x, y) == 0)
                        {
                            field.SetValue(x, y, field.GetValue(XFunc(x), YFunc(y)));
                            field.SetValue(XFunc(x), YFunc(y), 0);
                        }
                        else if (field.GetValue(x, y) == field.GetValue(XFunc(x), YFunc(y)))
                        {
                            int NewValue = field.GetValue(x, y) * 2;
                            score = (NewValue > score) ? NewValue : score;

                            field.SetValue(x, y, NewValue);
                            field.SetValue(XFunc(x), YFunc(y), 0);
                        }
                    }
                }
            }
        }

        /*
        public void Down()
        {
            TranslateValues(Direction.Down);
        }

        public void Left()
        {
            TranslateValues(Direction.Left);
        }

        public void Right()
        {
            TranslateValues(Direction.Right);
        }

        public void Up()
        {
            TranslateValues(Direction.Up);
        }
        */
    }

    class Field
    {
        
        private int[,] grid;
        private int size;

        public Field(int size)
        {
            if (size > 0)
            {
                this.size = size;
                grid = new int[size, size];
            }
        }

        public int GetSize()
        {
            return size;
        }

        public bool IsFilledUp()
        {
            for (int i = 0; i < size; i++)
            for (int y = 0; y < size; y++)
            if (GetValue(i, y) == 0) return false;
                    
            return true;
        }


        public bool IsMovable()
        {
            for (int i = 0; i < size; i++)
            {
                for (int y = 0; y < size; y++)
                {
                    if (GetValue(i, y) == GetValue(i + 1, y) ||
                        GetValue(i, y) == GetValue(i, y + 1))
                        return true;
                }
            }

            return false;
        }

        public void SetValue(int x, int y, int value)
        {
            if (GetValue(x, y) != -1)
            {
                grid[x, y] = value;
            } // else -?
        }

        public int GetValue(int x, int y)
        {

            if (x > size - 1 || y > size - 1 || x < 0 || y < 0) return -1;//throw new Exception();
            else return grid[x, y];
        }
    }

    enum Direction
    {
            Down,
            Left,
            Right,
            Up
    }
}
