using System;
using DxLibDLL;

namespace DiceMohjong.Phases
{
    /// <summary>
    /// 一局が終了した後のフェーズ
    /// </summary>
    class ResultPhase : Phase
    {
        protected override Phase update()
        {
            DX.DrawString(200,200,"[ResultPhase] 未開発",DX.GetColor(255,255,255));

            return this;
        }
    }
}
