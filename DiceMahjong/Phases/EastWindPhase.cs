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


        int[] tilekeys =
            {
                    DX.KEY_INPUT_1, DX.KEY_INPUT_2, DX.KEY_INPUT_3, DX.KEY_INPUT_4, DX.KEY_INPUT_5,
                    DX.KEY_INPUT_6, DX.KEY_INPUT_7, DX.KEY_INPUT_8,  DX.KEY_INPUT_9, DX.KEY_INPUT_0,
                    DX.KEY_INPUT_MINUS, DX.KEY_INPUT_PREVTRACK, DX.KEY_INPUT_YEN, DX.KEY_INPUT_SPACE
                    };

        static bool[] pressed = new bool[14];

        void PressedInit()
        {
            for (int i = 0; i < pressed.Length; i++)
                pressed[i] = false;
        }

        public EastWindPhase()
        {
            for (int i = 0; i < 4; i++)
                players[i] = new Player(PlayerStatus.EastPlayer + i, walltiles);

            Count = 0;
            PlayerNum = 0;

            for (int i = 0; i < pressed.Length; i++)
                pressed[i] = false;
        }

        TileNames tile = TileNames.Dots1;

        protected override Phase update()
        {
            // Debug
            string[] ps = { "東", "南", "西", "北" };
            int j;

            DX.DrawGraph(687, PlayerNum * 80 - ((pressed[13]) ? 10 : 0), Form1.TileHandle[(int)players[PlayerNum].MyHandTiles.LastTile], 0);
            for (int i = 0; i < 4; i++)
            {
                DX.DrawString(0, i * 82, ps[(int)players[i].Status], DX.GetColor(255, 255, 255));

                j = 0;
                foreach (var tile in players[i].MyHandTiles.GetAllTiles())
                {
                    DX.DrawGraph(50 + j * 49, i * 80 - ((pressed[j] && PlayerNum == i) ? 10 : 0), Form1.TileHandle[(int)tile], 0);
                    j++;
                }

                j = 0;
                foreach (var tile in players[i].MyDiscardedTiles.GetAllTiles())
                {
                    //DX.DrawGraph(800 + j * 49, i * 80, Form1.TileHandle[(int)tile], 0);
                    int x = 350 + j * 20;
                    int y = 400 + i * 32;
                    DX.DrawExtendGraph(x, y, x + 20, y + 32,Form1.TileHandle[(int)tile], 0);
                    j++;
                }


            }

            DX.DrawString(0, 500, Count.ToString(), DX.GetColor(255, 255, 255));

            DX.DrawGraph(250, 400, Form1.TileHandle[(int)tile], 0);
            // End Debug

            for (int i = 0; i < tilekeys.Length; i++)
            {
                if (key.IsPressed(tilekeys[i]))
                {
                    if(pressed[i])
                    {
                        tile = players[PlayerNum].GetTile(i);
                        players[PlayerNum].SetTile(walltiles.Drawing());

                        Count++;
                        PlayerNum = (PlayerNum + 1) % 4;

                        PressedInit();
                    }
                    else
                    {
                        PressedInit();
                        pressed[i] = true;
                    }
                }
            }

            return this;
        }
    }
}
