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

namespace DiceMohjong
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DX.SetUserWindow(this.Handle);
            DX.ChangeWindowMode(1);
            DX.DxLib_Init();
            DX.SetDrawScreen(DX.DX_SCREEN_BACK);
        }

        int num = 0;
        public void MainLoop()
        {
            DX.ClearDrawScreen();
            int mouseX, mouseY;
            DX.GetMousePoint(out mouseX, out mouseY);

            if (num < 256)
                num++;
            else
                num = 0;

            DX.DrawBox(num, num, num + 10, num + 10, DX.GetColor(255, 255, 255), 1);
            DX.DrawString(0, 0, mouseX.ToString() + " , " + mouseY.ToString(), DX.GetColor(255, 255, 255));
            DX.ScreenFlip();
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
