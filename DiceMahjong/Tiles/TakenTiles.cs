using System.Collections.Generic;

namespace MahjongLib
{
    class TakenTile
    {
        TileNames Tile;
        TakenTileStatus Status;
        PlayerStatus Player;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="tile">基準となる牌</param>
        /// <param name="status">鳴いた種類</param>
        /// <param name="player">誰から鳴いたか</param>
        public TakenTile(TileNames tile, TakenTileStatus status, PlayerStatus player)
        {
            Tile = tile;
            Status = status;
            Player = player;
        }

        public List<TileNames> GetTakenTile()
        {
            List<TileNames> tiles = new List<TileNames>();

            switch (Status)
            {
                case TakenTileStatus.Chi:
                    for (int i = 0; i < 3; i++)
                        tiles.Add(Tile + i);
                    break;

                case TakenTileStatus.Pon:
                    for (int i = 0; i < 3; i++)
                        tiles.Add(Tile);
                    break;

                case TakenTileStatus.Kan:
                    for (int i = 0; i < 4; i++)
                        tiles.Add(Tile);
                    break;
            }

            return tiles;
        }
    }
}
