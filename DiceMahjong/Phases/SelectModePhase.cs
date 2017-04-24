using DxLibDLL;

namespace DiceMohjong.Phases
{
    /// <summary>
    /// モード選択フェーズ
    /// </summary>
    class SelectModePhase : Phase
    {
        protected override Phase update()
        {
            DX.DrawString(200, 200, "東風戦", DX.GetColor(255,255,255));
            DX.DrawString(200, 250, "[Enter]キーで開始", DX.GetColor(255, 255, 255));
            DX.DrawString(200, 300, "[q]キーで戻る", DX.GetColor(255, 255, 255));

            if (key.IsPressed(DX.KEY_INPUT_RETURN))
                return new EastWindPhase();

            if (key.IsPressed(DX.KEY_INPUT_Q))
                return new StartPhase();

            return this;
        }
    }
}
