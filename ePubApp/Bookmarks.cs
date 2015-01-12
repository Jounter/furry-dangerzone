using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ePubApp
{
    public partial class Bookmarks : Form
    {
        string logedUser;

        public Bookmarks(string logedUser)
        {
            InitializeComponent();

            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Book Name";
            dataGridView1.Columns[1].Name = "Chapter Name";
            dataGridView1.Columns[2].Name = "Chapter number";
            dataGridView1.Columns[3].Name = "Date";

            this.logedUser = logedUser;
            loadList();
        }

        private void loadList()
        {
            string folderpath = Directory.GetCurrentDirectory();
            XmlDocument xml = new XmlDocument();
            xml.Load(folderpath + "\\Bookmarks.xml");

            XmlNodeList bookmarks = xml.SelectNodes("bookmarks/bookmark");
            foreach (XmlNode item in bookmarks)
            {
                string bookname = "";
                string nameC = "";
                int numberC = 0;

                string username = item["owner"].InnerText;

                string data = item["date"].InnerText;

                if (logedUser == username)
                {
                    XmlNode book = item.SelectSingleNode("book");

                    bookname = book["bookname"].InnerText;

                    XmlNode chapter = book.SelectSingleNode("chapter");


                    nameC = chapter["chaptername"].InnerText;
                    numberC = Convert.ToInt32(chapter["chapternumber"].InnerText);

                    DataGridViewRow linha = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                    linha.Cells[0].Value = bookname;
                    linha.Cells[1].Value = nameC;
                    linha.Cells[2].Value = numberC;
                    linha.Cells[3].Value = data;
                    dataGridView1.Rows.Add(linha);

                    dataGridView1.Sort(this.dataGridView1.Columns[1], ListSortDirection.Descending);

                }


            }

        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lol = dataGridView1.SelectedCells[0].Value.ToString();

            //Form menu = new Menu(logedUser);

            //this.Dispose();
            //this.Close();
        }

        private void Bookmarks_Load(object sender, EventArgs e)
        {

        }
    }
}
