using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace DiceMohjong.Phases
{
    class SelectModePhase : Phase
    {
        protected override Phase update()
        {
            MyDraw.DrawScreen(DX.GetColor(100, 255, 100));

            if (key.IsPressed(DX.KEY_INPUT_RETURN))
                return new EastWindPhase();

            return this;
        }
    }
}
