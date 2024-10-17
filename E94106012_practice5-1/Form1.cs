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

        //////////////����Reset////////////////
        public void Reset(object sender, EventArgs e)
        {
            num = 5;

            startbutton.Visible = true;
            label1.Visible = false;
            label2.Visible = false;

            selectedIndices.Clear();   // ��� selectedIndices �б�
            selectedKeyboard.Clear();   // ��� selectedKeyboard �б�
            for (int i = 0; i < 36; i++)
            {
                row1[i].BackColor = Color.White;
                row1[i].Visible = false;
            }
        }

        //////////////ϵ�y�S�C�x��Ҫ׃�ɾGɫ�İ��o////////////////
        public void ChooseColor(object sender, EventArgs e)
        {
            Random rnd = new Random();

            // ����һ���б���춴惦�ѽ��x�еİ��o����


            // ���}���Σ�����������ͬ���S�C����
            for (int i = 0; i < 3; i++)
            {
                int randomIndex;

                // ���C���ɵ��S�C�����Ǫ�һ�o����
                do
                {
                    randomIndex = rnd.Next(0, 36);
                } while (selectedIndices.Contains(randomIndex));

                // ���ѽ��x�е����������б��Դ_���������}�xȡ
                selectedIndices.Add(randomIndex);

                // �O���x�еİ��o�ı����ɫ
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
            timer1.Enabled = false;    // ��ͣӋ�r��
            timer1.Interval = 1000;    //(1��)
            //Reset(sender, e);
        }

        ////////////// �ɜy�I�Pݔ���ֵ ////////////////
        public void Press_key(object sender, KeyEventArgs e)
        {
            // �O���x�еİ��o�ı����ɫ
            for (int i = 0; i < row1.Length; i++)
            {
                string buttonText = row1[i].Text;
                string keyCodeString = e.KeyCode.ToString();

                // ������I���ı��� KeyCode ���ִ���ʾ����ʾ���Iƥ��
                if (buttonText == keyCodeString || ("D" + buttonText) == keyCodeString)
                {
                    if (row1[i].BackColor == Color.White)
                    {
                        row1[i].BackColor = Color.LightSkyBlue;
                        selectedKeyboard.Add(i); // ��Ӱ��o������
                        //label3.Text = string.Join(", ", selectedIndices);

                    }
                    else
                    {
                        row1[i].BackColor = Color.White;
                        selectedKeyboard.Remove(i); // ���б��Єh�����o������
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
                row1[i].Text = text1[i]; // �O�����o������
                //row1[i].Click += btn1_Click;
                Controls.Add(row1[i]);
            }
            for (int i = 12; i < 24; i++)
            {
                row1[i] = new Button();
                row1[i].SetBounds(250 + 100 * (i - 12), 290, 80, 80); //(starting point X, starting point Y, width, heigth)
                row1[i].Text = text1[i]; // �O�����o������
                //row1[i].Click += btn1_Click;
                Controls.Add(row1[i]);
            }

            for (int i = 24; i < 36; i++)
            {
                row1[i] = new Button();
                row1[i].SetBounds(250 + 100 * (i - 24), 380, 80, 80); //(starting point X, starting point Y, width, heigth)
                row1[i].Text = text1[i]; // �O�����o������
                //row1[i].Click += btn1_Click;
                Controls.Add(row1[i]);
            }
            timer1.Enabled = true;	     // ����Ӌ�r��
            ChooseColor(sender, e);
        }
        ////////////// �O��Ӌ�r�� ////////////////
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
                //MessageBox.Show("�r�g����", "�r�g������", MessageBoxButtons.OK);
                if (label1.Text == "�ʂ��A��")
                {
                    label1.Text = "����A��";
                    num = 5;
                    timer1.Enabled = true;
                }
                else
                {
                    label1.Text = "�ʂ��A��";
                    //MessageBox.Show("�[��Y����", "�r�g������", MessageBoxButtons.OK);
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
                            // ��� selectedindices �� selectedkeyboard ����������ť����ɫ
                            row1[i].BackColor = Color.LimeGreen;
                        }
                        else if (!selectedIndices.Contains(i) && selectedKeyboard.Contains(i))
                        {
                            // ��� selectedindices ���������� selectedkeyboard ��������ť���ɫ
                            row1[i].BackColor = Color.Red;
                        }
                        else if (selectedIndices.Contains(i) && !selectedKeyboard.Contains(i))
                        {
                            // ��� selectedindices �������� selectedkeyboard ����������ť���ɫ
                            row1[i].BackColor = Color.Red;
                        }
                        else
                        {
                            // ���������������ť������ɫ�����ǰ�ɫ������Ĭ����ɫ
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
                        MessageBox.Show("You Win��", "", MessageBoxButtons.OK);
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