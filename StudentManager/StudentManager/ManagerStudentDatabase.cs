using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace StudentManager
{
    // the data base must have already created before
    internal class ManagerStudentDatabase
    {
        private string connectString = "Server=xichxo\\SQLEXPRESS;" +
            "Database=ManagerStudentDB;Integrated Security=True;";
       
        // return a new SqlConnection object
        public SqlConnection Connection { get { return new SqlConnection(connectString); } }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }


        public bool AddAccount(string user_name, string pass_word)
        {
            using (SqlConnection connection = Connection) 
            {
                connection.Open();

                if (HaveUsernameInTheDB(user_name)) return false;

                string insertAccountQuery = "INSERT INTO Accounts (username, password)" +
                        "VALUES " +
                        "(@username, @password)";
                using (SqlCommand insertAccountCmd = new SqlCommand(insertAccountQuery, connection))
                {
                    insertAccountCmd.Parameters.Add("@username", System.Data.SqlDbType.VarChar).Value = user_name;
                    insertAccountCmd.Parameters.Add("@password", System.Data.SqlDbType.VarChar).Value = HashPassword(pass_word);
                    insertAccountCmd.ExecuteNonQuery();
                    return true;
                }
            }
            

        }

        public bool HaveUsernameInTheDB(string user_name)
        {
            using (SqlConnection connection = Connection)
            {
                connection.Open();


                SqlCommand checkingCmd = new SqlCommand("SELECT * FROM Accounts WHERE username = @username", connection);
                checkingCmd.Parameters.Add("@username", System.Data.SqlDbType.VarChar).Value = user_name;

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = checkingCmd;

                DataTable table = new DataTable();
                adapter.Fill(table);

                if (table.Rows.Count > 0) return true;
                else return false;
            }
            
        }

        private string GetHashPasswordFromDB(string user_name)
        {
            if (!HaveUsernameInTheDB(user_name)) return "This default hash password is for no existing username";

            using (SqlConnection connection = Connection)
            {
                connection.Open();

                string getHashQuery = "SELECT password " +
                    "FROM Accounts " +
                    "WHERE username = @username";
                using (SqlCommand getHashCmd = new SqlCommand(getHashQuery, connection))
                {
                    getHashCmd.Parameters.Add("@username", SqlDbType.VarChar).Value = user_name;

                    SqlDataReader reader = getHashCmd.ExecuteReader();
                    reader.Read();
                    return (string)reader["password"];
                }
            }
        }

        public bool DeleteAccount(string user_name, string pass_word)
        {
            using (SqlConnection connection = Connection)
            {
                connection.Open();


                string hashedPasswordFromDatabase = GetHashPasswordFromDB(user_name);

                if (VerifyPassword(pass_word, hashedPasswordFromDatabase))
                {
                    string deleteQuery = "DELETE " +
                        "FROM Accounts " +
                        "WHERE username = @username";
                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, connection))
                    {
                        deleteCmd.Parameters.Add("@username", SqlDbType.VarChar).Value = user_name;
                        deleteCmd.ExecuteNonQuery();
                    }

                    return true;
                }

                return false;
            }

            

        }

        public bool HaveAccount(string user_name, string pass_word)
        {
            if (!HaveUsernameInTheDB(user_name)) return false;
            if (VerifyPassword(pass_word, GetHashPasswordFromDB(user_name)))
            {
                return true;
            }
            return false;
        }

        public bool AddStudent(Student student)
        {
            /*
             
            create table Students(
               studentID varchar(255) primary key,
               first_name nvarchar(255) not null,
               last_name nvarchar(255) not null,
               phone_number varchar(255) not null unique,
               birth_day datetime not null,
               gender varchar(20) not null,
               std_address nvarchar(255) not null,
               std_image varbinary(MAX) not null
            )

             */

            if (HaveStudent(student.Id))
            {
                return false;
            }

            using (SqlConnection connection = Connection)
            {
                connection.Open();

                string insertAccountQuery = "INSERT INTO Students " +
                        "VALUES " +
                        "(@studentID, @first_name, @last_name, @phone_number, @birth_day, @gender, @std_address, @std_image)";
                using (SqlCommand insertAccountCmd = new SqlCommand(insertAccountQuery, connection))
                {
                    insertAccountCmd.Parameters.Add("@studentID", SqlDbType.VarChar).Value = student.Id;
                    insertAccountCmd.Parameters.Add("@first_name", SqlDbType.VarChar).Value = student.FirstName;
                    insertAccountCmd.Parameters.Add("@last_name", SqlDbType.VarChar).Value = student.LastName;
                    insertAccountCmd.Parameters.Add("@phone_number", SqlDbType.VarChar).Value = student.PhoneNumber;
                    insertAccountCmd.Parameters.Add("@birth_day", SqlDbType.DateTime).Value = student.BirthDay;
                    insertAccountCmd.Parameters.Add("@gender", SqlDbType.VarChar).Value = student.Gender;
                    insertAccountCmd.Parameters.Add("@std_address", SqlDbType.VarChar).Value = student.Address;
                    insertAccountCmd.Parameters.Add("@std_image", SqlDbType.VarBinary).Value = student.ImageData;

                    
                    if (insertAccountCmd.ExecuteNonQuery() > 0) return true;
                    return false;
                    
                }
            }
        }

        public bool HaveStudent(string studentID)
        {
            using (SqlConnection connection = Connection)
            {
                connection.Open();


                SqlCommand checkingCmd = new SqlCommand("SELECT * FROM Students WHERE studentID = @studentID", connection);
                checkingCmd.Parameters.Add("@studentID", SqlDbType.VarChar).Value = studentID;

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = checkingCmd;

                DataTable table = new DataTable();
                adapter.Fill(table);

                if (table.Rows.Count > 0) return true;
                else return false;
            }
        }








    }
}
