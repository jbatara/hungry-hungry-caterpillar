using System;
using System.Diagnostics;
using System.Threading;
using Game;
class Program
{
    static void Main()
    {
        Board newBoard = new Board(50,100);
        newBoard.MakeBoard();
        newBoard.StartCaterpillarCoords(49,99);
        newBoard.PrintBoard();
        DrawBoard(newBoard, "w");
        // program code goes here
    }

    public static void DrawBoard(Board board, string prevDirection){
        Stopwatch timer = new Stopwatch();
        timer.Start();
        bool elapsedTimer = false;
        string direction = "w";
        while(timer.ElapsedMilliseconds < 2000 && elapsedTimer == false){
            if(timer.ElapsedMilliseconds > 2000){
                elapsedTimer = true;
            }
            var directionKey = Console.ReadKey(true);
            direction = directionKey.KeyChar.ToString();
            board.Move(direction);
            prevDirection = direction;
        }
        if(elapsedTimer){
            board.Move(prevDirection);
        }
        board.PrintBoard();
        DrawBoard(board, prevDirection);
    }


}

