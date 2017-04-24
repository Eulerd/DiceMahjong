using DxLibDLL;
using System.Linq;
using MahjongLib;

namespace DiceMohjong.Phases
{
    /// <summary>
    /// 東風戦フェーズ
    /// </summary>
    class EastWindPhase : Phase
    {
        GameState state;

        /// <summary>
        /// 配牌を各プレイヤーに渡し、初期化する
        /// </summary>
        public EastWindPhase()
        {
            WallTiles walltiles = new WallTiles();
            Player[] players = new Player[4];
            for (int i = 0; i < 4; i++)
                players[i] = new Player(PlayerStatus.EastPlayer + i, walltiles);

            state = new GameState(players, walltiles, new KeyForTiles());
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
            DX.DrawString(0, 450, ps[state.PlayerNum], DX.GetColor(255, 255, 255));

            // ツモ牌表示
            DX.DrawGraph(687, state.PlayerNum * 80 - ((state.keytiles.LastKeyPressed()) ? 10 : 0), Mahjong.TileHandle[(int)state.Players[state.PlayerNum].Hands.LastTile], 1);

            // 各プレイヤー
            for (int i = 0; i < 4; i++)
            {
                // 家を表示
                DX.DrawString(0, i * 82, ps[(int)state.Players[i].Status], DX.GetColor(255, 255, 255));

                // 手牌を表示
                int j = 0;
                foreach (var tile in state.Players[i].Hands.GetAllTiles())
                {
                    DX.DrawGraph(50 + j * 49, i * 80 - ((state.keytiles.pressed[j] && state.PlayerNum == i) ? 10 : 0), Mahjong.TileHandle[(int)tile], 1);
                    j++;
                }

                // キー名を表示
                j = 0;
                foreach (string keyname in state.keytiles.tilekeys_name)
                {
                    DX.DrawString(55 + j * 49, 350, keyname, DX.GetColor(255, 255, 255));
                    j++;
                }

                // 河を表示
                j = 0;
                foreach (var tile in state.Players[i].DiscTiles.GetAllTiles())
                {
                    int x = 350 + j * 20;
                    int y = 400 + i * 32;
                    DX.DrawExtendGraph(x, y, x + 20, y + 32, Mahjong.TileHandle[(int)tile], 1);
                    j++;
                }
            }

            // 山から何枚ツモされたか
            //DX.DrawString(0, 500, walltiles.Count.ToString(), DX.GetColor(255, 255, 255));
            // End Debug

            for (int i = 0; i < Mahjong.HandTileCount; i++)
            {
                if (state.keytiles.IsKeyByUpdate(key, i))
                {
                    return state.Next(this, i);
                }
            }


            return this;
        }
    }
}
