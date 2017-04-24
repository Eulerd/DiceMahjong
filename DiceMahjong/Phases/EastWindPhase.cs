using DxLibDLL;
using MahjongLib;

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
        /// 
        /// </summary>
        KeyForTiles keytiles = new KeyForTiles();

        /// <summary>
        /// 現在アクティブな人
        /// </summary>
        int PlayerNum;

        /// <summary>
        /// 配牌を各プレイヤーに渡し、初期化する
        /// </summary>
        public EastWindPhase()
        {
            for (int i = 0; i < 4; i++)
                players[i] = new Player(PlayerStatus.EastPlayer + i, walltiles);
            
            PlayerNum = 0;
        }
        
        /// <summary>
        /// 東風戦のメイン
        /// </summary>
        /// <returns>一局終了するとEndPhaseを投げる</returns>
        protected override Phase update()
        {
            // Debug
            string[] ps = { "東", "南", "西", "北" };

            // アクティブなプレイヤー
            DX.DrawString(0, 450, ps[PlayerNum], DX.GetColor(255, 255, 255));

            // ツモ牌表示
            DX.DrawGraph(687, PlayerNum * 80 - ((keytiles.LastKeyPressed()) ? 10 : 0), Mahjong.TileHandle[(int)players[PlayerNum].Hands.LastTile], 1);

            // 各プレイヤー
            for (int i = 0; i < 4; i++)
            { 
                // 家を表示
                DX.DrawString(0, i * 82, ps[(int)players[i].Status], DX.GetColor(255, 255, 255));

                // 手牌を表示
                int j = 0;
                foreach (var tile in players[i].Hands.GetAllTiles())
                {
                    DX.DrawGraph(50 + j * 49, i * 80 - ((keytiles.pressed[j] && PlayerNum == i) ? 10 : 0), Mahjong.TileHandle[(int)tile], 1);
                    j++;
                }

                // キー名を表示
                j = 0;
                foreach(string keyname in keytiles.tilekeys_name)
                {
                    DX.DrawString(55 + j * 49, 350, keyname, DX.GetColor(255, 255, 255));
                    j++;
                }

                // 河を表示
                j = 0;
                foreach (var tile in players[i].DiscTiles.GetAllTiles())
                {
                    int x = 350 + j * 20;
                    int y = 400 + i * 32;
                    DX.DrawExtendGraph(x, y, x + 20, y + 32,Mahjong.TileHandle[(int)tile], 1);
                    j++;
                }
            }

            // 山から何枚ツモされたか
            DX.DrawString(0, 500, walltiles.Count.ToString(), DX.GetColor(255, 255, 255));
            // End Debug

            for (int i = 0; i < Mahjong.HandTileCount; i++)
            {
                if(keytiles.IsKeyByUpdate(key, i))
                {
                    Tile lasttile = players[PlayerNum].GetTileNumberOf(i);
                    // 川に捨てる
                    players[PlayerNum].RemoveTile(lasttile);

                    // これ以上自摸れない場合流局
                    if (!walltiles.CanDrawing())
                        return new ResultPhase();

                    PlayerNum = (PlayerNum + 1) % 4;
                    
                    // 山からツモる
                    players[PlayerNum].AddTile(walltiles.Drawing());
                }
            }

            return this;
        }
    }
}
