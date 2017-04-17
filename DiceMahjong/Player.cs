using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiles;

namespace DiceMohjong
{
    class Player
    {
        List<TakenTile> MyTakenTiles = new List<TakenTile>();
        public HandTiles MyHandTiles = new HandTiles();
        public DiscardedTiles MyDiscardedTiles = new DiscardedTiles();

        bool IsReach = false;
        public PlayerStatus Status;

        public Player(PlayerStatus status, WallTiles walltiles)
        {
            Status = status;

            // 配牌
            MyHandTiles.SetTiles(walltiles.FirstDrawing(status));
        }
        
    }
}
