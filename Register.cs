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



    public partial class Register : Form
    {
        dbFitness_TrackerTableAdapters.AdminTableAdapter ads = new dbFitness_TrackerTableAdapters.AdminTableAdapter();
        dbFitness_TrackerTableAdapters.MemberTableAdapter mds = new dbFitness_TrackerTableAdapters.MemberTableAdapter();
        dbFitness_TrackerTableAdapters.UsersTableAdapter uds = new dbFitness_TrackerTableAdapters.UsersTableAdapter();


        String Role;
        String g;
        int mautoid;
        int aid;
        public Register()
        {
            InitializeComponent();
        }
        /*AutoUser ID*/
        private void AutoUserID()
        {
            DataTable udt, mdt, adt = new DataTable();
            udt = uds.GetData();
            mdt = mds.GetData();
            adt = ads.GetData();

            if (udt.Rows.Count == 0)
            {
                lbluserid.Text = "U001";

            }
            else
            {
                int sizerow = udt.Rows.Count - 1;
                string oldid = udt.Rows[sizerow][0].ToString();
                int newid = Convert.ToInt32(oldid.Substring(1, 3));
                if (newid >= 0 && newid <= 9)
                {
                    lbluserid.Text = "U001" + (newid + 1);

                }

            }
            if (mdt.Rows.Count == 0)
            {
                mautoid = 1;

            }
            else
            {
                int sizerow = mdt.Rows.Count - 1;
                int newid = Convert.ToInt32(mdt.Rows[sizerow][0]);

                if (newid >= 0 && newid <= 9)
                {
                    mautoid = newid + 1;

                }

            }
            if (adt.Rows.Count == 0)
            {
                aid = 1;

            }
            else
            {
                int sizerow = adt.Rows.Count - 1;
                int newid1 = Convert.ToInt32(adt.Rows[sizerow][0]);

                if (newid1 >= 0 && newid1 <= 9)
                {
                    aid = newid1 + 1;

                }

            }
        }
        private void Cleardata()
        {
            txtFullname.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
            cboRole.Text = "";
            txtphnumber.Text = "";
            txtheight.Text = "";
            txtaddress.Text = "";
            txtMemberfee.Text = "";
            txtPosition.Text = "";



        }



        private string checkgender()
        {

            if (rdofemale.Checked == true)
            {
                g = "Female";
            }
            else if (rdomale.Checked == true)
            {
                g = "Male";
            }
            return g;

        }



        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }



        private void cboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            String Role = "";
            Role = cboRole.SelectedItem.ToString();


            if (Role == "Member")
            {
                txtPosition.Enabled = false;
                txtMemberfee.Enabled = true;

            }
            else if (Role == "Admin")
            {
                txtMemberfee.Enabled = false;
                txtPosition.Enabled = true;
            }



        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtMemberfee_TextChanged(object sender, EventArgs e)
        {

        }

        private void Register_Load(object sender, EventArgs e)
        {
            rdomale.Checked = true;
            AutoUserID();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string UserName, Password, Password1;
            UserName = txtUserName.Text;
            Password = txtPassword.Text;
            Password1 = @"%!@#$%^&*()?/<.>:;'\|/}]{[_~";
            char[] Password2 = Password1.ToCharArray();
            foreach (char ch in Password2)
            {
                if (!Password.Contains(ch))
                {

                    MessageBox.Show("Special Char", "Register", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }


            if (ValidateChildren(ValidationConstraints.Enabled))

            {
                MessageBox.Show(txtUserName.Text, "Demo App - Message!");


            }

            else if (UserName.Length < 8)

            {
                MessageBox.Show("8 character", "Register", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.SelectAll();
                txtUserName.Focus();


            }
            else if (Password.Length < 8 || Password.Length > 15)
            {
                MessageBox.Show("8 and 15", "Register", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.SelectAll();
                txtPassword.Focus();

            }
            else if (!Password.Any(Char.IsUpper))
            {
                MessageBox.Show("Upper Char", "Register", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (!Password.Any(Char.IsLower))
            {
                MessageBox.Show("Lower Char", "Register", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (!Password.Contains(" "))
            {
                MessageBox.Show("Space Character", "Register", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                Users u = new Users();
                u.userid = lbluserid.Text;
                u.fullname = txtFullname.Text;
                u.username = txtUserName.Text;
                u.password = txtPassword.Text;
                u.gender = g;
                u.phonenumber = txtphnumber.Text;
                u.address = txtaddress.Text;
                u.role = cboRole.SelectedItem.ToString();
                u.weight = Convert.ToInt32(txtweight.Text);
                u.height = Convert.ToInt32(txtheight.Text);
                u.dob = dtpdob.Value;

                u.Position = txtPosition.Text;

                if (cboRole.SelectedIndex == 0)
                {
                    uds.Insert(u.userid, u.fullname, u.username, u.password, u.gender, u.dob, u.weight, u.height, u.phonenumber, u.address, u.role);
                    int adata = ads.Insert(aid, u.Position, u.userid);
                    if (adata > 0)
                    {
                        MessageBox.Show("Admin Sucessful", "User Resgister", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Cleardata();
                        AutoUserID();
                        txtUserName.Focus();
                    }


                }
                else
                {
                    u.MemberFees = Convert.ToInt32(txtMemberfee.Text);

                    uds.Insert(u.userid, u.fullname, u.username, u.password, u.gender, u.dob, u.weight, u.height, u.phonenumber, u.address, u.role);
                    int mdata = mds.Insert(mautoid, u.MemberFees, u.Position);
                    if (mdata > 0)
                    {
                        MessageBox.Show("Admin Register Sucessful", "User Resgister", MessageBoxButtons.OK, MessageBoxIcon.Error);





                    }
                    uds.Insert(u.userid, u.fullname, u.username, u.password, u.gender, u.dob, u.weight, u.height, u.phonenumber, u.address, u.role);
                    mds.Insert(mautoid, u.MemberFees, u.Position);
                    ads.Insert(aid, u.Position, u.userid);
                }



            }

        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtUserName.Text))
            {
                //e.Cancel = true;
                //txtUserName.Focus();
                //ErrorProvider.R
                MessageBox.Show("Null", "Register", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}




