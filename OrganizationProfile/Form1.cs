using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganizationProfile
{
    public partial class frmRegistration : Form
    {
        private string _FullName;
        private int _Age;
        private long _ContactNo, _StudentNo;
        public frmRegistration()
        {

            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]{
                "BS Information Technology",
                "BS Computer Science",
                "BS Information Systems",
                "BS in Accountancy",
                "BS in Hostipality Management",
                "BS in Tourism Management"
                };
            for (int i = 0; i < 6; i++)
            {
                cbPrograms.Items.Add(ListOfProgram[i].ToString());
            }
            cbGender.Items.Add("Female");
            cbGender.Items.Add("Male");
        }
        /////return methods 
        public long StudentNumber(string studNum)
        {
            int countStudNumber = studNum.ToString().Length;
            try
            {

                if(studNum.Length ==0)
                {
                    throw new ArgumentNullException();
                }
                else if (!Regex.IsMatch(studNum, @"^[0-9]")){
                    throw new FormatException();
                }
                else if (countStudNumber != 11)
                {
                    throw new IndexOutOfRangeException(); 
                }
                else if (Regex.IsMatch(studNum, @"^[0-9]"))
                {
                   
                        _StudentNo = long.Parse(studNum);
                    Console.WriteLine(_StudentNo);
                }
                
            }
            catch (FormatException e)
            {
                MessageBox.Show("Please type numbers only.");
                textStudentNo.Focus();
            }
            catch (ArgumentNullException n)
            {
                MessageBox.Show("Student number cannot be empty.");
                textStudentNo.Focus();
                
            }
            catch (IndexOutOfRangeException n)
            {
                MessageBox.Show("Student number cannot have more than 11 digits.\n" +
                    "ex. 02000134719");
                textStudentNo.Focus();
            }
            return _StudentNo;
        }

        public long ContactNo(string Contact)
        {
            try
            {

                if (Contact.Length == 0)
                {
                    throw new ArgumentNullException();
                }
                else if (!Regex.IsMatch(Contact, @"^[0-9]"))
                {
                    throw new FormatException();
                }
                else if (Contact.Length != 11)
                {
                    throw new IndexOutOfRangeException();
                }
                else if (Regex.IsMatch(Contact, @"^[0-9]"))
                {

                    _ContactNo = long.Parse(Contact);
                }

            }
            catch (FormatException e)
            {
                MessageBox.Show("Please type numbers only.");
                txtContactNo.Clear();
                txtContactNo.Focus();
            }
            catch (ArgumentNullException n)
            {
                MessageBox.Show("Contact number cannot be empty.");
                txtContactNo.Focus();
            }
            catch (IndexOutOfRangeException n)
            {
                MessageBox.Show("Contact number cannot have more than 11 digits.\n" +
                    "ex. 09487880567");
                txtContactNo.Focus();
            }
            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            
                if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") || Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
                {
                    string lName = LastName.Substring(0, 1).ToUpper() + LastName.Substring(1, LastName.Length-1).ToLower();
                    string fName = FirstName.Substring(0, 1).ToUpper() + FirstName.Substring(1, FirstName.Length-1).ToLower();
                    _FullName = lName + ", " + fName + ", " + MiddleInitial.ToUpper()+".";
                }
            return _FullName;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            StudentInformationClass.SetFullName = FullName(txtLastName.Text,
                txtFirstName.Text, txtMiddleInitial.Text);
            StudentInformationClass.SetStudentNo = StudentNumber(textStudentNo.Text);
            Console.WriteLine(StudentInformationClass.SetStudentNo);
            StudentInformationClass.SetProgram = cbPrograms.Text;
            StudentInformationClass.SetGender = cbGender.Text;
            StudentInformationClass.SetContactNo = ContactNo(txtContactNo.Text);
            StudentInformationClass.SetAge = Age(txtAge.Text);
            StudentInformationClass.SetBirthday = datePickerBirthday.Value.ToString("MMM-" +
                "dd-yyyy");
            
                frmConfirmation frm = new frmConfirmation();
                frm.ShowDialog();
            
        }


        private void txtStudentNumber_Leave(object sender, EventArgs e)
        {
            StudentNumber(textStudentNo.Text);

        }

        private void txtContactNo_Leave(object sender, EventArgs e)
        {
            ContactNo(txtContactNo.Text);
        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAge_Leave(object sender, EventArgs e)
        {
            Age(txtAge.Text);
        }

        private void txtLastName_Leave(object sender, EventArgs e)
        {
            try
            {

                if (txtLastName.Text.Length == 0)
                {
                    throw new ArgumentNullException();
                }
                else if (Regex.IsMatch(txtLastName.Text, @"^[0-9]"))
                {
                    throw new FormatException();
                }
               

            }
            catch (FormatException h)
            {
                MessageBox.Show("Name cannot contain numbers.");
                txtLastName.Focus();
            }
            catch (ArgumentNullException n)
            {
                MessageBox.Show("Name number cannot be empty.");
                txtLastName.Focus();
            }

        }

        private void txtFirstName_Leave(object sender, EventArgs e)
        {
            try
            {

                if (txtFirstName.Text.Length == 0)
                {
                    throw new ArgumentNullException();
                }
                else if (Regex.IsMatch(txtFirstName.Text, @"^[0-9]"))
                {
                    throw new FormatException();
                }

            }
            catch (FormatException h)
            {
                MessageBox.Show("Name cannot contain numbers.");
                txtFirstName.Focus();
            }
            catch (ArgumentNullException n)
            {
                MessageBox.Show("Name number cannot be empty.");
                txtFirstName.Focus();
            }
        }

        public int Age(string age)
        {
            
            try
            {

                if (age.Length == 0)
                {
                    throw new ArgumentNullException();
                }
                else if (!Regex.IsMatch(age, @"^[0-9]"))
                {
                    throw new FormatException();
                }
                
                else if (Regex.IsMatch(age, @"^[0-9]"))
                {

                    _Age = Int32.Parse(age);
                    if (_Age<15||_Age>100)
                    {
                        throw new IndexOutOfRangeException();
                    }
                }

            }
            catch (FormatException e)
            {
                MessageBox.Show("Please type numbers only.");
                txtAge.Clear();
                txtAge.Focus();
            }
            catch (ArgumentNullException n)
            {
                MessageBox.Show("Age number cannot be empty.");
                txtAge.Focus();
            }
            catch (IndexOutOfRangeException n)
            {
                MessageBox.Show("Age cannot be younger than 15 and older than 100.");
                txtAge.Focus();
            }

            return _Age;

}

}
}
