using DTO;
using StudentManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AccountBLL
    {
        private string connectString = SharedConnectString.ConnectString;
        AccountManager accountManager = null;
        // return a new SqlConnection object
        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(connectString);
            }
        }

        public AccountBLL()
        {
            accountManager = new AccountManager();
        }


        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());
        }

        // return true if hasdedPassword is password's
        private bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        public void AddAccountBLL(Account account)
        {
            SqlConnection connection = null;
            try
            {
                connection = Connection;
                connection.Open();

            
                accountManager.AddAccount(account.Username, account.HashedPassword, account.Email);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"[AddAccount:{ex.Message}]");
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close(); // Đóng kết nối sau khi sử dụng xong
                }
            }
            
        }

        public void SetAdmin(string username, bool isAdmin)
        {
            SqlConnection connection = null;
            try
            {
                connection = Connection;
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE Accounts SET IsAdmin = @isAdmin WHERE username = @username ";
                cmd.Parameters.AddWithValue("@isAdmin", isAdmin);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SetAdmin:{ex.Message}]");
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close(); // Đóng kết nối sau khi sử dụng xong
                }
            }
        }

        public DataTable GetAccountList()
        {
            SqlConnection connection = null;
            try
            {
                connection = Connection;
                connection.Open();

                string query = "SELECT * FROM Accounts";
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetAccountList:{ex.Message}]");
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close(); // Đóng kết nối sau khi sử dụng xong
                }
            }
        }

        public void UpdatePassword(string email, string newPassword)
        {
            SqlConnection connection = null;
            try
            {
                connection = Connection;
                connection.Open();

                // Tạo câu lệnh UPDATE
                string updateStatement = "UPDATE Accounts SET hashedPassword = @newHashedPassword WHERE email = @email";

                // Tạo và mở đối tượng Command
                SqlCommand command = new SqlCommand(updateStatement, connection);
                
                // Thay thế các tham số trong câu lệnh UPDATE bằng giá trị thực tế
                command.Parameters.AddWithValue("@newHashedPassword", HashPassword(newPassword));
                command.Parameters.AddWithValue("@email", email);

                command.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UpdatePassword:{ex.Message}]");
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close(); // Đóng kết nối sau khi sử dụng xong
                }
            }
        }


        public bool HaveUsername(string userName)
        {
            SqlConnection connection = null;

            try
            {
                connection = Connection;
                connection.Open();

                SqlCommand checkingCmd = new SqlCommand("SELECT * FROM Accounts WHERE username = @username", connection);
                checkingCmd.Parameters.AddWithValue("@username", userName);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = checkingCmd;

                DataTable table = new DataTable();
                adapter.Fill(table);

                if (table.Rows.Count == 1) return true;
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[HaveUsername:{ex.Message}]");
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close(); // Đóng kết nối sau khi sử dụng xong
                }
            }
        }

        public bool HaveEmail(string email)
        {
            SqlConnection connection = null;

            try
            {
                connection = Connection;
                connection.Open();

                SqlCommand checkingCmd = new SqlCommand("SELECT * FROM Accounts WHERE email = @email", connection);
                checkingCmd.Parameters.AddWithValue("@email", email);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = checkingCmd;

                DataTable table = new DataTable();
                adapter.Fill(table);

                if (table.Rows.Count == 1) return true;
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[HaveEmail:{ex.Message}]");
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close(); // Đóng kết nối sau khi sử dụng xong
                }
            }
        }


        public bool DeleteAccount(string userName, string passWord)
        {
            SqlConnection connection = null;
            try
            {
                connection = Connection;
                connection.Open();


                string hashedPasswordFromDatabase = GetHashPasswordFromDB(userName);

                if (VerifyPassword(passWord, hashedPasswordFromDatabase))
                {
                    string deleteQuery = "DELETE " +
                        "FROM Accounts " +
                        "WHERE username = @username";

                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, connection);
                    deleteCmd.Parameters.AddWithValue("@username", userName);
                    deleteCmd.ExecuteNonQuery();
                    return true;
                }

                return false;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DeleteAccount:{ex.Message}]");
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close(); // Đóng kết nối sau khi sử dụng xong
                }
            }
        }


        public bool HaveAccount(string userName, string passWord)
        {
            if (HaveUsername(userName) && VerifyPassword(passWord, GetHashPasswordFromDB(userName))) return true;
            return false;
        }


        private string GetHashPasswordFromDB(string userName)
        {
            SqlConnection connection = null;
            try
            {
                connection = Connection;
                connection.Open();

                string getHashQuery = "SELECT hashedPassword " +
                    "FROM Accounts " +
                    "WHERE username = @username";
                SqlCommand getHashCmd = new SqlCommand(getHashQuery, connection);
                
                getHashCmd.Parameters.AddWithValue("@username", userName);

                SqlDataReader reader = getHashCmd.ExecuteReader();
                reader.Read();
                return (string)reader["hashedPassword"];
                

            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetHashPasswordFromDB:{ex.Message}]");
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close(); // Đóng kết nối sau khi sử dụng xong
                }
            }
        }

    }

    public class StudentBLL
    {
        private string connectString = SharedConnectString.ConnectString;
        private StudentDatabaseManager studentDatabaseManager = null;

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(connectString);
            }
        }
        public StudentBLL()
        {
            studentDatabaseManager = new StudentDatabaseManager();
        }

        public bool AddStudent(Student student)
        {
            return studentDatabaseManager.AddStudent(student);
        }

        public bool RemoveStudent(string studentId)
        {
            try
            {
                return studentDatabaseManager.RemoveStudent(studentId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[RemoveStudentBLL:{ex.Message}]");
                throw;
            }
            
        }

        public bool HaveStudent(string studentID)
        {
           return studentDatabaseManager.HaveStudent(studentID);

        }

        public DataTable GetStudentDataTableByID(string studentID)
        {
            return studentDatabaseManager.GetStudentDataTableByID(studentID);

        }

        public DataTable GetStudentList()
        {
            try
            {
                return studentDatabaseManager.GetStudentList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetStudentListBLL:{ex.Message}]");
                throw;
            }
        }

        public int CountStudentsByMonth(int month)
        {
            SqlConnection connection = null;
            try
            {
                connection = Connection;
                connection.Open();

                string query = "SELECT COUNT(*) FROM Students WHERE MONTH(birth_day) = @month";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@month", month);
                return (int)command.ExecuteScalar();

                /*
                // Tương đương với ExecuteReader?
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    return (int)dataTable.Rows[0][0];
                }
                else
                {
                    return 0;
                }
                */
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CountStudentsByMonth:{ex.Message}]");
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close(); // Đóng kết nối sau khi sử dụng xong
                }
            }
        }


        public bool EditStudent(string studentID, Student newStudent)
        {
            return studentDatabaseManager.EditStudent(studentID, newStudent);
        }

        private string CreateStudentFilterQuery(string studentID, string firstStudentName, string lastStudentName, string phoneNumber, DateTime studentBirthday, string gender, string address)
        {
            return studentDatabaseManager.CreateStudentFilterQuery(studentID, firstStudentName, lastStudentName, phoneNumber, studentBirthday, gender, address);
        }

        public DataTable GetStudentFilterResult(string studentID, string firstStudentName, string lastStudentName, string phoneNumber, DateTime studentBirthday, string gender, string address)
        {
            return studentDatabaseManager.GetStudentFilterResult(studentID, firstStudentName, lastStudentName, phoneNumber, studentBirthday, gender, address);
        }

        public void SaveStudentListImportedDataTable(DataTable importedDT)
        {
            studentDatabaseManager.SaveStudentListImportedDataTable(importedDT);
        }

        public void AddStudentListDataTable(DataTable dt)
        {
            studentDatabaseManager.AddStudentListDataTable(dt);
        }

        private bool DeleteStudentList()
        {
            return studentDatabaseManager.DeleteStudentList();
        }

    }

}
