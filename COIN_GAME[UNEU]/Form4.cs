using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COIN_GAME_UNEU_
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        int timer = 60;
        private void Form4_Load(object sender, EventArgs e)
        {
            this.Text = "코드아트 코인";
            label1.Text = "코인 이름: 코드아트 코인";
            timer1.Interval = 1000;
            timer1.Start();
            timer2.Interval = 1000;
            timer2.Start();
            timer3.Interval = 1000;
            timer3.Start();
            this.ControlBox = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer != 0)
            {
                timer = timer - 1;
            }
            else
            {
                information();
                timer = 60;
            }
            label8.Text = Class1.코드아트코인.코인이름 + " 시세 변동 까지 남은시간: " + timer.ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            information();
            timer2.Stop();
        }

        public bool information()
        {
            label2.Text = "현재 주가: " + Class1.코드아트코인.현재가격.ToString() + "$";
            if (Class1.코드아트코인.변동률 > 0)
            {
                label3.Text = "변동률: " + Class1.코드아트코인.변동률.ToString() + "$↑";
            }
            else
            {
                label3.Text = "변동률: " + Class1.코드아트코인.변동률.ToString() + "$↓";
            }//보유 코인:
            label4.Text = "보유 코인: " + Class1.코드아트코인.보유수.ToString() + " 개";
            label5.Text = "돈: " + Class1.USER.돈.ToString() + "$";
            return true;
        }

        private bool ISNUMBERIC(string a)
        {
            try
            {
                String NUMVER0 = a;
                int CONVER = Convert.ToInt32(NUMVER0);
                String NUMVER1 = Convert.ToString(CONVER);
                if (NUMVER0 == NUMVER1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ISNUMBERIC(textBox1.Text) == true & ISNUMBERIC(textBox2.Text) == true)
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {

                }
                else
                {
                    int 구매 = Convert.ToInt32(textBox1.Text);
                    int 판매 = Convert.ToInt32(textBox2.Text);
                    if (Class1.USER.돈 >= Class1.코드아트코인.현재가격 * 구매)
                    {
                        Class1.USER.돈 = Class1.USER.돈 - Class1.코드아트코인.현재가격 * 구매;
                        Class1.코드아트코인.보유수 = Class1.코드아트코인.보유수 + 구매;

                    }
                    if (Class1.코드아트코인.현재가격 >= 판매)
                    {
                        Class1.USER.돈 = Class1.USER.돈 + Class1.코드아트코인.현재가격 * 판매;
                        Class1.코드아트코인.보유수 = Class1.코드아트코인.보유수 - 판매;
                    }
                }
            }
            else
            {
                MessageBox.Show("현재 돈이나 보유코인이나 시세를 확인하세요.");
            }
            label4.Text = "보유 코인: " + Class1.코드아트코인.보유수.ToString();
            label5.Text = "돈: " + Class1.USER.돈.ToString() + "$";
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            label5.Text = "돈: " + Class1.USER.돈.ToString() + "$";
        }
    }
    }

