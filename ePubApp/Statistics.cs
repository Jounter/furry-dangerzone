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
            doTable();
           
        }
        private void doTable()
        {
            dataGridView1.Rows.Clear();
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
    }
}
