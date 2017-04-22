using System.Collections.Generic;
using MahjongLib;

namespace DiceMohjong
{
    class Player
    {
        /// <summary>
        /// 鳴いた牌リスト
        /// </summary>
        List<TakenTile> MyTakenTiles = new List<TakenTile>();

        /// <summary>
        /// 手牌
        /// </summary>
        public HandTiles MyHandTiles = new HandTiles();

        /// <summary>
        /// 捨て牌
        /// </summary>
        public DiscardedTiles MyDiscardedTiles = new DiscardedTiles();

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
            MyHandTiles.SetFirstTiles(walltiles.FirstDrawing());

            if (status == PlayerStatus.EastPlayer)
                MyHandTiles.SetTile(walltiles.Drawing());
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public TileNames GetTileNumberOf(int index)
        {
            TileNames tile = MyHandTiles.GetTile(index);

            return tile;
        }

        /// <summary>
        /// 牌を打つ
        /// </summary>
        /// <param name="tile">打牌する牌</param>
        public void RemoveTile(TileNames tile)
        {
            // 河に追加
            MyDiscardedTiles.AddTile(tile);

            // 打牌
            MyHandTiles.DiscarTile(tile);
        }

        /// <summary>
        /// 牌を1枚手牌に追加する
        /// </summary>
        /// <param name="tile">手牌に追加する牌</param>
        public void AddTile(TileNames tile)
        {
            MyHandTiles.SetTile(tile);
        }
    }
}
