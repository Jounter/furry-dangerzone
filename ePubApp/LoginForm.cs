using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ePubApp
{

    public partial class LoginForm : Form
    {
        private string username = "hey";
        private string pass = "123";
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == username && txtPass.Text == pass)
            {
                Menu li = new Menu();
                li.Show();

            }
            else
            {
                MessageBox.Show("Credenciais Invalidas");
            }


        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
