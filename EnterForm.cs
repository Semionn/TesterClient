using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TesterClient.ServiceReference1;
using System.ServiceModel.Security;

namespace TesterClient
{
    public partial class EnterForm : Form
    {
        public EnterForm()
        {
            InitializeComponent();
        }
        public Service1Client client = null;
        public List<User> students = null;

        private void button1_Click(object sender, EventArgs e)
        {
            if (client.Login(comboBoxLogin.Text, textBoxPass.Text))
            {
                User user = students[comboBoxLogin.SelectedIndex];                
                (new MainForm(this, user)).Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин\\пароль.","Ошибка");
            }
        }

        private void EnterForm_Load(object sender, EventArgs e)
        {

        }

        private void EnterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                client.Close();
            }
            catch (Exception)
            {
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            try
            {
                client = new Service1Client();
                client.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
                client.ClientCredentials.UserName.UserName = "unknonw";
                client.ClientCredentials.UserName.Password = "1234";
                client.Open();
                students = client.GetAllUsers().ToList();
                comboBoxLogin.DataSource = students.Select(a => a.Name).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось соединиться с базой. Ошибка: " + ex.Message);
            }
            panel1.Hide();
        }
    }
}
