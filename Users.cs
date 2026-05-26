using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker
{
    class Users
    {
        string UserID, FulLName, UserName, Password, Gender, Phonenumber, Address, Role, MPosition;
        int Weight, Height, MFees;
        DateTime DOB;


        public string userid
        {
            get
            {
                return UserID;
            }
            set
            {
                UserID = value;
            }
        }
        public string fullname
        {
            get
            {
                return FulLName;
            }
            set
            {
                FulLName = value;
            }

        }
        public string username
        {
            get
            {
                return UserName;
            }
            set
            {
                UserName = value;
            }

        }
        public string password
        {
            get
            {
                return Password;
            }
            set
            {
                Password = value;
            }

        }
        public string gender
        {
            get
            {
                return Gender;
            }
            set
            {
                Gender = value;
            }

        }
        public string phonenumber
        {
            get
            {
                return Phonenumber;
            }
            set
            {
                Phonenumber = value;
            }

        }
        public string address
        {
            get
            {
                return Address;
            }
            set
            {
                Address = value;
            }

        }
        public string role
        {
            get
            {
                return Role;
            }
            set
            {
                Role = value;
            }

        }
        public int weight
        {
            get
            {
                return Weight;
            }
            set
            {
                Weight = value;
            }
        }
        public int height
        {
            get
            {
                return Height;
            }
            set
            {
                Height = value;
            }
        }
        public DateTime dob
        {
            get
            {
                return DOB;
            }
            set
            {


                DOB = value;
            }


        }
        public int MemberFees
        {
            get
            {
                return MFees;
            }
            set
            {
                MFees = value;
            }
        }
        public string Position
        {
            get
            {
                return MPosition;
            }
            set
            {
                MPosition = value;
            }
        }
    }

}






