using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fresher;

namespace FreshersInfo
{
    
    public partial class Fresher : Form
    {
        FresherDetail fresher = new FresherDetail();
        
        
        public Fresher()
        {
            InitializeComponent();
        }

        private void viewOption_Click(object sender, EventArgs e)
        {
            ViewFresher viewFresher = new ViewFresher();
            viewFresher.ShowDialog();
        }

        private void createOption_Click(object sender, EventArgs e)
        {
            CreateFresher createFresher = new CreateFresher();
            createFresher.ShowDialog();
        }

        private void exitOption_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
