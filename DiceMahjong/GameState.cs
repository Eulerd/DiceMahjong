using MahjongLib;
using DiceMohjong.Phases;
using DiceMohjong.Players;
using System.Linq;

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
        public int PlayerNum { get; private set; }
        
        public Player ThinkingPlayer { get; private set; }

        public Player[] WaitingPlayers { get; private set; }

        public GameState(Player[] players, WallTiles walltiles)
        {
            this.Players = players;
            this.walltiles = walltiles;

            PlayerNum = 0;
            PlayerStateUpdate();
        }

        void PlayerStateUpdate()
        {
            ThinkingPlayer = Players[PlayerNum];
            WaitingPlayers = (from p in Players
                              where p != Players[PlayerNum]
                              select p).ToArray();
        }

        public Phase Next(Phase now, Tile lasttile)
        {
            // 川に捨てる
            ThinkingPlayer.RemoveTile(lasttile);

            // これ以上自摸れない場合流局
            if (!walltiles.CanDrawing())
                return new ResultPhase();

            PlayerNum = (PlayerNum + 1) % 4;
            PlayerStateUpdate();

            // 山からツモる
            ThinkingPlayer.AddTile(walltiles.Drawing());

            return now;
        }
    }
}
