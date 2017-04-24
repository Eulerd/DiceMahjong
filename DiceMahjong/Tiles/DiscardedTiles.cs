using System.Collections.Generic;
using System.Linq;

namespace MahjongLib
{
    /// <summary>
    /// 河の牌
    /// </summary>
    class DiscardedTiles
    {
        /// <summary>
        /// 河にある牌リスト
        /// </summary>
        List<KeyValuePair<Tile, TileStatus>> tiles = new List<KeyValuePair<Tile, TileStatus>>();

        public void AddTile(Tile tile)
        {
            tiles.Add(new KeyValuePair<Tile, TileStatus>(tile, TileStatus.Normal));
        }

        public Tile TakenTile()
        {
            ChangeStatus(tiles.Count - 1, TileStatus.Taken);

            return tiles.Last().Key;
        }

        public Tile[] GetAllTiles()
        {
            List<Tile> tmp_tiles = new List<Tile>();

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
                new KeyValuePair<Tile, TileStatus>(tiles[index].Key, status);
        }

        enum TileStatus
        {
            Normal,
            Reach,
            Taken,
        }
    }
}
