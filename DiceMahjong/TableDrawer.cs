using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;
using MahjongLib;

namespace DiceMohjong
{
    class TableDrawer
    {
        GameState State;

        public TableDrawer(GameState state)
        {
            State = state;
        }

        public void Draw()
        {
            int now = State.PlayerNum;
            bool UpTile = State.keytiles.LastKeyPressed();
            
            // Debug
            string[] ps = { "東", "南", "西", "北" };

            // アクティブなプレイヤー
            DX.DrawString(0, 450, ps[now], DX.GetColor(255, 255, 255));

            // ツモ牌表示
            DX.DrawGraph(687, now * 80 - ((UpTile) ? 10 : 0), Mahjong.TileHandle[(int)State.Players[now].Hands.LastTile], 1);

            // 各プレイヤー
            for (int i = 0; i < 4; i++)
            {
                // 家を表示
                DX.DrawString(0, i * 82, ps[(int)State.Players[i].Status], DX.GetColor(255, 255, 255));

                // 手牌を表示
                int j = 0;
                foreach (var tile in State.Players[i].Hands.GetAllTiles())
                {
                    DX.DrawGraph(50 + j * 49, i * 80 - ((State.keytiles.pressed[j] && now == i) ? 10 : 0), Mahjong.TileHandle[(int)tile], 1);
                    j++;
                }

                // キー名を表示
                j = 0;
                foreach (string keyname in State.keytiles.tilekeys_name)
                {
                    DX.DrawString(55 + j * 49, 350, keyname, DX.GetColor(255, 255, 255));
                    j++;
                }

                // 河を表示
                j = 0;
                foreach (var tile in State.Players[i].DiscTiles.GetAllTiles())
                {
                    int x = 350 + j * 20;
                    int y = 400 + i * 32;
                    DX.DrawExtendGraph(x, y, x + 20, y + 32, Mahjong.TileHandle[(int)tile], 1);
                    j++;
                }
            }

            // 山から何枚ツモされたか
            DX.DrawString(0, 500, State.walltiles.Count.ToString(), DX.GetColor(255, 255, 255));
            // End Debug
        }
    }
}
