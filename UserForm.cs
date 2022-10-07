using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserFormApp
{
    public partial class UserForm : Form
    {
        private object errorProviderApp;

        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {

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
                MessageBox.Show("Welcome "+textBox1.Text, "");
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

                MessageBox.Show("user saved successfully");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

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

        private void InputValidation(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                e.Cancel = true;
                textBox2.Focus();
                errorProvider.SetError(textBox1,"Name should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(textBox1, "");
            }
        }
    }
}
