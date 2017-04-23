using System;
using System.Collections.Generic;
using System.Linq;

namespace MahjongLib
{
    class HandTiles
    {
        /// <summary>
        /// どの牌が何枚あるか
        /// </summary>
        int[] tiletypes = new int[38];

        /// <summary>
        /// 自摸した牌
        /// </summary>
        public TileNames LastTile { get; private set; }

        public int TileCount
        {
            get
            {
                int c = 0;

                for (int i = 0; i < tiletypes.Length; i++)
                    c += tiletypes[i];

                return c;
            }
            private set
            {
                TileCount = value;
            }
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public HandTiles()
        {
            for (int i = 0; i < tiletypes.Length; i++)
                tiletypes[i] = 0;

            LastTile = TileNames.Null;
        }

        /// <summary>
        /// 手牌リストから初期化する
        /// </summary>
        /// <param name="hands">元になる手牌</param>
        public HandTiles(TileNames[] hands)
        {
            for (int i = 0; i < hands.Length - 1; i++)
                tiletypes[(int)hands[i]]++;

            LastTile = hands.Last();
        }

        /// <summary>
        /// 他のクラスを元に作成する
        /// </summary>
        /// <param name="t">元になるクラス</param>
        public HandTiles(HandTiles t)
        {
            for (int i = 0; i < t.tiletypes.Length; i++)
                tiletypes[i] = t.tiletypes[i];

            LastTile = t.LastTile;
        }

        /// <summary>
        /// 自摸する
        /// </summary>
        /// <param name="tile">自摸する牌</param>
        public void SetTile(TileNames tile)
        {
            if (LastTile != TileNames.Null)
                throw new ArgumentException("打牌される前に自摸されています。");

            LastTile = tile;
        }

        /// <summary>
        /// 指定の場所の手牌を取得する
        /// </summary>
        /// <param name="index">取得する手牌の番号</param>
        /// <returns>取得した牌</returns>
        public TileNames GetTile(int index)
        {
            if (index == 13)
                return LastTile;

            int count = 0;
            for(int i = 0;i < tiletypes.Length;i++)
            {
                for(int j = 0;j < tiletypes[i];j++)
                {
                    if (index == count)
                        return (TileNames)i;

                    count++;
                }
            }

            throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        /// 配牌を手牌に追加する
        /// </summary>
        /// <param name="tiles">元になる牌配列</param>
        public void SetFirstTiles(TileNames[] tiles)
        {
            for (int i = 0; i < tiles.Length; i++)
                tiletypes[(int)tiles[i]]++;
        }

        /// <summary>
        /// 牌を1枚捨てる
        /// </summary>
        /// <param name="tile">捨てる牌</param>
        public void DiscarTile(TileNames tile)
        {
            // 自摸牌分追加する
            tiletypes[(int)LastTile]++;
            LastTile = TileNames.Null;

            tiletypes[(int)tile]--;
        }

        /// <summary>
        /// 手牌を取得する
        /// </summary>
        /// <returns>手牌</returns>
        public TileNames[] GetAllTiles()
        {
            List<TileNames> tiles = new List<TileNames>();

            for(int i = 0;i < tiletypes.Length;i++)
            {
                if(tiletypes[i] != 0)
                {
                    for (int j = 0; j < tiletypes[i]; j++)
                        tiles.Add((TileNames)i);
                }
            }

            return tiles.ToArray();
        }

        /// <summary>
        /// この手牌でポンできるか
        /// </summary>
        /// <param name="tile">ポンできるか調べる牌</param>
        /// <returns>ポンできるか</returns>
        public bool CanPon(TileNames tile)
        {
            return (tiletypes[(int)tile] >= 2);
        }

        /// <summary>
        /// この手牌でカンできるか
        /// </summary>
        /// <param name="tile">カンできるか調べる牌</param>
        /// <returns>カンできるか</returns>
        public bool CanKan(TileNames tile)
        {
            return (tiletypes[(int)tile] >= 3);
        }

        /// <summary>
        /// この手牌でチーできるか
        /// </summary>
        /// <param name="tile">チーできるか調べる牌</param>
        /// <returns>チーできるか</returns>
        public bool CanChow(TileNames tile)
        {
            if (TileNames.East <= tile)
                return false;


            int i = (int)tile % 10;
            bool flag = false;

            if (!flag && 1 <= i && i <= 7)
                flag = (tiletypes[i + 1] > 0 && tiletypes[i + 2] > 0);

            if (!flag && 2 <= i && i <= 8)
                flag = (tiletypes[i - 1] > 0 && tiletypes[i + 1] > 0);

            if (!flag && 3 <= i && i <= 9)
                flag = (tiletypes[i - 2] > 0 && tiletypes[i - 1] > 0);

            return flag;
        }

        /// <summary>
        /// あがれる手牌か
        /// </summary>
        /// <returns>あがれるか</returns>
        public bool IsWinningHand()
        {
            HandTiles tmp_tiletypes = new HandTiles(this);

            if (IsZeroAllTiles())
                return false;

            // 七対子判定
            for(int i = 1;i < 38;i++)
            {
                if(tmp_tiletypes[i] >= 2)
                {
                    tmp_tiletypes[i] -= 2;
                    i--;
                }
            }
            if (tmp_tiletypes.IsZeroAllTiles())
                return true;

            // 国士無双判定
            tmp_tiletypes = new HandTiles(this);
            if(tmp_tiletypes.IsKokushi())
                return true;

            for (int i = 1; i < 38; i++)
            {
                // 初期化
                tmp_tiletypes = new HandTiles(this);

                // 頭雀を含むか
                if (tmp_tiletypes[i] >= 2)
                {
                    tmp_tiletypes[i] -= 2;

                    for (int j = 1; j < 38; j++)
                    {
                        // 刻子を含むか
                        if (tmp_tiletypes[j] >= 3)
                        {
                            tmp_tiletypes[j] -= 3;

                            j = 1;
                        }
                    }

                    for (int j = 1; j < 38; j++)
                    {
                        // 順子を含むか
                        if (tmp_tiletypes.ContainsChow((TileNames)j))
                        {
                            tmp_tiletypes[j]--;
                            tmp_tiletypes[j + 1]--;
                            tmp_tiletypes[j + 2]--;

                            j = 1;
                        }
                    }

                    if (tmp_tiletypes.IsZeroAllTiles())
                        return true;
                }
            }

            return false;
        }
        
        public override string ToString()
        {
            string s = "";

            int count = 0;
            for(int i = 0;i < tiletypes.Length;i++)
            {
                if (tiletypes[i] != 0)
                {
                    count++;
                    if (i > 0)
                        s += " ";

                    s += i + " : " + tiletypes[i];

                    if (count >= 10)
                    {
                        s += "\n";
                        count = 0;
                    }
                }
            }

            return s;
        }

        /// <summary>
        /// 順子が含まれるか
        /// </summary>
        /// <param name="tile">順子の一番前の牌</param>
        /// <returns>含まれるか</returns>
        bool ContainsChow(TileNames tile)
        {
            int index = (int)tile;

            // 数牌の種類を超えての順子判定は、番号を種類ごとに一つ飛ばして割り振ってあるため起こらない
            return
                (index <= (int)TileNames.East && 
                (tiletypes[index] >= 1 && tiletypes[index + 1] >= 1 && tiletypes[index + 2] >= 1));
        }

        /// <summary>
        /// 手牌が国士無双かどうか
        /// </summary>
        /// <returns>国士無双か</returns>
        bool IsKokushi()
        {
            // 幺九牌のリスト
            int[] yaotiles = { 1, 9, 11, 19, 21, 29, 31, 32, 33, 34, 35, 36, 37 };

            HandTiles tmp_tiletypes = new HandTiles(this);

            for(int i = 0;i < yaotiles.Length;i++)
            {
                if (tmp_tiletypes[yaotiles[i]] >= 1)
                    tmp_tiletypes[yaotiles[i]]--;
                else
                    return false;
            }

            for(int i = 0;i < yaotiles.Length;i++)
            {
                if (tmp_tiletypes[yaotiles[i]] >= 1)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool IsZeroAllTiles()
        {
            for(int i = 0;i < tiletypes.Length;i++)
            {
                if (tiletypes[i] != 0)
                    return false;
            }

            return true;
        }

        int Length
        {
            get { return tiletypes.Length; }
        }

        private int this[int index]
        {
            get
            {
                return tiletypes[index];
            }

            set
            {
                tiletypes[index] = value;
            }
        }

    }
}
