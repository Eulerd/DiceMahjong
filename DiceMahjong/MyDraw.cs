using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace DiceMohjong
{
    class MyDraw
    {
        public static void DrawScreen(uint color)
        {
            int X, Y;
            DX.GetWindowSize(out X, out Y);
            DX.DrawBox(0, 0, X, Y, color, 1);
        }
    }
}
