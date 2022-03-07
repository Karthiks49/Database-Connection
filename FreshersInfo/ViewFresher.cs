using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Fresher;
using System.Data.SqlClient;

namespace FreshersInfo
{
    public partial class ViewFresher : Form
    {
        public ViewFresher()
        {
            InitializeComponent();
            Display();
        }

        public void Display()
        {
                        Freshermanagement freshermanagement = new Freshermanagement();
            SqlDataReader reader = freshermanagement.GetAllFreshers();
            listView.DataSource = reader;
            //listView.DataSource;
        }

        private void update_Click(object sender, EventArgs e)
        {
            var createFresher = new CreateFresher();
            int id = int.Parse(listView.SelectedCells[0].Value.ToString());
            string name = listView.SelectedCells[1].Value.ToString();
            DateTime dateOfBirth = DateTime.Parse(listView.SelectedCells[2].Value.ToString());
            long mobileNumer = long.Parse(listView.SelectedCells[3].Value.ToString());
            string address = listView.SelectedCells[4].Value.ToString();
            string qualification = listView.SelectedCells[5].Value.ToString();
            createFresher.id = id;
            FresherDetail fresher =  new FresherDetail(name, dateOfBirth.ToString("yyyy/MM/dd"), mobileNumer, address, qualification);
            createFresher.GetValues(fresher);

            createFresher.ShowDialog();
            listView.Refresh();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var createFresher = new CreateFresher();
                int id = int.Parse(listView.SelectedCells[0].Value.ToString());
                string name = listView.SelectedCells[1].Value.ToString();
                createFresher.DeleteFresher(id, name);
            }
        }

        private void ViewFresher_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fresherManagementDataSet2.Freshers' table. You can move, or remove it, as needed.
            this.freshersTableAdapter1.Fill(this.fresherManagementDataSet2.Freshers);

            /*            Freshermanagement freshermanagement = new Freshermanagement();
                        SqlDataReader reader = freshermanagement.GetAllFreshers();
                        listView.DataSource = reader;*/
        }
    }
}
