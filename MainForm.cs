using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TesterClient.ServiceReference1;
//TODO:Сделать вывод во время теста текущей оценки студента (teta), оценки задания (beta) и средней оценки предложенных заданий
//Information level задания = k1*beta+k2*a-k3*c, показывает, насколько важно (сильно) определяет это задание уровень знаний студента
//Алгоритм выбора нового задания:
//1)Ищем ближайшее подходящее по уровню
//2)В том же радиусе + eps ищем еще задания
//3)Из сформированного списка выбираем наиболее информативное
//Находим новое teta с помощью метода максимизации правдоподобия
//Максимизируем L(teta). L=f(beta(1),teta)*f(beta(2),teta)..., где f = используемая функция вероятности правильного ответа студента,
//beta(i) - оценка i-го задания. При этом если ответ на задание верен, то используется f, иначе 1-f.
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
