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
        private string epubPath = "D:\\Escola\\1Semestre\\IS\\projeto\\trunk\\ePubBooks";
        public Menu()
        {
            InitializeComponent();
            byte[] bytes = Encoding.Default.GetBytes(epubPath);
            epubPath = Encoding.UTF8.GetString(bytes);
            epubFiles = Directory.GetFiles(epubPath, "*.epub").
                Select(path => Path.GetFileName(path)).ToArray();
            listBox1.DataSource = epubFiles.ToList();

       


        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnConfigs_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

    }
}

