using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahjongLib;

namespace DiceMohjong.Players
{
    class KeyboardPlayer : Player
    {
        public KeyboardPlayer(PlayerStatus status, WallTiles walltiles) : base(status, walltiles)
        { }
        
        public override Tile HitTile()
        {
            
            for (int i = 0; i < Mahjong.HandTileCount; i++)
            {
                if (GameState.key.IsKeyByUpdate(i))
                {
                    return GetTileNumberOf(i);
                }
            }

            return Tile.Null;
        }
    }
}
