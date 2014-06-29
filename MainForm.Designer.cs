namespace TesterClient
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listBoxThemes = new System.Windows.Forms.ListBox();
            this.listBoxTests = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonEnd = new System.Windows.Forms.Button();
            this.buttoNext = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.listBoxAnswers = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTask = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelTaskNum = new System.Windows.Forms.Label();
            this.labelChooseTest = new System.Windows.Forms.Label();
            this.buttonBeginTest = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxThemes
            // 
            this.listBoxThemes.FormattingEnabled = true;
            this.listBoxThemes.Location = new System.Drawing.Point(3, 31);
            this.listBoxThemes.Name = "listBoxThemes";
            this.listBoxThemes.Size = new System.Drawing.Size(117, 264);
            this.listBoxThemes.TabIndex = 0;
            this.listBoxThemes.SelectedIndexChanged += new System.EventHandler(this.listBoxThemes_SelectedIndexChanged);
            // 
            // listBoxTests
            // 
            this.listBoxTests.FormattingEnabled = true;
            this.listBoxTests.Location = new System.Drawing.Point(126, 31);
            this.listBoxTests.Name = "listBoxTests";
            this.listBoxTests.Size = new System.Drawing.Size(188, 264);
            this.listBoxTests.TabIndex = 1;
            this.listBoxTests.SelectedIndexChanged += new System.EventHandler(this.listBoxTests_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.listBoxThemes);
            this.panel1.Controls.Add(this.listBoxTests);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(322, 411);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Тесты";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Разделы";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelTaskNum);
            this.panel2.Controls.Add(this.buttonEnd);
            this.panel2.Controls.Add(this.buttoNext);
            this.panel2.Controls.Add(this.buttonBack);
            this.panel2.Controls.Add(this.listBoxAnswers);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.textBoxTask);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(322, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(533, 411);
            this.panel2.TabIndex = 3;
            // 
            // buttonEnd
            // 
            this.buttonEnd.Location = new System.Drawing.Point(401, 363);
            this.buttonEnd.Name = "buttonEnd";
            this.buttonEnd.Size = new System.Drawing.Size(120, 36);
            this.buttonEnd.TabIndex = 5;
            this.buttonEnd.Text = "Закончить";
            this.buttonEnd.UseVisualStyleBackColor = true;
            this.buttonEnd.Click += new System.EventHandler(this.buttonEnd_Click);
            // 
            // buttoNext
            // 
            this.buttoNext.Location = new System.Drawing.Point(143, 363);
            this.buttoNext.Name = "buttoNext";
            this.buttoNext.Size = new System.Drawing.Size(121, 36);
            this.buttoNext.TabIndex = 4;
            this.buttoNext.Text = "Дальше";
            this.buttoNext.UseVisualStyleBackColor = true;
            this.buttoNext.Click += new System.EventHandler(this.buttoNext_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(6, 363);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(121, 36);
            this.buttonBack.TabIndex = 3;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // listBoxAnswers
            // 
            this.listBoxAnswers.BackColor = System.Drawing.Color.PowderBlue;
            this.listBoxAnswers.FormattingEnabled = true;
            this.listBoxAnswers.Location = new System.Drawing.Point(6, 171);
            this.listBoxAnswers.Name = "listBoxAnswers";
            this.listBoxAnswers.Size = new System.Drawing.Size(515, 186);
            this.listBoxAnswers.TabIndex = 2;
            this.listBoxAnswers.SelectedIndexChanged += new System.EventHandler(this.listBoxAnswers_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Задание";
            // 
            // textBoxTask
            // 
            this.textBoxTask.Location = new System.Drawing.Point(6, 31);
            this.textBoxTask.Multiline = true;
            this.textBoxTask.Name = "textBoxTask";
            this.textBoxTask.Size = new System.Drawing.Size(515, 134);
            this.textBoxTask.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // labelTaskNum
            // 
            this.labelTaskNum.AutoSize = true;
            this.labelTaskNum.Location = new System.Drawing.Point(192, 13);
            this.labelTaskNum.Name = "labelTaskNum";
            this.labelTaskNum.Size = new System.Drawing.Size(83, 13);
            this.labelTaskNum.TabIndex = 6;
            this.labelTaskNum.Text = "Вопрос 1 из 10";
            // 
            // labelChooseTest
            // 
            this.labelChooseTest.AutoSize = true;
            this.labelChooseTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelChooseTest.Location = new System.Drawing.Point(517, 93);
            this.labelChooseTest.Name = "labelChooseTest";
            this.labelChooseTest.Size = new System.Drawing.Size(124, 20);
            this.labelChooseTest.TabIndex = 4;
            this.labelChooseTest.Text = "Выберите тест";
            // 
            // buttonBeginTest
            // 
            this.buttonBeginTest.Location = new System.Drawing.Point(521, 133);
            this.buttonBeginTest.Name = "buttonBeginTest";
            this.buttonBeginTest.Size = new System.Drawing.Size(111, 33);
            this.buttonBeginTest.TabIndex = 5;
            this.buttonBeginTest.Text = "Начать тест";
            this.buttonBeginTest.UseVisualStyleBackColor = true;
            this.buttonBeginTest.Visible = false;
            this.buttonBeginTest.Click += new System.EventHandler(this.buttonBeginTest_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(855, 411);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.labelChooseTest);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonBeginTest);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxThemes;
        private System.Windows.Forms.ListBox listBoxTests;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonEnd;
        private System.Windows.Forms.Button buttoNext;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.ListBox listBoxAnswers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxTask;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelTaskNum;
        private System.Windows.Forms.Label labelChooseTest;
        private System.Windows.Forms.Button buttonBeginTest;
    }
}