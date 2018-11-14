using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DemoDbObjects.PL;

namespace DemoDbObjects.BL
{
    public class UserCollection : List<User>
    {
        public void LoadUsers()
        {
            //select users from db
            string sql = "SELECT * FROM [dbo].[sonnenbergdb2];";

            

            SqlCommand query = new SqlCommand();
            Database db = new Database();

            DataTable userTable = db.Get(query);


            //Loop through user rows 
            foreach (DataRow dr in userTable.Rows)
            {
                //constructing new user object 
                User u = new User();

                u.Id = Convert.ToInt32(dr["Id"]);

                u.FirstName = dr["FirstName"].ToString();

                u.LastName = dr["LastName"].ToString();


                this.Add(u);
            }
              //select all emails for user and populate user email list

              //Add new user object to this user collection
        }

    }
}
