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
    public partial class Favorites : Form
    {
        public Favorites()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Form book = new Book();
            //book.ShowDialog();

            this.Dispose();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
