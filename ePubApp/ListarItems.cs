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
    public partial class ListarItems : Form
    {
        private string[] epubFiles;
        private string epubPath = Path.GetFullPath("E:\\IPL\\3 Ano\\IS\\IS\\trunk");
        public ListarItems()
        {
            InitializeComponent();
            byte[] bytes = Encoding.Default.GetBytes(epubPath);
            epubPath = Encoding.UTF8.GetString(bytes);
            MessageBox.Show(epubPath);
            epubFiles = Directory.GetFiles(epubPath, "*.epub").
                Select(path => Path.GetFileName(path)).ToArray();
            MessageBox.Show(epubPath);
            listBox1.DataSource = epubFiles.ToList();

       


        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Epub epub = new Epub(listBox1.SelectedItem.ToString());
            ApresentaEpub ape = new ApresentaEpub(epub);
            ape.Show();
        }

    }
}

