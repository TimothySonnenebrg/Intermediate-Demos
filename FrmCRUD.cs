using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoDb.DB;

namespace DemoDB.GUI
{
    public partial class FrmCRUD : Form
    {
        private Database db;

        public FrmCRUD()
        {
            InitializeComponent();

            db = new Database();
        }

        private void FrmCRUD_Load(object sender, EventArgs e)
        {
            MessageBox.Show(db.ConnectionTest().ToString());

            try
            {
                ReBindUser(db.GetUsers());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Loading users failed: {ex.GetType()}");
            }
        }

       


       private void ReBindUser(DataTable dt)
        {
            if (dt.Rows.Count >= 1) 
            {
                dgvEmail.DataSource = null;
                dgvUser.DataSource = dt;
            }
        }

        // rebind email data grid view
        private void ReBindEmails(DataTable dt)
        {// have to update even if results are empty b/c some users might not have emails
         // ???: potential selection bug?
            dgvEmail.DataSource = null;
                dgvUser.DataSource = dt;          
        }

        private void dgvUser_SelectionChanged(object sender, EventArgs e)
        {
            txtFirstName.Text=dgvUser.CurrentRow.Cells["FirstName"].Value.ToString();

            txtLastName.Text = dgvUser.CurrentRow.Cells["LastName"].Value.ToString();

               


            try
            { //get selected id 



               int userid= Convert.ToInt32(dgvUser.CurrentRow.Cells["Id"].Value);  //takes number and converts it 

                

            }
            catch (Exception ex)
            {

                throw ex;
            }


            //use to populate user email.



        }

        private void btnDeleteEmail_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Delete selected user 

            try
            { //get selected id 



                int userid = Convert.ToInt32(dgvUser.CurrentRow.Cells["Id"].Value);  //takes number and converts it 
                //
                //delete selected user 
                db.DeleteUser(userid);


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //update selected user in db

     
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                int userid = Convert.ToInt32(dgvUser.CurrentRow.Cells["Id"].Value);  //takes number and converts it 

                if (db.UpdateUser(userid, txtFirstName.Text, txtLastName.Text) < 1)
                {
                    MessageBox.Show("user not updated");
                }
                else
                {
                    try
                    {
                        ReBindUser(db.GetUsers());
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show($"loading User failed {ex.GetType()} ");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update user: {ex.GetType()}");

            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //Deselect all users 
            dgvUser.ClearSelection();

            dgvEmail.DataSource = null;

            txtFirstName.Text = string.Empty;

            txtLastName.Text = string.Empty;

            txtFirstName.Focus();
        }


        //insert new user
        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {

                int userid = Convert.ToInt32(dgvUser.CurrentRow.Cells["Id"].Value);  //takes number and converts it 

                if (db.InsertUser(  txtFirstName.Text, txtLastName.Text) < 1)
                {
                    MessageBox.Show("user not inserted");
                }
                else
                {
                    try
                    {
                        ReBindUser(db.GetUsers());
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show($"loading User {ex.GetType()} ");
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        //Shows all users 
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            try
            {
                ReBindUser(db.GetUsers());
            }
            catch (Exception ex)
            {

                MessageBox.Show($"loading User {ex.GetType()} ");
            }
        }

        //query db for name that match substring

        private void btnSearchNames_Click(object sender, EventArgs e)
        {
            try
            {
                

                ReBindUser(db.SelectUsersByName(txtNameContains.Text));

            }
            catch (Exception ex)
            {

               MessageBox.Show($"search name failed{ex.GetType()} ");
            }
        }
    }
}
