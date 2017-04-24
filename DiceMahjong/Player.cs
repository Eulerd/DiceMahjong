using System.Collections.Generic;
using MahjongLib;

namespace DiceMohjong
{
    class Player
    {
        /// <summary>
        /// 鳴いた牌リスト
        /// </summary>
        public List<TakenTile> Takens = new List<TakenTile>();

        /// <summary>
        /// 手牌
        /// </summary>
        public HandTiles Hands = new HandTiles();

        /// <summary>
        /// 捨て牌
        /// </summary>
        public DiscardedTiles DiscTiles = new DiscardedTiles();

        /// <summary>
        /// プレイヤーの家
        /// </summary>
        public PlayerStatus Status;

        /// <summary>
        /// プレイヤーの家を設定し、山から配牌をとる
        /// </summary>
        /// <param name="status">何家か</param>
        /// <param name="walltiles">山牌</param>
        public Player(PlayerStatus status, WallTiles walltiles)
        {
            Status = status;

            // 配牌
            Hands.SetFirstTiles(walltiles.FirstDrawing());

            if (status == PlayerStatus.EastPlayer)
                Hands.SetTile(walltiles.Drawing());
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Tile GetTileNumberOf(int index)
        {
            Tile tile = Hands.GetTile(index);

            return tile;
        }

        /// <summary>
        /// 牌を打つ
        /// </summary>
        /// <param name="tile">打牌する牌</param>
        public void RemoveTile(Tile tile)
        {
            // 河に追加
            DiscTiles.AddTile(tile);

            // 打牌
            Hands.DiscarTile(tile);
        }

        /// <summary>
        /// 牌を1枚手牌に追加する
        /// </summary>
        /// <param name="tile">手牌に追加する牌</param>
        public void AddTile(Tile tile)
        {
            Hands.SetTile(tile);
        }
    }
}
