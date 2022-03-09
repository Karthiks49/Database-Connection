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
using System.Data;
using System.Configuration;

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
            listView.DataSource = GetFreshers();
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
            FresherDetail fresher =  new FresherDetail(name, dateOfBirth.ToString("yyyy/MM/dd"), mobileNumer, address, qualification);
            fresher.id = id;
            createFresher.GetValues(fresher);
            createFresher.ShowDialog();
            Display();
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
                Display();
            }
        }

        private DataTable GetFreshers()
        {
            DataTable freshersTable = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["FreshersInfo.Properties.Settings.FresherManagementConnectionString"].ConnectionString;

            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand("select * from Freshers", connection);
                
            connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(freshersTable);
            connection.Close();
            
            return freshersTable;
        }
    }
}
