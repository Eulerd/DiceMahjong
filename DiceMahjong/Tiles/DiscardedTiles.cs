using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiles
{
    /// <summary>
    /// 河の牌
    /// </summary>
    class DiscardedTiles
    {
        /// <summary>
        /// 河にある牌リスト
        /// </summary>
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

        public TileNames[] GetAllTiles()
        {
            List<TileNames> tmp_tiles = new List<TileNames>();

            for(int i = 0;i < tiles.Count;i++)
                tmp_tiles.Add(tiles[i].Key);

            return tmp_tiles.ToArray();
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
