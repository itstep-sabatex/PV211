using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFDataSetDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cafe.People' table. You can move, or remove it, as needed.
            this.peopleTableAdapter.Fill(this.cafe.People);

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.peopleTableAdapter.Update(this.cafe);
            this.cafe.WriteXml("C:/tmp/people.xml");
            this.cafe.ReadXml("C:/tmp/people.xml");
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Id",typeof(int)));
            DataRow dr = dt.NewRow();
            dr["Id"] = 10;
            dt.Rows.Add(dr);

        }
    }
}
