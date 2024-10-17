namespace E94106012_practice5_1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            startbutton = new Button();
            label1 = new Label();
            label2 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // startbutton
            // 
            startbutton.Location = new Point(676, 597);
            startbutton.Margin = new Padding(5, 4, 5, 4);
            startbutton.Name = "startbutton";
            startbutton.Size = new Size(349, 45);
            startbutton.TabIndex = 0;
            startbutton.Text = "開始遊戲";
            startbutton.UseVisualStyleBackColor = true;
            startbutton.Click += startbutton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(790, 24);
            label1.Name = "label1";
            label1.Size = new Size(137, 39);
            label1.TabIndex = 1;
            label1.Text = "準備階段";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(835, 79);
            label2.Name = "label2";
            label2.Size = new Size(45, 52);
            label2.TabIndex = 2;
            label2.Text = "5";
            label2.Click += label2_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1637, 676);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(startbutton);
            Margin = new Padding(5, 4, 5, 4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button startbutton;
        private Label label1;
        private Label label2;
        private System.Windows.Forms.Timer timer1;
    }
}