using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohjongWinTest
{
    class Program
    {

        static void Main(string[] args)
        {
            int[] hands = { 8, 8, 8, 14, 15, 16, 19, 20, 21, 21, 22, 23, 30, 30 };

            HandTiles mytiles = new HandTiles(hands);

            if (mytiles.IsWinningHand())
                Console.WriteLine("[あがり]");
            else
                Console.WriteLine("![あがり]");

            WallTiles wt = new WallTiles();

            Console.WriteLine(wt.ToString());


        }

        static void PrintTiles(int[] tiles)
        {

            for (int i = 0; i < tiles.Length; i++)
            {
                if (i > 0)
                    Console.Write(" ");
                Console.Write(tiles[i]);
            }
            Console.WriteLine();
        }
    }
}
