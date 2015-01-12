using ePubApp.ServiceReference1;
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
    public partial class Statistics : Form
    {
        Service1Client serv;
        public Statistics()
        {
            InitializeComponent();
            serv = new Service1Client();

        }

        private void Statistics_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            mostAccess();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mostFavoriteEbook();
        }

        private void mostAccess()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "Date";
            dataGridView1.Columns[1].Name = "Access's";
            List<DateStatisticsWeb> list = serv.getMostAccess().ToList();
            foreach (DateStatisticsWeb item in list)
            {
                DataGridViewRow linha = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                linha.Cells[0].Value = item.Date.Day + "-" + item.Date.Month + "-" + item.Date.Year;
                linha.Cells[1].Value = item.Acess;
                dataGridView1.Rows.Add(linha);
            }
            dataGridView1.Sort(this.dataGridView1.Columns[1], ListSortDirection.Descending);
        }

        private void mostFavoriteEbook()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "Book Name";
            dataGridView1.Columns[1].Name = "Number of Favorites";
            List<EBooks> list = serv.favoriteEBook().ToList();

            foreach (EBooks item in list)
            {
                DataGridViewRow linha = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                for (int i = 0; i < 4; i++)
                {
                    linha.Cells[0].Value = item.EBookName;
                    linha.Cells[1].Value = item.Count;
                }
                dataGridView1.Rows.Add(linha);
            }
            dataGridView1.Sort(this.dataGridView1.Columns[1], ListSortDirection.Descending);
        }

        private void mostFavoriteChapter()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Chapter Name";
            dataGridView1.Columns[1].Name = "Chapter Number";
            dataGridView1.Columns[2].Name = "Number of Favorites";
            List<Chapters> list = serv.favoriteChapter().ToList();

            foreach (Chapters item in list)
            {
                DataGridViewRow linha = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                for (int i = 0; i < 4; i++)
                {
                    linha.Cells[0].Value = item.ChapterName;
                    linha.Cells[1].Value = item.ChapterNumber;
                    linha.Cells[2].Value = item.Count;
                }
                dataGridView1.Rows.Add(linha);
            }
            dataGridView1.Sort(this.dataGridView1.Columns[1], ListSortDirection.Descending);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mostFavoriteChapter();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mostChapterBookmark();
        }

        private void mostChapterBookmark()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Chapter Name";
            dataGridView1.Columns[1].Name = "Chapter Number";
            dataGridView1.Columns[2].Name = "Number of Bookmarks";
            List<Chapters> list = serv.capitulosEbooksBookmark().ToList();

            foreach (Chapters item in list)
            {
                DataGridViewRow linha = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                for (int i = 0; i < 4; i++)
                {
                    linha.Cells[0].Value = item.ChapterName;
                    linha.Cells[1].Value = item.ChapterNumber;
                    linha.Cells[2].Value = item.Count;
                }
                dataGridView1.Rows.Add(linha);
            }
            dataGridView1.Sort(this.dataGridView1.Columns[1], ListSortDirection.Descending);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            mostBookBookmark();
        }

        private void mostBookBookmark()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "Book Name";
            dataGridView1.Columns[1].Name = "Number of Bookmarks";
            List<EBooks> list = serv.ebooksBookmark().ToList();

            foreach (EBooks item in list)
            {
                DataGridViewRow linha = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                for (int i = 0; i < 4; i++)
                {
                    linha.Cells[0].Value = item.EBookName;
                    linha.Cells[1].Value = item.Count;
                }
                dataGridView1.Rows.Add(linha);
            }
            dataGridView1.Sort(this.dataGridView1.Columns[1], ListSortDirection.Descending);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
            this.Close();
        }
    }
}
