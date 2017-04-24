using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahjongLib;
using DiceMohjong.Phases;

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
        /// 牌用キー情報
        /// </summary>
        public KeyForTiles keytiles = new KeyForTiles();

        /// <summary>
        /// 現在アクティブな人
        /// </summary>
        public int PlayerNum;

        public GameState(Player[] players, WallTiles walltiles, KeyForTiles keytiles)
        {
            this.Players = players;
            this.walltiles = walltiles;
            this.keytiles = keytiles;

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
