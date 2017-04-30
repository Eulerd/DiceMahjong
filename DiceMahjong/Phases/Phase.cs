using DxLibDLL;

namespace DiceMohjong.Phases
{
    abstract class Phase
    {
        public Phase Update()
        {
            key.Update();

            Phase res = update();

            DX.ScreenFlip();

            return res;
        }

        protected abstract Phase update();

        protected static KeyForTiles key = GameState.key;
    }
}
