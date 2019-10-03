using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace COIN_GAME_UNEU_
{
    public partial class 배경 : Form
    {
        public 배경()
        {
            InitializeComponent();
            chart2.ChartAreas[0].AxisX.Maximum = 10;
            chart2.ChartAreas[0].AxisY.Maximum = 1000;
        }
        Random random = new Random();
        int num;
        private void 배경_Load(object sender, EventArgs e)
        {
            Class1.사용자코인.과거가격 = 0;
            Class1.코드아트코인.과거가격 = 0;
            Class1.코드아트코인.코인이름 = "코드아트 코인";
            Form3 form3 = new Form3();
            form3.Show();
            Form4 form4 = new Form4();
            form4.Show();
            chart2.Series[0].Points.AddY(0);
            chart2.Series[1].Points.AddY(0);
            사용자코인();
            코드아트코인();
            timer1.Interval = 60000;
            timer1.Start();
            listBox1.Items.Add("현재구현 준비중입니다.");
            listBox1.Items.Add("빠른 시일 내에 구현하겠습니다.");
            string UserName = Environment.UserName;
            label4.Text = "이름: " + UserName;
            label5.Text = "컴퓨터 이름: " + Environment.UserDomainName;
        }
        //  chart2.Series[1].Points.AddY(Class1.초다코인.시세);
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }
        public bool 사용자코인()
        {
            if (num == 10)
            {
                chart2.Series[0].Points.Clear();
                chart2.Series[1].Points.Clear();
                num = 0;
            }
           num += 1;
            int rannum = random.Next(1, 1000);
            chart2.Series[0].Points.AddY(rannum);
            Class1.사용자코인.현재가격 = rannum;
            Class1.사용자코인.변동률 = Class1.사용자코인.현재가격 - Class1.사용자코인.과거가격;
            Class1.사용자코인.과거가격 = rannum;
            return true;
        }

        public bool 코드아트코인()
        {
            int rannum = random.Next(1, 1000);
            if(rannum < 800)
            {
                rannum = random.Next(1, 500);
            }
            else
            {
                rannum = random.Next(1,1000);
            }
            chart2.Series[1].Points.AddY(rannum);
            Class1.코드아트코인.현재가격 = rannum;
            Class1.코드아트코인.변동률 = Class1.코드아트코인.현재가격 - Class1.코드아트코인.과거가격;
            Class1.코드아트코인.과거가격 = rannum;
            return true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            사용자코인();
            코드아트코인();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3.ActiveForm.Focus();
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
        public void save()
        {
            StreamWriter streamWriter = new StreamWriter("save.txt");
            streamWriter.WriteLine(Class1.USER.돈.ToString(), Encoding.Default);
            streamWriter.WriteLine(Class1.사용자코인.코인이름, Encoding.Default);
            streamWriter.WriteLine(Class1.사용자코인.보유수.ToString(), Encoding.Default);
            streamWriter.WriteLine(Class1.코드아트코인.코인이름, Encoding.Default);
            streamWriter.WriteLine(Class1.코드아트코인.보유수.ToString(), Encoding.Default);
            streamWriter.Close();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                FileInfo check = new FileInfo("save.txt");
                if(check.Exists)
                {
                    save();
                }
                else
                {
                    FileStream fileStream = new FileStream("save.txt", FileMode.Create);
                    fileStream.Close();
                    save();
                }
            }
            catch
            {

            }
        }
    }
}
