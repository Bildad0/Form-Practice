using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
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
            this.AutoSize = true;

        }


        public void LoadData()
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
            LoadData();
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
            //Methods must be name to what they do,
            //fields must be name to what your mean/do.

            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                MessageBox.Show("Welcome "+nametextbox.Text);
            }
            using (var ctx = new DatabaseContext())
            {
                var User = new User()
                {
                    //was unable to change field name.
                    UserName = nametextbox.Text,
                    UserEmail = emailtextbox.Text,
                    UserAge= int.Parse(ageTextbox.Text),
                    UserCity = UsercityTextbox.Text
                };

                var Job = new Job(){ JobTitle=userjobtextbox.Text };

                User.UserJob = Job;

                ctx.Users.AddOrUpdate(User);
                ctx.SaveChanges();
                Reset();
                MessageBox.Show("Details saved successfully");
                LoadData();


            }
        }

      private void btnDelete_Click(User user)
        {
            using (var ctx = new DatabaseContext())
            { 

                var data = ctx.Users.Find(user.UserId);
                ctx.Users.Remove(data);
                ctx.SaveChanges();
                MessageBox.Show("User Deleted succesfully");
                LoadData();              
            }
        }

        public void Reset()
        {
            nametextbox.Text = "";
            ageTextbox.Text = "";
            emailtextbox.Text = "";
            UsercityTextbox.Text = "";
            userjobtextbox.Text = "";
        }

        public void EditDetails(int? UserId)
        {
            if (UserId == null)
            {
                MessageBox.Show("No such user!!");
            }
            using (var ctx= new DatabaseContext())
            {
                var data = ctx.Users.Find(UserId);
                var User = new User()
                {
                    //was unable to change field name.
                    UserName = nametextbox.Text,
                    UserEmail = emailtextbox.Text,
                    UserAge = int.Parse(ageTextbox.Text),
                    UserCity = UsercityTextbox.Text
                    //UserJob= userjobtextbox.Text
                    
                };
                ctx.Users.AddOrUpdate(User);
                ctx.SaveChanges();
                Reset();
                MessageBox.Show("Details update successfully");
                LoadData();

            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
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

            if (string.IsNullOrWhiteSpace(nametextbox.Text))
            {
                e.Cancel = true;
                nametextbox.Focus();
                errorProvider.SetError(nametextbox,"Name should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(nametextbox, "");
            }
        }

        private void EmailValidation(object sender, CancelEventArgs e)
        {
            //check if the input value is null
            if (string.IsNullOrWhiteSpace(emailtextbox.Text) && emailtextbox.Text.IndexOf("com")<0)
            {
                e.Cancel = true;
                emailtextbox.Focus();
                errorProvider.SetError(emailtextbox, "Email is required");
            }else if (emailtextbox.Text.IndexOf("@")>-1)
            {
                //check if there is '@' and a '.' in the correct order
                if (emailtextbox.Text.IndexOf(".") < emailtextbox.Text.IndexOf("@"))
                {
                    e.Cancel = true;
                    emailtextbox.Focus();
                    errorProvider.SetError(emailtextbox, "Use a valid Email");
                }
                
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(emailtextbox, "");
            }
        }

        //private void EditUser(object sender, CancelEventArgs e)
        //{
            
        //    using(var ctx= new DatabaseContext())
        //    {
        //        var std = ctx.Users.SingleOrDefault(x => x.UserId== x.UserId);
        //        if (std != null)
        //        {
        //            std.UserName = textBox1.Text;
        //            std.UserAge = int.Parse(textBox2.Text);
        //            std.UserEmail = textBox3.Text;
        //            std.UserCity = textBox4.Text;
        //            ctx.SaveChanges();
        //            MessageBox.Show("Details updated succesfully");
        //        }
        //    }
        //}

        private void EditUser(object sender, EventArgs e)
        {

            //EditDetails();
        }

        private void GetCellValue(object sender, DataGridViewCellEventArgs e)
        {
           using(var ctx = new DatabaseContext())
            {
                var data = ctx.Users.Select(
                    p=> new User()
                {
                    UserId=p.UserId
                });
             
            }
        }

        private void DeleteUser(object sender, EventArgs e)
        {
           
        }
    }
}
