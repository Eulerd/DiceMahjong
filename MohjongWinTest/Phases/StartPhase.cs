using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace MohjongWinTest.Phases
{
    class StartPhase : Phase
    {
        protected override Phase update()
        {
            int X, Y;
            DX.GetWindowSize(out X, out Y);

            DX.DrawString(X / 2, Y / 2, "麻雀ゲーム", DX.GetColor(255, 255, 255), DX.GetColor(0, 255, 0));



            return this;
        }
    }
}
