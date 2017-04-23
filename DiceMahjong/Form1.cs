using DiceMohjong.Phases;
using DxLibDLL;
using MahjongLib;
using System;
using System.Windows.Forms;

namespace DiceMohjong
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Phase phase;

        private void Form1_Load(object sender, EventArgs e)
        {
            phase = new StartPhase();

            DX.SetUserWindow(this.Handle);
            DX.ChangeWindowMode(1);
            DX.DxLib_Init();
            DX.SetDrawScreen(DX.DX_SCREEN_BACK);

            DX.LoadDivGraph("mahjong01.png", 35, 9, 5, 48, 72, out Mahjong.TileHandle[0]);

            // TileNamesの番号にあわせる
            int[] TmpHandle = new int[Mahjong.TileHandle.Length];
            Mahjong.TileHandle.CopyTo(TmpHandle, 0);
            int num = 1;
            for (int i = 1; i < Mahjong.TileHandle.Length; i++)
            {
                if (i % 10 == 0)
                {
                    num++;
                    continue;
                }

                TmpHandle[i] = Mahjong.TileHandle[i - num];
            }
            Mahjong.TileHandle = TmpHandle;
        }

        public void MainLoop()
        {
            phase = phase.Update();
            DX.ClearDrawScreen();
            
            if (phase == null)
                Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DX.DxLib_End();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Escape)
                this.Close();
        }
    }
}
