using MahjongLib;
using DiceMohjong.Players;

namespace DiceMohjong.Phases
{
    /// <summary>
    /// 東風戦フェーズ
    /// </summary>
    class EastWindPhase : Phase
    {
        GameState state;

        TableDrawer drawer;

        /// <summary>
        /// 配牌を各プレイヤーに渡し、初期化する
        /// </summary>
        public EastWindPhase()
        {
            WallTiles walltiles = new WallTiles();
            Player[] players = new Player[4];
            for (int i = 0; i < 4; i++)
                players[i] = new Player(PlayerStatus.EastPlayer + i, walltiles);

            state = new GameState(players, walltiles);
        }

        /// <summary>
        /// 東風戦のメイン
        /// </summary>
        /// <returns>一局終了するとEndPhaseを投げる</returns>
        protected override Phase update()
        {
            drawer = new TableDrawer(state);

            drawer.Draw(key);
            

            for (int i = 0; i < Mahjong.HandTileCount; i++)
            {
                if (key.IsKeyByUpdate(i))
                {
                    return state.Next(this, i);
                }
            }

            return this;
        }
    }
}
