using System;

namespace MahjongLib
{
    class TakenTile
    {
        /// <summary>
        /// 自分の家と鳴いた家から鳴いた方向を調べる
        /// </summary>
        /// <param name="MyStatus">自分の家</param>
        /// <param name="OppStatus">鳴いた家</param>
        /// <returns>鳴いた方向</returns>
        static public TakenFrom GetPosition(PlayerStatus MyStatus, PlayerStatus OppStatus)
        {
            int count = 0;
            int i = (int)MyStatus;

            while (i != (int)OppStatus)
            {
                i = (i + 1) % 4;
                count++;
            }

            return (TakenFrom)(count - 1);
        }
        
        /// <summary>
        /// 基準のとなる牌
        /// </summary>
        Tile BaseTile;

        /// <summary>
        /// 鳴いた牌
        /// </summary>
        Tile TileTaken;

        /// <summary>
        /// 鳴きの種類
        /// </summary>
        TakenTileStatus TileStatus;

        /// <summary>
        /// 誰から鳴いたか
        /// </summary>
        TakenFrom BaseStatus;

        /// <summary>
        /// 値を細かく設定する(主にチーの時に用いる)
        /// </summary>
        /// <param name="mysta">自分の家</param>
        /// <param name="oppsta">鳴いた人の家</param>
        /// <param name="baset">基準牌</param>
        /// <param name="takent">鳴いた牌</param>
        /// <param name="status">鳴きの種類</param>
        public TakenTile(PlayerStatus mysta, PlayerStatus oppsta, Tile baset, Tile takent, TakenTileStatus status)
        {
            BaseStatus = GetPosition(mysta, oppsta);
            BaseTile = baset;
            TileTaken = takent;
            TileStatus = status;
        }

        /// <summary>
        /// 値を細かく設定する(主にチーの時に用いる)
        /// </summary>
        /// <param name="basestatus">誰から鳴いたか</param>
        /// <param name="baset">基準牌</param>
        /// <param name="takent">鳴いた牌</param>
        /// <param name="status">鳴きの種類</param>
        public TakenTile(TakenFrom basestatus, Tile baset, Tile takent, TakenTileStatus status)
        {
            BaseStatus = basestatus;
            BaseTile = baset;
            TileTaken = takent;
            TileStatus = status;
        }

        /// <summary>
        /// ポンとカンの場合に用いる
        /// </summary>
        /// <param name="basestatus">誰から鳴いたか</param>
        /// <param name="baset">基準牌</param>
        /// <param name="status">鳴きの種類(ポン,カン)</param>
        public TakenTile(TakenFrom basestatus, Tile baset, TakenTileStatus status)
        {
            if (status == TakenTileStatus.Chow)
                throw new ArgumentException();

            BaseStatus = basestatus;
            TileStatus = status;
            BaseTile = baset;
            TileTaken = baset;
        }
    }
}
