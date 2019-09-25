using System;
using System.Diagnostics;
using System.Threading;
using Game;
class Program
{
    static void Main()
    {
        Board newBoard = new Board(100,50);
        newBoard.MakeBoard();
        newBoard.PrintBoard();
        DrawBoard(newBoard, "w");
        // program code goes here
    }

    public static void DrawBoard(Board board, string prevDirection){
        string direction = prevDirection;
        Console.WriteLine(Console.KeyAvailable);
        if(!Console.KeyAvailable){
            Console.WriteLine("if");
            var directionKey = Console.ReadKey(true);
            direction = directionKey.KeyChar.ToString();
            prevDirection = direction;
        }
        board.Move(direction);
        board.MakeBoard();
        board.PrintBoard();
        Thread.Sleep(200);
        DrawBoard(board, prevDirection);
    }


}

