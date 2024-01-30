using System;
using System.Collections;
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
    internal class StudentDatabaseManager
    {
        private string connectString = "Server=xichxo\\SQLEXPRESS;Database=ManagerStudentDB;Integrated Security=True;";
       
        // return a new SqlConnection object
        public SqlConnection Connection 
        { 
            get 
            { 
                return new SqlConnection(connectString);
            }
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());
        }

        // return true if hasdedPassword is password's
        private bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        public bool AddAccount(string userName, string passWord)
        {
            try
            {
                using (SqlConnection connection = Connection)
                {
                    connection.Open();

                    if (HaveUsernameInTheDB(userName)) return false;

                    string insertAccountQuery = "INSERT INTO Accounts (username, password)" +
                            "VALUES " +
                            "(@username, @password)";
                    using (SqlCommand insertAccountCmd = new SqlCommand(insertAccountQuery, connection))
                    {
                        insertAccountCmd.Parameters.Add("@username", System.Data.SqlDbType.VarChar).Value = userName;
                        insertAccountCmd.Parameters.Add("@password", System.Data.SqlDbType.VarChar).Value = HashPassword(passWord);
                        if (insertAccountCmd.ExecuteNonQuery() == 1) return true;
                        return false;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
            
            

        }

        public bool HaveUsernameInTheDB(string userName)
        {
            try
            {
                using (SqlConnection connection = Connection)
                {
                    connection.Open();


                    SqlCommand checkingCmd = new SqlCommand("SELECT * FROM Accounts WHERE username = @username", connection);
                    checkingCmd.Parameters.Add("@username", System.Data.SqlDbType.VarChar).Value = userName;

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = checkingCmd;

                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    if (table.Rows.Count == 1) return true;
                    return false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        private string GetHashPasswordFromDB(string userName)
        {
            try
            {
                using (SqlConnection connection = Connection)
                {
                    connection.Open();

                    string getHashQuery = "SELECT password " +
                        "FROM Accounts " +
                        "WHERE username = @username";
                    using (SqlCommand getHashCmd = new SqlCommand(getHashQuery, connection))
                    {
                        getHashCmd.Parameters.Add("@username", SqlDbType.VarChar).Value = userName;

                        SqlDataReader reader = getHashCmd.ExecuteReader();
                        reader.Read();
                        return (string)reader["password"];
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null;
            }
        }

        public bool DeleteAccount(string userName, string passWord)
        {
            try
            {
                using (SqlConnection connection = Connection)
                {
                    connection.Open();


                    string hashedPasswordFromDatabase = GetHashPasswordFromDB(userName);

                    if (VerifyPassword(passWord, hashedPasswordFromDatabase))
                    {
                        string deleteQuery = "DELETE " +
                            "FROM Accounts " +
                            "WHERE username = @username";
                        using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, connection))
                        {
                            deleteCmd.Parameters.Add("@username", SqlDbType.VarChar).Value = userName;
                            deleteCmd.ExecuteNonQuery();
                        }

                        return true;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }

        }

        public bool HaveAccount(string userName, string passWord)
        {
            if (HaveUsernameInTheDB(userName) && VerifyPassword(passWord, GetHashPasswordFromDB(userName)) ) return true;
            return false;
        }

        public bool AddStudent(Student student)
        {
            try
            {
                using (SqlConnection connection = Connection)
                {
                    connection.Open();

                    string insertStudentQuery = "INSERT INTO Students " +
                            "VALUES " +
                            "(@studentID, @first_name, @last_name, @phone_number, @birth_day, @gender, @std_address, @std_image)";
                    using (SqlCommand insertStudentCmd = new SqlCommand(insertStudentQuery, connection))
                    {
                        insertStudentCmd.Parameters.Add("@studentID", SqlDbType.VarChar).Value = student.Id;
                        insertStudentCmd.Parameters.Add("@first_name", SqlDbType.NVarChar).Value = student.FirstName;
                        insertStudentCmd.Parameters.Add("@last_name", SqlDbType.NVarChar).Value = student.LastName;
                        insertStudentCmd.Parameters.Add("@phone_number", SqlDbType.VarChar).Value = student.PhoneNumber;
                        insertStudentCmd.Parameters.Add("@birth_day", SqlDbType.DateTime).Value = student.BirthDay;
                        insertStudentCmd.Parameters.Add("@gender", SqlDbType.VarChar).Value = student.Gender;
                        insertStudentCmd.Parameters.Add("@std_address", SqlDbType.NVarChar).Value = student.Address;
                        insertStudentCmd.Parameters.Add("@std_image", SqlDbType.VarBinary).Value = student.ImageData;

                        if (insertStudentCmd.ExecuteNonQuery() > 0) return true;
                        return false;

                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool RemoveStudent(string studentId)
        {
            try
            {
                using (SqlConnection connection = Connection)
                {
                    connection.Open();

                    string removeStudentQuery = "DELETE FROM Students " +
                        "WHERE studentID = @studentID";
                    using (SqlCommand removeStudentCmd = new SqlCommand(removeStudentQuery, connection))
                    {

                        removeStudentCmd.Parameters.Add("@studentID", SqlDbType.VarChar).Value = studentId;
                        if (removeStudentCmd.ExecuteNonQuery() > 0) return true;
                        return false;

                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        public bool HaveStudent(string studentID)
        {
            try
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
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
            
        }

        public DataTable GetStudentDataTableByID(string studentID)
        {
            try
            {
                using (SqlConnection connection = Connection)
                {
                    connection.Open();

                    string query = "SELECT * FROM Students WHERE studentID = @studentID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@studentID", SqlDbType.VarChar).Value = studentID;

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        return dataTable;
                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null;
            }
            
        }

        public bool EditStudent(string studentID, Student newStudent)
        {
            try
            {
                if ((studentID == newStudent.Id) && HaveStudent(studentID))
                {
                    return RemoveStudent(studentID) && AddStudent(newStudent);
                }
                return false;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        private string CreateStudentFilterQuery(string studentID, string firstStudentName, string lastStudentName, string phoneNumber, DateTime studentBirthday, string gender, string address)
        {
            string query = "SELECT * FROM Students WHERE 1 = 1";

            if (!string.IsNullOrEmpty(studentID))
            {
                query += $" AND studentID = '{studentID}'";
            }

            if (!string.IsNullOrEmpty(firstStudentName))
            {
                query += $" AND first_name = '{firstStudentName}'";
            }

            if (!string.IsNullOrEmpty(lastStudentName))
            {
                query += $" AND last_name = '{lastStudentName}'";
            }

            if (!string.IsNullOrEmpty(phoneNumber))
            {
                query += $" AND phone_number = '{phoneNumber}'";
            }

            if (studentBirthday != DateTimePicker.MinimumDateTime)
            {
                query += $" AND birth_day = @birth_day";
            }

            if (!string.IsNullOrEmpty(gender))
            {
                query += $" AND gender = '{gender}'";
            }

            if (!string.IsNullOrEmpty(address))
            {
                query += $" AND std_address = @std_address";
            }

            return query;

        }

        public DataTable GetStudentFilterResult(string studentID, string firstStudentName, string lastStudentName, string phoneNumber, DateTime studentBirthday, string gender, string address)
        {

            using (SqlConnection connection = Connection)
            {
                connection.Open();

                string query = CreateStudentFilterQuery(studentID, firstStudentName, lastStudentName, phoneNumber, studentBirthday, gender, address);
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters for any DateTime values
                    if (studentBirthday != DateTimePicker.MinimumDateTime)
                    {
                        command.Parameters.AddWithValue("@birth_day", studentBirthday);
                    }
                    if (!string.IsNullOrEmpty(address))
                    {
                        command.Parameters.Add("@std_address", SqlDbType.NVarChar).Value = address;
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    return dataTable;
                }
            }
        }


    }
}
