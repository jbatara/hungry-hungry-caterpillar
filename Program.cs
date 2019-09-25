using System;
using Game;
class Program
{
    static void Main()
    {
        Board newBoard = new Board(50,100);
        newBoard.MakeBoard();
        newBoard.StartCaterpillarCoords(49,99);
        newBoard.PrintBoard();
        // program code goes here
    }
}

