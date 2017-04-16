using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohjongWinTest
{
    class Player
    {
        List<TakenTile> MyTakenTiles = new List<TakenTile>();
        HandTiles MyHandTiles = new HandTiles();
        DiscardedTiles MyDiscardedTiles = new DiscardedTiles();

        bool IsReach = false;
        
    }
}
