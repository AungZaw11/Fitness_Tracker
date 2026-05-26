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
    public partial class LoginForm : Form
    {
        dbFitness_TrackerTableAdapters.UsersTableAdapter uds = new dbFitness_TrackerTableAdapters.UsersTableAdapter();
        int count = 0;
        public static string uname;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string UName, UPassword, URole;
            UName = txtusername.Text;
            UPassword = txtpassword.Text;
            URole = cborole.SelectedItem.ToString();
            uds.CheckUserdData(UName, UPassword, URole);
            if(dt.Rows.Count>0)
            {
                uname = dt.Rows[0][1].ToString();
                string urole = dt.Rows[0]["Role"].ToString();
                if(urole=="Admin")
                {
                    MessageBox.Show("AdminLogin Successful", "Login Form", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    AdminHomePage ah = new AdminHomePage();
                    ah.ShowDialog();


                }
                else if( urole =="Member")
                {
                    MessageBox.Show("AdminLogin Successful", "Login Form", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    MemberHomePage mh = new MemberHomePage();
                    mh.ShowDialog();
                }
            }
               
            
            else
            {
                MessageBox.Show("Fail Login", "LoginForm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                int count =+ 1;
                {
                   if(count >=3)
                    {
                        MessageBox.Show("Over Three Time Login", "Login Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }


            }
        }
    }
}
