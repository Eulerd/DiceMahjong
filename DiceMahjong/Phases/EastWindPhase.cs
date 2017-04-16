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
        int Count;
        int PlayerNum;

        public EastWindPhase()
        {
            for (int i = 0; i < 4; i++)
                players[i] = new Player(PlayerStatus.EastPlayer + i, walltiles);

            Count = 0;
            PlayerNum = 0;
        }

        TileNames tile = TileNames.Dots1;

        protected override Phase update()
        {
            List<TileNames>[] tiles = new List<TileNames>[4];

            // Debug
            string[] ps = { "東", "南", "西", "北" };
            for (int i = 0; i < 4; i++)
            {
                DX.DrawString(0, i * 72, ps[(int)players[i].Status], DX.GetColor(255, 255, 255));

                tiles[i] = new List<TileNames>();
                tiles[i].AddRange(players[i].MyHandTiles.GetAllTiles());
                for (int j = 0; j < tiles[i].Count; j++)
                {
                    DX.DrawGraph(50 + j * 49, i * 72, Form1.TileHandle[(int)tiles[i][j]], 0);
                }
            }

            DX.DrawString(0, 500, Count.ToString(), DX.GetColor(255, 255, 255));

            DX.DrawGraph(250, 400, Form1.TileHandle[(int)tile], 0);
            // End Debug

            // 親が捨てる
            if (Count % 2 == 0)
            {
                for (int i = 0; i < 14; i++)
                {
                    if (key.IsPressed((i == (tiles[PlayerNum].Count - 1)) ? DX.KEY_INPUT_SPACE : (DX.KEY_INPUT_1 + i)))
                    {
                        tile = tiles[PlayerNum][i];
                        players[PlayerNum].MyHandTiles.DiscarTile(tile);

                        Count++;
                        PlayerNum++;
                        PlayerNum %= 4;
                    }
                }
            }
            else
            {
                players[PlayerNum].MyHandTiles.SetTile(walltiles.Drawing());
                Count++;
            }

            return this;
        }
    }
}
