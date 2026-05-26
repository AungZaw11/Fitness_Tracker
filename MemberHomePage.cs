using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitnessTracker
{
    public partial class MemberHomePage : Form
    {
        public MemberHomePage()
        {
            InitializeComponent();
        }

        private void MemberHomePage_Load(object sender, EventArgs e)
        {
            lblwelcome.Text = "Welcome to" + LoginForm.uname;
        }


    }
}
