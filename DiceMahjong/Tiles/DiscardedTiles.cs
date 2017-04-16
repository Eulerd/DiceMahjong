using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiles
{
    class DiscardedTiles
    {
        List<KeyValuePair<TileNames, TileStatus>> tiles = new List<KeyValuePair<TileNames, TileStatus>>();

        public void AddTile(TileNames tile)
        {
            tiles.Add(new KeyValuePair<TileNames, TileStatus>(tile, TileStatus.Normal));
        }

        public TileNames TakenTile()
        {
            ChangeStatus(tiles.Count - 1, TileStatus.Taken);

            return tiles.Last().Key;
        }

        public void Reach()
        {
            ChangeStatus(tiles.Count - 1, TileStatus.Reach);
        }

        void ChangeStatus(int index, TileStatus status)
        {
            tiles[index] =
                new KeyValuePair<TileNames, TileStatus>(tiles[index].Key, status);
        }

        enum TileStatus
        {
            Normal,
            Reach,
            Taken,
        }
    }
}
