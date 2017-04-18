using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace DiceMohjong.Phases
{
    /// <summary>
    /// スタートフェーズ
    /// </summary>
    class StartPhase : Phase
    {
        /// <summary>
        /// 選択表示用
        /// </summary>
        int pos = 0;

        /// <summary>
        /// モード配列
        /// </summary>
        string[] ModeNames = { "ゲームスタート", "設定" };

        /// <summary>
        /// モードの個数
        /// </summary>
        int ModeCount;

        public StartPhase()
        {
            ModeCount = ModeNames.Length;
        }

        protected override Phase update()
        {
            if (key.IsPressed(DX.KEY_INPUT_DOWN))
                pos = (pos == ModeCount - 1) ? 0 : pos + 1;
            if (key.IsPressed(DX.KEY_INPUT_UP))
                pos = (pos == 0) ? ModeCount - 1 : pos - 1;
            
            for (int i = 0;i < ModeCount;i++)
            {
                DX.DrawString(150, 100 + (i * 100), ModeNames[i], DX.GetColor(255, 255, 255));
            }
            
            DX.DrawCircle(100, 100 + (pos * 100), 10, DX.GetColor(255, 0, 0));
            
            if(key.IsPressed(DX.KEY_INPUT_RETURN))
            {
                switch (pos)
                {
                    case 0:
                        return new SelectModePhase();
                    case 1:
                        return new OptionPhase();
                    default:
                        break;
                }
            }

            return this;
        }
    }
}
