using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DxLibDLL;
using DiceMohjong.Phases;

namespace DiceMohjong
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Phase phase;
        public static int[] TileHandle = new int[35];

        private void Form1_Load(object sender, EventArgs e)
        {
            phase = new StartPhase();

            DX.SetUserWindow(this.Handle);
            DX.ChangeWindowMode(1);
            DX.DxLib_Init();
            DX.SetDrawScreen(DX.DX_SCREEN_BACK);

            DX.LoadDivGraph("mahjong01.png", 35, 9, 5, 48, 72, out TileHandle[0]);
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
