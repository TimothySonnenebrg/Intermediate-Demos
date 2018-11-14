using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoDbObjects.BL;


namespace DemoDbObjects.GUI
{
    public partial class FrmCRUD : Form
    {
        UserCollection users;

        

        public FrmCRUD()
        {
            InitializeComponent();
            users = new UserCollection();
        }

        // populate the inital user list
        private void FrmCRUD_Load(object sender, EventArgs e)
        {
            users.LoadUsers();
            RebindUser();
           
        }

        // rebind email data grid view
        private void RebindEmail()
        {

        }

        // rebind user data grid view
        private void RebindUser()
        {
            if (users.Count >= 1)
            {
                dgvUser.DataSource = null;
                dgvUser.DataSource = users;

            }
        }

        // populate user details when selected user changes
        private void dgvUser_SelectionChanged(object sender, EventArgs e)
        {
            txtFirstName.Text = dgvUser.CurrentRow.Cells["FirstName"].Value.ToString();
            txtLastName.Text = dgvUser.CurrentRow.Cells["LastName"].Value.ToString();
        }

        // delete the selected user from the database
        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        // update the selected user in the database
        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        // deselect all users
        private void btnNew_Click(object sender, EventArgs e)
        {
            dgvUser.ClearSelection();
            dgvEmail.DataSource = null;
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtFirstName.Focus();
        }

        // insert a new user
        private void btnInsert_Click(object sender, EventArgs e)
        {

        }

        // show all users
        private void btnShowAll_Click(object sender, EventArgs e)
        {

        }

        // query the database for names which match the given substring
        private void btnSearchNames_Click(object sender, EventArgs e)
        {
 
        }
    }
}
