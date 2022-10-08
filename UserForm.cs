using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserFormApp
{
    public partial class UserForm : Form
    {
       

        public UserForm()
        {
            InitializeComponent();
            
        }

        private void DisplayData()
        {
            List<User> _students = new List<User>();
            using (var ctx = new DatabaseContext())
            {
                _students = ctx.Users.ToList();
            }
            dataGridView1.DataSource = _students;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //You need to read the value from input fields....
            // Methods must be name to what they do,
            //fields must be name to what your mean/do.

            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                MessageBox.Show("Welcome "+textBox1.Text);
            }
            using (var ctx = new DatabaseContext())
            {
                var User = new User()
                {
                    //was unable to change field name.
                    UserName = textBox1.Text,
                    UserEmail = textBox3.Text,
                    UserAge= int.Parse(textBox2.Text),
                    UserCity = textBox4.Text
                }; 

                ctx.Users.Add(User);
                ctx.SaveChanges();
                MessageBox.Show("Details saved successfully");
            }
        }

      private void btnDelete_Click(object sender, EventArgs e)
        {
            using (var ctx = new DatabaseContext())
            {
                var data = ctx.Users.Where(x => x.UserId == x.UserId).First();
                ctx.Users.Remove(data);
                ctx.SaveChanges();
                MessageBox.Show("User Deleted succesfully");
            }
            UserForm NewForm = new UserForm();
            NewForm.Show();
            this.Dispose(false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            UserForm NewForm = new UserForm();
            NewForm.Show();
            this.Dispose(false);

        }

        private void City(object sender, EventArgs e)
        {

        }

        private void Email(object sender, EventArgs e)
        {
            
        }

        private void Age(object sender, EventArgs e)
        {

        }

        private void name(object sender, EventArgs e)
        {

        }

        private void txtInput_keyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void NameValidation(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                e.Cancel = true;
                textBox1.Focus();
                errorProvider.SetError(textBox1,"Name should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(textBox1, "");
            }
        }

        private void EmailValidation(object sender, CancelEventArgs e)
        {
            //check if the input value is null
            if (string.IsNullOrWhiteSpace(textBox3.Text) && textBox3.Text.IndexOf("com")<0)
            {
                e.Cancel = true;
                textBox3.Focus();
                errorProvider.SetError(textBox3, "Email is required");
            }else if (textBox3.Text.IndexOf("@")>-1)
            {
                //check if there is '@' and a '.' in the correct order
                if (textBox3.Text.IndexOf(".") < textBox3.Text.IndexOf("@"))
                {
                    e.Cancel = true;
                    textBox3.Focus();
                    errorProvider.SetError(textBox3, "Use a valid Email");
                }
                
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(textBox3, "");
            }
        }

        private void EditUser(object sender, EventArgs e)
        {
            using(var ctx= new DatabaseContext())
            {
                var std = ctx.Users.Where(x => x.UserId == x.UserId).First();
                std.UserName = textBox1.Text;
                std.UserAge = int.Parse(textBox2.Text);
                std.UserEmail = textBox3.Text;
                std.UserCity = textBox4.Text;

                ctx.SaveChanges();
                MessageBox.Show("Details updated succesfully");
            }
        }
    }
}
