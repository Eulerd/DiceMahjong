using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohjongWinTest
{
    class WallTiles
    {
        int[] tiles = new int[136];
        int front = 0;
        int dead_front = 132;

        public WallTiles()
        {
            WallInit();
            Shuffing();
        }

        public int Drawing()
        {
            front++;

            return tiles[front - 1];
        }

        public int DrawingFromDeadWall()
        {
            dead_front++;

            return tiles[dead_front - 1];
        }

        public int[] GetAllFrontDoras()
        {
            int[] doras = new int[4];

            for (int i = 0; i < 4; i++)
                doras[i] = tiles[i + 124];

            return doras;
        }

        public int[] GetAllBackDoras()
        {
            int[] doras = new int[4];

            for (int i = 0; i < 4; i++)
                doras[i] = tiles[i + 128];

            return doras;
        }

        public override string ToString()
        {
            string S = "";
            for(int i = 0;i < tiles.Length;i++)
            {
                if (i > 0)
                    S += " ";
                S += tiles[i];
            }
            return S;
        }

        void WallInit()
        {
            int count = 0;
            for (int i = 0; i < tiles.Length; i++)
            {
                if (i % 4 == 0)
                    count++;

                if (count % 10 == 0)
                    count++;

                tiles[i] = count;
            }
        }

        void Shuffing()
        {
            Random rand;

            for(int i = 0;i < tiles.Length;i++)
            {
                rand = new Random(i + DateTime.Now.Millisecond);
                int num = rand.Next(136);

                // swap
                int tmp = tiles[i];
                tiles[i] = tiles[num];
                tiles[num] = tiles[i];
            }
        }
    }
}
