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
    public partial class ResultsForm : Form
    {
        public ResultsForm(TestPassage testPass)
        {
            InitializeComponent();

            int rightAnswers = testPass.Test.Tasks.Where((a, i) => a.RightAnswer == testPass.Answers[i]).ToList().Count;
            labelTestResult.Text = string.Format("Выполнено заданий: {0} из {1}", rightAnswers, testPass.Test.Tasks.Count);
        }
    }
}
