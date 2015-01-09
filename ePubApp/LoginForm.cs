using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ePubApp.ServiceReference1;
namespace ePubApp
{

    public partial class LoginForm : Form
    {
        Service1Client serv;

        public LoginForm()
        {
            InitializeComponent();

            serv = new Service1Client();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Book li = new Book();
            //li.Show();

            /*if (txtUser == null || txtPass == null)
{
    showErr();
}
else
{
    if (serv.UserExists(txtUser.Text, txtPass.Text) == 0)
    {
        showErr();
    }
    else
    {
        this.Hide();

        Form menu = new Menu();
        menu.ShowDialog();

        this.Close();
    }
}*/

            this.Hide();

            Form menu = new Menu();
            menu.ShowDialog();

            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {

        }

        private void showErr()
        {
            MessageBox.Show("Sorry, wrong username or password");
        }
    }
}
