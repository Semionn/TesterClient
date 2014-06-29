using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TesterClient.ServiceReference1;

namespace TesterClient
{
    public partial class MainForm : Form
    {
        EnterForm enterForm = null;
        Service1Client client = null;
        List<TestsTheme> tests = null;
        TestPassage currTestPass = null;
        User currUser = null;
        bool init = true;
        DateTime taskBeginTime = DateTime.Now;

        public MainForm(EnterForm enterForm, User user)
        {
            InitializeComponent();
            this.enterForm = enterForm;
            client = enterForm.client;
            currUser = user;
            tests = client.GetAllTests();
            Text = "Пользователь: " + user.Name;
            listBoxThemes.DataSource = tests.Select(a => a.Name).ToList();
            panel2.Hide();
            init = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            enterForm.Close();
        }

        private void listBoxThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxThemes.SelectedIndex > -1)
            {
                listBoxTests.DataSource = tests[listBoxThemes.SelectedIndex].Tests.Select(a => a.Name).ToList();
            }
        }

        private void listBoxTests_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!init && listBoxTests.SelectedIndex > -1)
            {
                buttonBeginTest.Visible = true;           
            }
            else
            {
                listBoxTests.SelectedIndex = -1;
                buttonBeginTest.Visible = false;
            }
        }

        private void ShowTask()
        {
            SetLabelTaskNum();
            textBoxTask.Text = currTestPass.Test.Tasks[currTestPass.LastTask].Text;
            listBoxAnswers.Items.Clear();
            for (int i = 0; i < currTestPass.Test.Tasks[currTestPass.LastTask].Answers.Count; i++)
            {
                /*listBoxAnswers.Items.Add(new RadioButton() 
                                        {
                                            Text = currTestPass.Test.Tasks[currTestPass.LastTask].Answers[i], 
                                            Parent = listBoxAnswers, 
                                            Height = 30,
                                            Name = "r"+i.ToString(),
                                        });*/
                listBoxAnswers.Items.Add(currTestPass.Test.Tasks[currTestPass.LastTask].Answers[i]);
            }
            listBoxAnswers.SelectedIndex = currTestPass.Answers[currTestPass.LastTask];
            listBoxAnswers.SelectedIndex = currTestPass.Test.Tasks[currTestPass.LastTask].RightAnswer;
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            FixTime();
            currTestPass.TimeEnd = DateTime.Now;
            client.SendTestResult(currTestPass);
            var f = new ResultsForm(currTestPass);
            f.ShowDialog();
            currTestPass = null;

            panel2.Hide();
            panel1.Enabled = true;
        }

        private void buttoNext_Click(object sender, EventArgs e)
        {
            if (currTestPass.LastTask < currTestPass.Test.Tasks.Count - 1)
            {
                FixTime();
                currTestPass.LastTask++;
                ShowTask();
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (currTestPass.LastTask > 0)
            {
                FixTime();
                currTestPass.LastTask--;
                ShowTask();
            }
        }

        private void FixTime()
        {
            currTestPass.TimeAnswer[currTestPass.LastTask] += GetTimeResult();
        }

        private int GetTimeResult()
        {
            int res = (DateTime.Now - taskBeginTime).Seconds;
            taskBeginTime = DateTime.Now;
            return res;
        }

        private void listBoxAnswers_SelectedIndexChanged(object sender, EventArgs e)
        {
            currTestPass.Answers[currTestPass.LastTask] = listBoxAnswers.SelectedIndex;
        }

        private void SetLabelTaskNum()
        {
            labelTaskNum.Text = string.Format("Вопрос {0} из {1}", currTestPass.LastTask + 1, currTestPass.Test.Tasks.Count);
        }

        private void buttonBeginTest_Click(object sender, EventArgs e)
        {
            panel2.Show();
            panel1.Enabled = false;
            var currTest = tests[listBoxThemes.SelectedIndex].Tests[listBoxTests.SelectedIndex];
            currTestPass = new TestPassage()
            {
                Answers = new List<int>(),
                Test = currTest,
                User = currUser,
                TimeBegin = DateTime.Now,
                TimeAnswer = new List<int>()
            };
            for (int i = 0; i < currTest.Tasks.Count; i++)
            {
                currTestPass.TimeAnswer.Add(0);
                currTestPass.Answers.Add(-1);
            }
            ShowTask();  
        }
    } 
    
}
