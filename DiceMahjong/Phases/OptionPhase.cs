using DxLibDLL;

namespace DiceMohjong.Phases
{
    /// <summary>
    /// 設定フェーズ
    /// </summary>
    class OptionPhase : Phase
    {
        protected override Phase update()
        {
            DX.DrawString(200, 200, "[OptionPhase] 未開発", DX.GetColor(255, 255, 255));
            DX.DrawString(200, 250, "[q]キーで戻る", DX.GetColor(255, 255, 255));

            if (key.IsPressed(DX.KEY_INPUT_Q))
                return new StartPhase();

            return this;
        }
    }
}
