using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    class Board {
        public int BoardSize_X { get; set;}
        public int BoardSize_Y { get; set; }
        public string[,] GameBoard { get; set; }
        public List<int[]> CaterpillarCoords { get; set;}
        public List<int[]> FoodCoords { get; set; }
        public int FoodEaten { get; set; }
        public string Direction { get; set; }
        public Board(int x, int y){
            BoardSize_X = x;
            BoardSize_Y = y;
            GameBoard = new string[BoardSize_Y,BoardSize_X];
            CaterpillarCoords = new List<int[]>{new int[]{BoardSize_Y-1,BoardSize_X-1}};
            FoodCoords = new List<int[]>();
        }

        public string[,] MakeBoard()
        {
            for (int row = 0; row < BoardSize_Y; row++)
            {
                for (int col = 0; col < BoardSize_X; col++)
                {
                    GameBoard[row, col] = '\u2591'.ToString();
                }
            }
            AddCaterpillar();
            GenerateFood();
            AddFood();
            return GameBoard;
        }

        public void GenerateFood()
        {
            for(int i = 0; i < 5; i++)
            {
                bool noCat = false;
                if(FoodCoords.ElementAtOrDefault(i) == null)
                {
                    while(!noCat){
                        Random random = new Random();
                        int randNumX = random.Next(0,BoardSize_X);
                        int randNumY = random.Next(0, BoardSize_Y);
                        Console.WriteLine("random" + randNumX + ", " + randNumY);
                        int[] coords = new int[]{ randNumX, randNumY };
                        if(!CaterpillarCoords.Contains(coords))
                        {
                            FoodCoords.Add(coords);
                            noCat = true;
                        }

                    }
                }
            }
        }

        public void AddFood()
        {
            for (int coordPair = 0; coordPair < FoodCoords.Count; coordPair++)
            {
                GameBoard[FoodCoords[coordPair][1], FoodCoords[coordPair][0]] = "\u1bfd";
            }
        }

        public void AddCaterpillar()
        {
            for(int coordPair = 0; coordPair < CaterpillarCoords.Count; coordPair++)
            {
                if(coordPair == 0)
                {
                    GameBoard[CaterpillarCoords[0][0], CaterpillarCoords[0][1]] = '\u0c67'.ToString();
                } else {
                    GameBoard[CaterpillarCoords[coordPair][0], CaterpillarCoords[coordPair][1]] = '\u0c66'.ToString();
                }
            }
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
            GrowCaterpillar();
            int x = CaterpillarCoords[0][1];
            int y = CaterpillarCoords[0][0];
            if(directionLetter == "a"){
                CaterpillarCoords[0][1] = (x - 1) >= 0 ? (x - 1) % BoardSize_X : (x - 1)+BoardSize_X;
            } else if (directionLetter == "s"){
                CaterpillarCoords[0][0] = (y + 1) % BoardSize_Y;
            } else if (directionLetter == "d"){
                CaterpillarCoords[0][1] = (x + 1) % BoardSize_X;
            } else if (directionLetter == "w"){
                CaterpillarCoords[0][0] = (y - 1) >= 0 ? (y - 1) % BoardSize_Y : (y - 1) + BoardSize_Y;
            }
            CaterpillarCoords.Insert(1,new int[]{y,x});
            CaterpillarCoords.Remove(CaterpillarCoords[CaterpillarCoords.Count-1]);
            Direction = directionLetter;
        }

        public bool IsFoodEaten(){
            bool isEaten = false;
            
            foreach(int[] coords in FoodCoords){
                if(coords.SequenceEqual(new int[] { CaterpillarCoords[0][1], CaterpillarCoords[0][0] })){
                    Console.WriteLine("Check if Eaten!");
                    isEaten = true;
                    int index = FoodCoords.IndexOf(coords);
                    Console.WriteLine(index);
                    FoodCoords.RemoveAt(index);
                    FoodEaten++;
                    break;
                }
            }
            return isEaten;
        }

        public void GrowCaterpillar(){
            int[] lastCoord = CaterpillarCoords[CaterpillarCoords.Count-1];
            int x = lastCoord[1];
            int y = lastCoord[0];
            if(IsFoodEaten()){
                if(Direction == "a"){
                    x += 1;
                } else if (Direction == "s"){
                    y -= 1;
                } else if (Direction == "d"){
                    x -= 1;
                } else if(Direction == "w"){
                    y += 1;
                }
                x = x >= 0 ? x % BoardSize_X : x + BoardSize_X;
                y = y >= 0 ? y % BoardSize_Y : y + BoardSize_Y;

                CaterpillarCoords.Add(new int[]{y,x});
            }
        }
    }
}