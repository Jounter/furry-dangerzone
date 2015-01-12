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

            if (txtUser == null || txtPass == null)
            {
                showErr();
            }
            else
            {
                try
                {
                    //UI
                    this.Cursor = Cursors.WaitCursor;
                    Application.DoEvents();

                    if (!serv.UserExists(txtUser.Text, txtPass.Text))
                    {
                        showErr();

                    }
                    else
                    {
                        this.Hide();

                        Form menu = new Menu(txtUser.Text);
                        menu.ShowDialog();

                        this.Dispose();
                        this.Close();
                    }
                }
                finally
                {
                    //UI
                    this.Cursor = Cursors.Default;
                }
            }
            /*
            this.Hide();

            Form menu = new Menu(txtUser.Text);
            menu.ShowDialog();

            this.Close();*/
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form signup = new SignInForm();
            signup.ShowDialog();

            this.Close();
        }

        private void showErr()
        {
            MessageBox.Show("Sorry, wrong username or password");
        }
    }
}
