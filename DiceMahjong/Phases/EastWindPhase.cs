using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiles;
using DxLibDLL;

namespace DiceMohjong.Phases
{
    class EastWindPhase : Phase
    {
        Player[] players = new Player[4];
        WallTiles walltiles = new WallTiles();

        public EastWindPhase()
        {
            for(int i = 0;i < 4;i++)
                players[i] = new Player(PlayerStatus.EastPlayer + i, walltiles);
        }

        protected override Phase update()
        {
            string[] ps = { "東", "南", "西", "北" };
            for(int i = 0;i < 4;i++)
            {
                DX.DrawString(0, i * 72, ps[(int)players[i].Status], DX.GetColor(255,255,255));

                TileNames[] tiles = players[i].MyHandTiles.GetAllTiles();
                for(int j = 0;j < tiles.Length;j++)
                {
                    int tilenum = (int)tiles[j];
                    for(int k = 0;k < 3;k++)
                    {
                        if (tilenum > (10 * (k + 1)))
                            tilenum--;
                    }

                    DX.DrawGraph(50 + j * 49, i * 72, Form1.TileHandle[tilenum], 0);
                }

                //DX.DrawString(50, i * 50, players[i].MyHandTiles.ToString(), DX.GetColor(255, 255, 255));
            }

            return this;
        }
    }
}
