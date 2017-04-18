using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiles
{
    class WallTiles
    {
        TileNames[] tiles = new TileNames[136];
        int front = 0;
        int kind_front = 132;

        public WallTiles()
        {
            WallInit();
            Shuffing();
        }

        public TileNames[] FirstDrawing(PlayerStatus status)
        {
            TileNames[] tiles;
            int count = 14;

            tiles = new TileNames[count];
            for (int i = 0; i < count; i++)
                tiles[i] = Drawing();

            return tiles;
        }

        public TileNames Drawing()
        {
            front++;

            return tiles[front - 1];
        }

        public TileNames DrawingFromKindWall()
        {
            kind_front++;

            return tiles[kind_front - 1];
        }

        public TileNames[] GetAllFrontDoras()
        {
            TileNames[] doras = new TileNames[4];

            for (int i = 0; i < 4; i++)
                doras[i] = tiles[i + 124];

            return doras;
        }

        public TileNames[] GetAllBackDoras()
        {
            TileNames[] doras = new TileNames[4];

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

                tiles[i] = (TileNames)count;
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
                TileNames tmp = tiles[i];
                tiles[i] = tiles[num];
                tiles[num] = tmp;
            }
        }
    }
}
