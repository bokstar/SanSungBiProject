using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace SanSongBi
{
    public partial class Game_fnc : Form
    {
        Timer timer;

        static int score =0;
        static int fail_count = 0;
      
        //1000개 단어
        static List<string> raining = null;
       
        public Game_fnc()
        {
            InitializeComponent();
        }

        //Form를 초기화하는 메소드
        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Location = new Point(100,3);
            label1.Text = "테스트";
            label5.Text = "0";
            setTextSource();
            label2.Text = score.ToString();

        }

        // 레이블을 움직이기 위한 메소드
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label1.Top > this.Height) timer.Enabled = false;

                label1.Top = label1.Top +1;

                if (label1.Location.Y == 238)
                {
                    label1.Text ="";
                    fail_count += 1;
                    label5.Text = fail_count.ToString();
                    label1.Location = new Point(100, 3);
                    label1.Text = RandomCreate();
                }

                 // 타이머 중료 조건

                if (Int32.Parse(label5.Text) > 3)
                {
                    timer.Stop();
                    
                }

        }
        //TxtSource 파일을 배열에 담기 위한 메소드
        public void setTextSource()
        {
            string pathSource =@"C:\Users\bean\Documents\Github\SanSongBi_Project\SanSongBi\SanSongBi\TxtSource.txt";
            StreamReader file = new StreamReader(pathSource);
   
            string line;
            raining = new List<string>();

            while ((line = file.ReadLine()) != null)
            {
                raining.Add(line.ToString());
            }
        }

        // Txt 배열을 랜덤으로 받아오기 위한 메소드
        
        public string RandomCreate()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 1000);
            return raining[randomNumber];
        }


        private void button1_Click(object sender, EventArgs e)
        {
            score += 10;
            label2.Text = score.ToString();
            label1.Text = RandomCreate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void If_collect()
        {


        }


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //score += 10;
                //label2.Text = score.ToString();

                // 레이블 1 값과 입력값이 같으면 이벤트
                if (textBox1.Text.Equals(label1.Text.ToString()))
                {
                    score += 10;
                    label2.Text = score.ToString();
                    label1.Text = RandomCreate();
                    textBox1.Text = "";
                    label1.Location = new Point(100, 3);
                    label1.Text = RandomCreate();


                 //textBox1.AppendText(Keys.Enter.ToString());
                }
                else
                {
                    fail_count += 1;
                    label5.Text = fail_count.ToString();
                }

            }

            else
            {
                return;
            }
        }

      
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (timer.Enabled ==false)
            {
            label1.Visible = true;
            timer = new Timer();
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Interval = 10;
            timer.Enabled = true;
            label1.Text = RandomCreate();
            //alarm = new Timer();
            //alarm.Tick += new EventHandler(timer2_Tick);
            //alarm.Interval = 3000;
            //label6.Text = alarm.ToString();
            //alarm.Enabled = true;
        }

  }

        private void timer2_Tick(object sender, EventArgs e)
        {



            //timer.Enabled = false;           
            

        //     if (label1.Top > this.Height) timer.Enabled = false;

        //        label1.Top = label1.Top +1;


        //// 타이머 중지 조건

        //        if (true)
        //        {

        //        }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            inital();
        }

        private void inital()
        {
            label1.Visible = false;
            timer.Enabled = false;
            score =0;
            fail_count = 0;
            label1.Location = new Point(100, 3);
            label2.Text = score.ToString();
            label5.Text =fail_count.ToString();

        } 

    }
}
