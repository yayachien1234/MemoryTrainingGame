using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E94106012_practice5_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        Button[] row1 = new Button[36];//12 button
        int num = 5;
        List<int> selectedIndices = new List<int>();
        List<int> selectedKeyboard = new List<int>();

        //////////////重置Reset////////////////
        public void Reset(object sender, EventArgs e)
        {
            num = 5;

            startbutton.Visible = true;
            label1.Visible = false;
            label2.Visible = false;

            selectedIndices.Clear();   // 清除 selectedIndices 列表
            selectedKeyboard.Clear();   // 清除 selectedKeyboard 列表
            for (int i = 0; i < 36; i++)
            {
                row1[i].BackColor = Color.White;
                row1[i].Visible = false;
            }
        }

        //////////////系統隨機選擇要變成綠色的按鈕////////////////
        public void ChooseColor(object sender, EventArgs e)
        {
            Random rnd = new Random();

            // 創建一個列表，用於存儲已經選中的按鈕索引


            // 重複三次，生成三個不同的隨機索引
            for (int i = 0; i < 3; i++)
            {
                int randomIndex;

                // 保證生成的隨機索引是獨一無二的
                do
                {
                    randomIndex = rnd.Next(0, 36);
                } while (selectedIndices.Contains(randomIndex));

                // 將已經選中的索引加入列表，以確保不會重複選取
                selectedIndices.Add(randomIndex);

                // 設定選中的按鈕的背景顏色
                row1[randomIndex].BackColor = Color.LimeGreen;
            }
            //label3.Text = string.Join(", ", selectedIndices);
        }
        ////////////// Load ////////////////
        public void Form1_Load_1(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Press_key);
            label1.Visible = false;
            label2.Visible = false;
            timer1.Enabled = false;    // 暫停計時器
            timer1.Interval = 1000;    //(1秒)
            //Reset(sender, e);
        }

        ////////////// 偵測鍵盤輸入的值 ////////////////
        public void Press_key(object sender, KeyEventArgs e)
        {
            // 設定選中的按鈕的背景顏色
            for (int i = 0; i < row1.Length; i++)
            {
                string buttonText = row1[i].Text;
                string keyCodeString = e.KeyCode.ToString();

                // 如果按鍵的文本是 KeyCode 的字串表示，表示按鍵匹配
                if (buttonText == keyCodeString || ("D" + buttonText) == keyCodeString)
                {
                    if (row1[i].BackColor == Color.White)
                    {
                        row1[i].BackColor = Color.LightSkyBlue;
                        selectedKeyboard.Add(i); // 添加按鈕的索引
                        //label3.Text = string.Join(", ", selectedIndices);

                    }
                    else
                    {
                        row1[i].BackColor = Color.White;
                        selectedKeyboard.Remove(i); // 從列表中刪除按鈕的索引
                        //label3.Text = string.Join(", ", selectedIndices);
                    }
                }
            }
        }
        public void startbutton_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            startbutton.Visible = false;
            string[] text1 = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

            for (int i = 0; i < 12; i++)
            {
                row1[i] = new Button();
                row1[i].SetBounds(250 + 100 * i, 200, 80, 80); //(starting point X, starting point Y, width, heigth)
                row1[i].Text = text1[i]; // 設定按鈕的文字
                //row1[i].Click += btn1_Click;
                Controls.Add(row1[i]);
            }
            for (int i = 12; i < 24; i++)
            {
                row1[i] = new Button();
                row1[i].SetBounds(250 + 100 * (i - 12), 290, 80, 80); //(starting point X, starting point Y, width, heigth)
                row1[i].Text = text1[i]; // 設定按鈕的文字
                //row1[i].Click += btn1_Click;
                Controls.Add(row1[i]);
            }

            for (int i = 24; i < 36; i++)
            {
                row1[i] = new Button();
                row1[i].SetBounds(250 + 100 * (i - 24), 380, 80, 80); //(starting point X, starting point Y, width, heigth)
                row1[i].Text = text1[i]; // 設定按鈕的文字
                //row1[i].Click += btn1_Click;
                Controls.Add(row1[i]);
            }
            timer1.Enabled = true;	     // 啟動計時器
            ChooseColor(sender, e);
        }
        ////////////// 設定計時器 ////////////////
        public void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = num.ToString();

            if (num == 0)
            {
                timer1.Enabled = false;
                for (int i = 0; i < 36; i++)
                {
                    row1[i].BackColor = Color.White;
                }
                //MessageBox.Show("時間到！", "時間倒數器", MessageBoxButtons.OK);
                if (label1.Text == "準備階段")
                {
                    label1.Text = "玩家階段";
                    num = 5;
                    timer1.Enabled = true;
                }
                else
                {
                    label1.Text = "準備階段";
                    //MessageBox.Show("遊戲結束！", "時間倒數器", MessageBoxButtons.OK);
                    for (int i = 0; i < 36; i++)
                    {
                        row1[i].BackColor = Color.White;
                    }
                    //label3.text = string.join(", ", selectedindices);
                    //label4.text = string.join(", ", selectedkeyboard);
                    for (int i = 0; i < row1.Length; i++)
                    {
                        if (selectedIndices.Contains(i) && selectedKeyboard.Contains(i))
                        {
                            // 如果 selectedindices 和 selectedkeyboard 都包含，按钮变绿色
                            row1[i].BackColor = Color.LimeGreen;
                        }
                        else if (!selectedIndices.Contains(i) && selectedKeyboard.Contains(i))
                        {
                            // 如果 selectedindices 不包含，但 selectedkeyboard 包含，按钮变红色
                            row1[i].BackColor = Color.Red;
                        }
                        else if (selectedIndices.Contains(i) && !selectedKeyboard.Contains(i))
                        {
                            // 如果 selectedindices 包含，但 selectedkeyboard 不包含，按钮变红色
                            row1[i].BackColor = Color.Red;
                        }
                        else
                        {
                            // 如果都不包含，按钮背景颜色可以是白色或其他默认颜色
                            row1[i].BackColor = Color.White;
                        }
                    }
                    bool result = true;
                    for(int i = 0;i < row1.Length; i++)
                    {
                        if(row1[i].BackColor == Color.Red)
                        {
                            MessageBox.Show("You Lose \n Try Again", "", MessageBoxButtons.OK);
                            result = false;
                            Reset(sender, new EventArgs());
                        }
                    }
                    if (result == true)
                    {
                        MessageBox.Show("You Win！", "", MessageBoxButtons.OK);
                        Reset(sender, new EventArgs());
                    }
                }
            }
            num--;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}