namespace MahjongLib
{
    public static class Mahjong
    {
        public const int HandTileCount = 14;
        public const int TileCount = 136;
        public const int KingTilesCount = 14;
        public const int CanGetTilesCount = 122;

    }


    public enum TileNames
    {
        Null = 334,

        Bamboo1 = 1,
        Bamboo2 = 2,
        Bamboo3 = 3,
        Bamboo4 = 4,
        Bamboo5 = 5,
        Bamboo6 = 6,
        Bamboo7 = 7,
        Bamboo8 = 8,
        Bamboo9 = 9,

        Dots1 = 11,
        Dots2 = 12,
        Dots3 = 13,
        Dots4 = 14,
        Dots5 = 15,
        Dots6 = 16,
        Dots7 = 17,
        Dots8 = 18,
        Dots9 = 19,
        
        Characters1 = 21,
        Characters2 = 22,
        Characters3 = 23,
        Characters4 = 24,
        Characters5 = 25,
        Characters6 = 26,
        Characters7 = 27,
        Characters8 = 28,
        Characters9 = 29,

        East = 31,
        South = 32,
        West = 33,
        North = 34,

        Haku = 35,
        Hatsu = 36,
        Tyun = 37
    }

    enum TakenTileStatus
    {
        Pon,
        Chi,
        Kan
    }

    enum TakenFrom
    {
        LeftPlayer,
        OppositePlayer,
        RightPlayer
    }

    enum PlayerStatus
    {
        EastPlayer,
        SouthPlayer,
        WestPlayer,
        NorthPlayer
    }

    public enum Elements
    {
        SeatEast = 1,
        SeatSouth = 1,
        SeatWest = 1,
        SeatNorth = 1,
        RoundEast = 1,
        RoundSouth = 1,
        RoundWest = 1,
        RoundNorth = 1,
        Reach = 1,
        SelfDrawn = 1,
        Pinhu = 1,
        AllSimples = 1,
        PureDoubleChow = 1,
        KingTileDraw = 1,
        Tyankan = 1,
        LastTileDrown = 1,
        LonLastTile = 1,

        DoubleReach = 2,
        PureStraight = 2,
        TripleRun = 2,
        TriplePung = 2,
        AllPungs = 2,
        ThreePungs = 2,
        ThreeKongs = 2,
        SevenPairs = 2,
        Tyanta = 2,
        Honrouto = 2,
        LittleThreeDragons = 2,

        HalfFlush = 3,
        Zyuntyan = 3,
        DoublePureDoubleChow = 3,
        FullFlush = 6,
    }
}