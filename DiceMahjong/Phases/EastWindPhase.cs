using Tiles;
using DxLibDLL;

namespace DiceMohjong.Phases
{
    /// <summary>
    /// 東風戦フェーズ
    /// </summary>
    class EastWindPhase : Phase
    {
        /// <summary>
        /// 各プレイヤー用()
        /// </summary>
        Player[] players = new Player[4];

        /// <summary>
        /// 山牌
        /// </summary>
        WallTiles walltiles = new WallTiles();

        /// <summary>
        /// 現在アクティブな人
        /// </summary>
        int PlayerNum;

        /// <summary>
        /// 牌を切るためのキー配列
        /// </summary>
        int[] tilekeys =
            {
                    DX.KEY_INPUT_1, DX.KEY_INPUT_2, DX.KEY_INPUT_3, DX.KEY_INPUT_4, DX.KEY_INPUT_5,
                    DX.KEY_INPUT_6, DX.KEY_INPUT_7, DX.KEY_INPUT_8,  DX.KEY_INPUT_9, DX.KEY_INPUT_0,
                    DX.KEY_INPUT_MINUS, DX.KEY_INPUT_PREVTRACK, DX.KEY_INPUT_YEN, DX.KEY_INPUT_SPACE
                    };

        /// <summary>
        /// 牌を切るためのキーが前に押されているか
        /// </summary>
        static bool[] pressed = new bool[14];

        /// <summary>
        /// pressed配列の初期化
        /// </summary>
        void PressedInit()
        {
            for (int i = 0; i < pressed.Length; i++)
            {
                pressed[i] = false;
            }
        }

        /// <summary>
        /// 配牌を各プレイヤーに渡し、初期化する
        /// </summary>
        public EastWindPhase()
        {
            for (int i = 0; i < 4; i++)
                players[i] = new Player(PlayerStatus.EastPlayer + i, walltiles);
            
            PlayerNum = 0;

            for (int i = 0; i < pressed.Length; i++)
                pressed[i] = false;
        }

        /// <summary>
        /// デバッグ用牌
        /// </summary>
        TileNames tile = TileNames.Dots1;

        /// <summary>
        /// 東風戦のメイン
        /// </summary>
        /// <returns>一局終了するとEndPhaseを投げる</returns>
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

            DX.DrawString(0, 500, walltiles.Count.ToString(), DX.GetColor(255, 255, 255));

            DX.DrawGraph(250, 400, Form1.TileHandle[(int)tile], 0);
            // End Debug

            for (int i = 0; i < tilekeys.Length; i++)
            {
                if (key.IsPressed(tilekeys[i]))
                {
                    if(pressed[i])
                    {
                        tile = players[PlayerNum].GetTileNumberOf(i);
                        players[PlayerNum].AddTile(walltiles.Drawing());

                        PlayerNum = (PlayerNum + 1) % 4;

                        PressedInit();
                        pressed[13] = true;
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
