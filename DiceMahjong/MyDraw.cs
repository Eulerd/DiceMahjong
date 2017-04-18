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
        /// <summary>
        /// 全画面に描写する
        /// </summary>
        /// <param name="color">描写する色</param>
        public static void DrawScreen(uint color)
        {
            int X, Y;
            DX.GetWindowSize(out X, out Y);
            DX.DrawBox(0, 0, X, Y, color, 1);
        }
    }
}
