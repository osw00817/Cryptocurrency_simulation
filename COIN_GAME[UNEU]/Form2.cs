using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace COIN_GAME_UNEU_
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    Class1.사용자코인.코인이름 = textBox1.Text;
                    배경 배경 = new 배경();
                    this.Hide();
                    배경.Show();
                }
                else
                {
                    MessageBox.Show("화폐이름을 입력하세요.", "가상화폐 시뮬레이션", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception A)
            {
                MessageBox.Show(A.Message, "가상화폐 시뮬레이션", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            download();
        }
        public void download()
        {
            FileInfo check = new FileInfo("save.txt");
            if (check.Exists)
            {
                int i = 0;
                string[] lines = File.ReadAllLines("save.txt");
                foreach (string a in lines)
                {
                    switch (i)
                    {
                        case 0: Class1.USER.돈 = Convert.ToInt32(a); i += 1; break;
                        case 1: Class1.사용자코인.코인이름 = a; i += 1; break;
                        case 2: Class1.사용자코인.보유수 = Convert.ToInt32(a); i += 1; break;
                        case 3: Class1.코드아트코인.코인이름 = a; i += 1; break;
                        case 4: Class1.코드아트코인.보유수 = Convert.ToInt32(a); i += 1; break;
                    }
                }
                배경 배경 = new 배경();
                this.Opacity = 0;
                배경.Show();
            }
        }
    }
}

