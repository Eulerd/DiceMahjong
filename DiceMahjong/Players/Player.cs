﻿using System.Collections.Generic;
using MahjongLib;

namespace DiceMohjong.Players
{
    abstract class Player
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

        KeyForTiles key;

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
        /// 打牌する牌を返す
        /// </summary>
        /// <returns></returns>
        public abstract Tile HitTile();
        
        /// <summary>
        /// index番目の牌を取得する
        /// </summary>
        /// <param name="index">番号</param>
        /// <returns>indexの牌</returns>
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
