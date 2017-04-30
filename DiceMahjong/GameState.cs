using MahjongLib;
using DiceMohjong.Phases;
using DiceMohjong.Players;

namespace DiceMohjong
{
    class GameState
    {
        /// <summary>
        /// 各プレイヤー用()
        /// </summary>
        public Player[] Players = new Player[4];

        /// <summary>
        /// 山牌
        /// </summary>
        public WallTiles walltiles = new WallTiles();

        /// <summary>
        /// 現在アクティブな人
        /// </summary>
        public int PlayerNum;

        public GameState(Player[] players, WallTiles walltiles)
        {
            this.Players = players;
            this.walltiles = walltiles;

            PlayerNum = 0;
        }

        public Phase Next(Phase now, int last)
        {
            Tile lasttile = Players[PlayerNum].GetTileNumberOf(last);
            // 川に捨てる
            Players[PlayerNum].RemoveTile(lasttile);

            // これ以上自摸れない場合流局
            if (!walltiles.CanDrawing())
                return new ResultPhase();
            
            PlayerNum = (PlayerNum + 1) % 4;

            // 山からツモる
            Players[PlayerNum].AddTile(walltiles.Drawing());

            return now;
        }
    }
}
