using System;
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

    public static void DrawBoard(Board board, string direction){
        bool gameOver = board.IsCannibal();
        if(!gameOver){
            while(!Console.KeyAvailable){
                board.Move(direction);
                board.MakeBoard();
                board.PrintBoard();
                Thread.Sleep(100);
                DrawBoard(board, direction);
            }
            var directionKey = Console.ReadKey(true);
            direction = directionKey.KeyChar.ToString();
            board.Move(direction);
            board.MakeBoard();
            board.PrintBoard();
            Thread.Sleep(100);
            DrawBoard(board, direction);
        } else {
            Console.WriteLine("Game Over!");
            System.Environment.Exit(1);
        }
    }


}

