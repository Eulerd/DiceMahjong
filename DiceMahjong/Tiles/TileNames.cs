namespace Tiles
{
    public enum TileNames
    {
        Dots1 = 1,
        Dots2 = 2,
        Dots3 = 3,
        Dots4 = 4,
        Dots5 = 5,
        Dots6 = 6,
        Dots7 = 7,
        Dots8 = 8,
        Dots9 = 9,

        Bamboo1 = 11,
        Bamboo2 = 12,
        Bamboo3 = 13,
        Bamboo4 = 14,
        Bamboo5 = 15,
        Bamboo6 = 16,
        Bamboo7 = 17,
        Bamboo8 = 18,
        Bamboo9 = 19,

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