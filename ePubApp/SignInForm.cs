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
    public partial class SignInForm : Form
    {
        Service1Client serv;

        public SignInForm()
        {
            InitializeComponent();

            serv = new Service1Client();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAcc_Click(object sender, EventArgs e)
        {
            Boolean err = false;

            if (txtUser.Text == "" || txtPass.Text == "" || txtRetypePass.Text == "" || txtName.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("The fields cannot be empty");
            }
            else if (!txtPass.Text.Equals(txtRetypePass.Text))
            {
                MessageBox.Show("The passwords do not match");
            }
            else
            {
                try
                {
                    //UI
                    this.Cursor = Cursors.WaitCursor;
                    Application.DoEvents();

                    string msg = serv.CreateUser(txtUser.Text, txtPass.Text, txtName.Text, textBox1.Text, dateTimePicker1.Value);
                    
                    MessageBox.Show(msg);

                    if (msg.Equals("User already exists."))
                    {
                        err = true;
                    }
                }
                finally
                {
                    //UI
                    this.Cursor = Cursors.Default;
                }

                if (!err)
                {
                    this.Hide();

                    Form login = new LoginForm();
                    login.ShowDialog();

                    this.Close();   
                }
            }

        }

        private void SignInForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form login = new LoginForm();
            login.ShowDialog();

            this.Close();
        }
    }
}
