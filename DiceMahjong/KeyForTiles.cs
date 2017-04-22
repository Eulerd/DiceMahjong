using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace DiceMohjong
{
    class KeyForTiles
    {
        public KeyForTiles()
        {
            PressedInit();
        }

        /// <summary>
        /// 牌を切るためのキー配列
        /// </summary>
        int[] tilekeys =
        {
            DX.KEY_INPUT_1, DX.KEY_INPUT_2, DX.KEY_INPUT_3,
            DX.KEY_INPUT_4, DX.KEY_INPUT_5,DX.KEY_INPUT_6,
            DX.KEY_INPUT_7, DX.KEY_INPUT_8,  DX.KEY_INPUT_9,
            DX.KEY_INPUT_0,DX.KEY_INPUT_MINUS, DX.KEY_INPUT_PREVTRACK,
            DX.KEY_INPUT_YEN, DX.KEY_INPUT_SPACE
        };

        public string[] tilekeys_name =
        {
            "1","2","3", "4","5","6", "7","8","9", "0","-","^", "\\", "Space"
        };

        /// <summary>
        /// 牌を切るためのキーが前に押されているか
        /// </summary>
        public bool[] pressed = new bool[14];

        public bool LastKeyPressed()
        {
            return pressed[13];
        }

        /// <summary>
        /// pressed配列の初期化
        /// </summary>
        void PressedInit()
        {
            for (int i = 0; i < pressed.Length; i++)
            {
                pressed[i] = false;
            }
        }

        /// <summary>
        /// 番号の牌が選択された状態でもう一度同じキーが押されたか
        /// </summary>
        /// <param name="key">キー情報</param>
        /// <param name="i">判定する手牌の番号</param>
        /// <returns>i番目キーが二回連続で押されたか</returns>
        public bool IsKeyByUpdate(Key key, int i)
        {
            bool f = false;
            if(key.IsPressed(tilekeys[i]))
            {
                if(pressed[i])
                {
                    PressedInit();
                    f = true;
                }
                else
                {
                    PressedInit();
                    pressed[i] = true;
                }
            }

            return f;
        }
    }
}
