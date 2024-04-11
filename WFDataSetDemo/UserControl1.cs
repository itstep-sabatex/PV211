using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFDataSetDemo
{
    public partial class UserControl1: UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            this.clientsTableAdapter.Fill(this.dataSet1.Clients);
            this.invoicesTableAdapter.Fill(this.dataSet1.Invoices);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.invoicesTableAdapter.Update(this.dataSet1);
           // this.cafe.WriteXml("c:/tmp/cafe.xml");

        }

        private void invoicesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.invoicesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet1);

        }

        private void invoicesDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void invoicesBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            var row = this.dataSet1.Invoices.NewInvoicesRow();
            row.Date = DateTime.Now;
             e.NewObject = row;
            
        }
    }
}
