using System;

namespace Tiles
{
    class WallTiles
    {
        /// <summary>
        /// 山牌
        /// </summary>
        TileNames[] tiles = new TileNames[136];

        /// <summary>
        /// 山牌の次自摸される場所
        /// </summary>
        int front = 0;

        /// <summary>
        /// 王稗の次自摸される場所
        /// </summary>
        int king_front = 132;

        /// <summary>
        /// 山牌が何回自摸されたか
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// 値を初期化してから洗牌する
        /// </summary>
        public WallTiles()
        {
            WallInit();
            Shuffing();
            Count = 0;
        }

        /// <summary>
        /// 手牌を配る
        /// </summary>
        /// <returns>手牌</returns>
        public TileNames[] FirstDrawing()
        {
            TileNames[] tiles;
            int count = 14;

            tiles = new TileNames[count];
            for (int i = 0; i < count; i++)
                tiles[i] = Drawing();

            return tiles;
        }

        /// <summary>
        /// 自摸
        /// </summary>
        /// <returns>自摸した牌</returns>
        public TileNames Drawing()
        {
            front++;
            Count++;

            if (Count >= 122)
                throw new IndexOutOfRangeException("王稗から通常自摸できません。");

            return tiles[front - 1];
        }

        /// <summary>
        /// 王稗から自摸
        /// </summary>
        /// <returns>王稗から自摸した牌</returns>
        public TileNames DrawingFromKingWall()
        {
            king_front++;

            return tiles[king_front - 1];
        }

        /// <summary>
        /// 表ドラをすべて取得する
        /// </summary>
        /// <returns>すべての表ドラ</returns>
        public TileNames[] GetAllFrontDoras()
        {
            TileNames[] doras = new TileNames[4];

            for (int i = 0; i < 4; i++)
                doras[i] = tiles[i + 124];

            return doras;
        }

        /// <summary>
        /// 裏ドラをすべて取得する
        /// </summary>
        /// <returns>すべての裏ドラ</returns>
        public TileNames[] GetAllBackDoras()
        {
            TileNames[] doras = new TileNames[4];

            for (int i = 0; i < 4; i++)
                doras[i] = tiles[i + 128];

            return doras;
        }

        /// <summary>
        /// 山牌の番号を並べて文字列化
        /// </summary>
        /// <returns>山牌の中身</returns>
        public override string ToString()
        {
            string S = "";
            for(int i = 0;i < tiles.Length;i++)
            {
                if (i > 0)
                    S += " ";
                S += tiles[i];
            }
            return S;
        }

        /// <summary>
        /// イーピンから順番に4枚ずつ山牌に入れる
        /// </summary>
        void WallInit()
        {
            int count = 0;
            for (int i = 0; i < tiles.Length; i++)
            {
                if (i % 4 == 0)
                    count++;

                if (count % 10 == 0)
                    count++;

                tiles[i] = (TileNames)count;
            }
        }

        /// <summary>
        /// 洗牌
        /// </summary>
        void Shuffing()
        {
            Random rand;

            for(int i = 0;i < tiles.Length;i++)
            {
                rand = new Random(i + DateTime.Now.Millisecond);
                int num = rand.Next(136);

                // swap
                TileNames tmp = tiles[i];
                tiles[i] = tiles[num];
                tiles[num] = tmp;
            }
        }
    }
}
