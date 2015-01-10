using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eBdb.EpubReader;
using System.IO;

namespace ePubApp
{
    public partial class Menu : Form
    {
        private string[] epubFiles;
        List<string> list = new List<string>();
        private string epubPath = "D:\\Escola\\1Semestre\\IS\\projeto\\trunk\\ePubBooks";
        public Menu()
        {
            InitializeComponent();
            byte[] bytes = Encoding.Default.GetBytes(epubPath);
            epubPath = Encoding.UTF8.GetString(bytes);
            epubFiles = Directory.GetFiles(epubPath, "*.epub").
                Select(path => Path.GetFileName(path)).ToArray();

            Epub livro;

                for (int i = 0; i < epubFiles.Count(); i++)
                {
                    string book = epubFiles.ElementAt(i);

                    string path = "D:\\Escola\\1Semestre\\IS\\projeto\\trunk\\ePubBooks\\" + book;

                    livro = null;
                    try
                    {
                        livro = new Epub(@path);
                        list.Add(livro.Title[0]);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error reading the following eBook:" + book);
                        list.Add(book + "- Corruped!");
                    }
                }



                listBox1.DataSource = list;


            

        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnConfigs_Click(object sender, EventArgs e)
        {
            Form config = new Configs();
            config.ShowDialog();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;

            string book = epubFiles.ElementAt(selectedIndex);
            
            string path = "D:\\Escola\\1Semestre\\IS\\projeto\\trunk\\ePubBooks\\" + book;

            Epub epub = null;
            Boolean error;
            try
            {
                epub = new Epub(@path);
                error = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Error opening eBook!");
                error = true;
            }

            if (error == false)
            {
                Book li = new Book(epub);
                li.Show();
            }

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to log out?", "Log Out", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                this.Hide();

                Form login = new LoginForm();
                login.ShowDialog();

                this.Close();
            }
            else if (dialog == DialogResult.No)
            {
                
            }
        }

        private void btnBM_Click(object sender, EventArgs e)
        {
            Form bookmacks = new Bookmarks();
            bookmacks.ShowDialog();
        }

    }
}

