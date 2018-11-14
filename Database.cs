using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //dataset datatable
using System.Data.SqlClient;


namespace DemoDb.DB
{
    public class Database
    {
        //database Connection info

        private SqlConnection conn;


        public Database()
        {

            //sql connection string builder is new builder

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "sonnenberglimited2.database.windows.net";

            builder.InitialCatalog = "sonnenbergdb2";

            builder.UserID = "sonnenbergdb2";

            builder.Password = "Test123!";


            conn = new SqlConnection(builder.ConnectionString);  //New Conection
        }

        //test conn
        public bool ConnectionTest()
        {
            conn.Open();

            bool result = conn.State == ConnectionState.Open;

            conn.Close();

            return result;
        }


        // get all users from the user table
        // can throw exceptions (catch in caller)

        public DataTable GetUsers()
        {
            // connect to the db

            conn.Open();

            //construct the query
            string sql = "Select * from [dbo].[MdDemoUser];";

            SqlCommand query = new SqlCommand(sql,conn);  //run sql on tihs server not do it 


            //run Query sql command

            SqlDataReader reader = query.ExecuteReader();  //cmd run 

            //reformat results to data table 

            DataTable results = new DataTable();

            results.Load(reader);


            //close and return
            conn.Close();

            return results;
        }


        //delete email address





        //delete user

        public int DeleteUser(int userId)
        {
            //SQL DElete user
            string sqlDeleteEmails = "DELETE FROM [dbo].[MdDemoEmail] WHERE UserId - @UserId;";

            SqlCommand cmdDeleteEmails = new SqlCommand(sqlDeleteEmails, conn);

            cmdDeleteEmails.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;



            string sqlDeleteUser = "DELETE FROM [dbo].[MdDemoEmail] WWERE Id - @UserId;";

            SqlCommand cmdDeleteUser = new SqlCommand(sqlDeleteUser, conn);

            cmdDeleteUser.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;  //Bind Value 
            //Does the same thing that add with avlue

            conn.Open();

            int emailAffectedRows = cmdDeleteEmails.ExecuteNonQuery();

            int userAffectedRows = cmdDeleteUser.ExecuteNonQuery();

            conn.Close();

            return userAffectedRows;
        }


        //Insert user 


            public int InsertUser(string firstName, string lastName)
            {
                    string sql = "Insert Into [dbo].[MdDemoEmail]  (FirstName,LastName) Values (@FirstName, @LastName=); ";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = firstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = lastName;

                    conn.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();


                    conn.Close();


                    return rowsAffected;
            }


        //Update exsisting user

            public int UpdateUser(int userId, string firstName, string lastName)
        {
            string sql = "UPDATE [dbo].[MdDemoEmail] SET FirstName = @FirstName, LastName = @LastName WHERE Id = @UserId; ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
            cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = firstName;
            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = lastName;

            conn.Open();

            int rowsAffected = cmd.ExecuteNonQuery();


            conn.Close();


            return rowsAffected;
        }




        // get email addresses for a given user
        public DataTable GetEmails(int userId)
        {

            //should beconverted into a transaction 
            //or alter db to archive deleted information
            // construct the SQL
            // concatenated string query == DEATH!
            //string sql = "SELECT Id, EmailAddress, Verified FROM [dbo].[MdDemoEmail] WHERE UserId = '" + userId.ToString() +  "';";

            // parameterized query (@UserID is the SQL parameter)
            string sql = "SELECT Id, EmailAddress, Verified FROM [dbo].[MdDemoEmail] WHERE UserID = @UserID;";
            SqlCommand query = new SqlCommand(sql, conn);
            query.Parameters.AddWithValue("@UserID", userId);  // infers DB column type for value conversion

            // open the connection
            conn.Open();

            // execute the query
            // convert query results to a DataTable
            SqlDataAdapter adapter = new SqlDataAdapter(query);  // create a db to RAM mapping
            DataTable results = new DataTable();

            // run the select and use those results to fill the datatable (query executes here)
            adapter.Fill(results);

            conn.Close();
            return results;

        }


        //Select uers by name

        public DataTable SelectUsersByName(string nameContains)
        {
            string sql = "SELECT * FROM [dbo].[MdDemoUser] WHERE FirstName LIKE '%' + @NameContains + '%' OR LastName LIKE '%' + '%';";

            SqlCommand query = new SqlCommand(sql, conn);

            query.Parameters.AddWithValue("@NameContains", SqlDbType.NVarChar).Value = nameContains;

            SqlDataReader reader = query.ExecuteReader();

            

            DataTable results = new DataTable();

            results.Load(reader);

            conn.Close();

            return results;
        }


        //get email address for user 







        //update email address




    }
}
