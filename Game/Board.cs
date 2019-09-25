using System;
using System.Collections.Generic;

namespace Game
{
    class Board {
        public int BoardSize_X { get; set;}
        public int BoardSize_Y { get; set; }
        public char[,] GameBoard { get; set; }
        public int[] CaterpillarCoords { get; set;}
        public Board(int x, int y){
            BoardSize_X = x;
            BoardSize_Y = y;
            GameBoard = new char[BoardSize_Y,BoardSize_X];
            CaterpillarCoords = new int[]{49,99};
        }

        public char[,] MakeBoard(){
            for (int row = 0; row < BoardSize_Y; row++)
            {
                for (int col = 0; col < BoardSize_X; col++)
                {
                    if (col == CaterpillarCoords[1] && row == CaterpillarCoords[0])
                    {
                        GameBoard[row, col] = '\u0c67';
                    } else {
                        GameBoard[row, col] = '\u2591';
                    }
                }
            }
            return GameBoard;
        }

        public void PrintBoard(){
            for(int row = 0; row < GameBoard.GetLength(0); row++){
                string line = "";
                for(int col = 0; col < GameBoard.GetLength(1); col++){
                    line += GameBoard[row,col];
                }
                Console.WriteLine(line);
            }
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public void Move(string directionLetter){
            int x = CaterpillarCoords[1];
            int y = CaterpillarCoords[0];
            if(directionLetter == "a"){
                CaterpillarCoords[1] = (x - 1) > 0 ? (x - 1) % BoardSize_X : ((x - 1) % BoardSize_X)+BoardSize_X;
            } else if (directionLetter == "s"){
                CaterpillarCoords[0] = (y + 1) % BoardSize_Y;
            } else if (directionLetter == "d"){
                CaterpillarCoords[1] = (x + 1) % BoardSize_X;
            } else if (directionLetter == "w"){
                CaterpillarCoords[0] = (y - 1) > 0 ? (y - 1) % BoardSize_Y : ((y - 1) % BoardSize_Y) + BoardSize_Y;
            }
            Console.WriteLine("x " + x + ", y " + y);
        }
    }
}