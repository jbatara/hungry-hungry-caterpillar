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
            GameBoard = new char[BoardSize_X,BoardSize_Y];
        }

        public void StartCaterpillarCoords(int x, int y){
            CaterpillarCoords = new int[]{x,y};
            GameBoard[x,y] = '\u0c67';
        }

        public char[,] MakeBoard(){
            for (int row = 0; row < BoardSize_X; row++)
            {
                for (int col = 0; col < BoardSize_Y; col++)
                {
                    GameBoard[row, col] = '\u2591';
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
        }

        public void Move(string directionLetter){
            int x = CaterpillarCoords[0];
            int y = CaterpillarCoords[1];
            if(directionLetter == "a"){
                CaterpillarCoords[0] = (x - 1) % BoardSize_Y;
            } else if (directionLetter == "s"){
                CaterpillarCoords[1] = (y - 1) % BoardSize_X;
            } else if (directionLetter == "d"){
                CaterpillarCoords[0] = (x + 1) % BoardSize_Y;
            } else if (directionLetter == "w"){
                CaterpillarCoords[1] = (y + 1) % BoardSize_X;
            }
        }
    }
}