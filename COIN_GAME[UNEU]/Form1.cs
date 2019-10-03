using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace COIN_GAME_UNEU_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.Opacity = 0.1f;
            InitializeComponent();
        }
        float d = 0.01f;
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                FileInfo fileInfo = new FileInfo("비트 코인 음악.WAV");
                if(fileInfo.Exists)
                {
                    System.Media.SoundPlayer soundPlayer = new System.Media.SoundPlayer();
                    soundPlayer.SoundLocation = @"비트 코인 음악.WAV";
                    soundPlayer.PlayLooping();
                }
               else
                {
                    MessageBox.Show("노래가 저장되있지 않으므로 노래가 재생되지 않습니다.", "가상화폐 시뮬레이션", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {

            }
            this.Opacity = 0.1f;
            timer1.Interval = 30;
            timer1.Start();
            Class1.USER.돈 = 1000;
            Class1.사용자코인.보유수 = 0;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.Show();
            timer1.Stop();
        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(d <= 1f)
            {
                this.Opacity = d;
                d += 0.01f;
            }
            else if(d < 2f)
            {
                d += 0.01f;
            }
           else
            {
                Form2 form2 = new Form2();
                this.Hide();
                form2.Show();
                timer1.Stop();
            }
        }
    }
}
