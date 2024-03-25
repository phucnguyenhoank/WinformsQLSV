using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt;



/*
 DỮ LIỆU VÀO PHẢI HỢP LÝ
VIỆC GIỮ CHO DỮ LIỆU LUÔN HỢP LÝ THUỘC VỀ TRÁCH NHIỆM CỦA LỚP KHÁC
Ở ĐÂY CHỈ XỬ LÝ NGOẠI LỆ LOGIC CODE, KHÔNG XỬ LÝ NGOẠI LỆ LOGIC NGHIỆP VỤ CỦA ỨNG DỤNG
 */
namespace StudentManager
{
    public static class SharedConnectString
    {
        public static string ConnectString = "Server=xichxo\\SQLEXPRESS;Database=ManagerStudentDB;Integrated Security=True;";
    }

    public class AccountManager
    {
        private string connectString = SharedConnectString.ConnectString;

        // return a new SqlConnection object
        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(connectString);
            }
        }

        public bool AddAccount(string userName, string hashedPassword, string email)
        {
            SqlConnection connection = null;

            try
            {
                connection = Connection;
                connection.Open();

                SqlCommand insertAccountCmd = connection.CreateCommand();
                insertAccountCmd.CommandText = "INSERT INTO Accounts (username, hashedPassword, email) VALUES (@username, @password, @email)";
                insertAccountCmd.Parameters.AddWithValue("@username", userName);
                insertAccountCmd.Parameters.AddWithValue("@password", hashedPassword);
                insertAccountCmd.Parameters.AddWithValue("@email", email);

                if (insertAccountCmd.ExecuteNonQuery() == 1) return true;
                return false;
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


    }
    // the data base must have already created before
    
    public class StudentDatabaseManager
    {
        private string connectString = SharedConnectString.ConnectString;

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(connectString);
            }
        }

        public bool AddStudent(Student student)
        {
            SqlConnection connection = null;
            try
            {
                connection = Connection;
               
                connection.Open();

                string insertStudentQuery = "INSERT INTO Students " +
                        "VALUES " +
                        "(@studentID, @first_name, @last_name, @phone_number, @birth_day, @gender, @std_address, @std_image)";

                SqlCommand insertStudentCmd = new SqlCommand(insertStudentQuery, connection); 
                insertStudentCmd.Parameters.AddWithValue("@studentID", student.Id);
                insertStudentCmd.Parameters.AddWithValue("@first_name", student.FirstName);
                insertStudentCmd.Parameters.AddWithValue("@last_name", student.LastName);
                insertStudentCmd.Parameters.AddWithValue("@phone_number", student.PhoneNumber);
                insertStudentCmd.Parameters.AddWithValue("@birth_day", student.BirthDay);
                insertStudentCmd.Parameters.AddWithValue("@gender", student.Gender);
                insertStudentCmd.Parameters.AddWithValue("@std_address", student.Address);
                insertStudentCmd.Parameters.AddWithValue("@std_image", student.ImageData);


                if (insertStudentCmd.ExecuteNonQuery() > 0) return true;
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[AddStudent:{ex.Message}]");
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public bool RemoveStudent(string studentId)
        {
            SqlConnection connection = null;
            try
            {
                connection = Connection;
                connection.Open();

                string removeStudentQuery = "DELETE FROM Students " +
                    "WHERE studentID = @studentID";
                SqlCommand removeStudentCmd = new SqlCommand(removeStudentQuery, connection);
                removeStudentCmd.Parameters.Add("@studentID", SqlDbType.VarChar).Value = studentId;
                if (removeStudentCmd.ExecuteNonQuery() > 0) return true;
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[RemoveStudent:{ex.Message}]");
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public bool HaveStudent(string studentID)
        {
            SqlConnection connection = null;
            try
            {
                connection = Connection;
                connection.Open();

                SqlCommand checkingCmd = new SqlCommand("SELECT * FROM Students WHERE studentID = @studentID", connection);
                checkingCmd.Parameters.Add("@studentID", SqlDbType.VarChar).Value = studentID;

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = checkingCmd;

                DataTable table = new DataTable();
                adapter.Fill(table);

                if (table.Rows.Count == 1) return true;
                else return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[HaveStudent:{ex.Message}]");
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

        }

        public DataTable GetStudentDataTableByID(string studentID)
        {

            SqlConnection connection = null;
            try
            {
                connection = Connection;
                connection.Open();

                string query = "SELECT * FROM Students WHERE studentID = @studentID";
                SqlCommand command = new SqlCommand(query, connection);
                
                command.Parameters.Add("@studentID", SqlDbType.VarChar).Value = studentID;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetStudentDataTableByID:{ex.Message}]");
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

        public DataTable GetStudentList()
        {
            SqlConnection connection = null;
            try
            {
                connection = Connection;
                connection.Open();

                string query = "SELECT * FROM Students";
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetStudentList:{ex.Message}]");
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
            try
            {
                if ((studentID == newStudent.Id) && HaveStudent(studentID))
                {
                    return RemoveStudent(studentID) && AddStudent(newStudent);
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[EditStudent:{ex.Message}]");
                throw;
            }
        }

        public string CreateStudentFilterQuery(string studentID, string firstStudentName, string lastStudentName, string phoneNumber, DateTime studentBirthday, string gender, string address)
        {
            string query = "SELECT * FROM Students WHERE 1 = 1";

            if (!string.IsNullOrEmpty(studentID))
            {
                query += $" AND studentID = '{studentID}'";
            }

            if (!string.IsNullOrEmpty(firstStudentName))
            {
                query += $" AND first_name = N'{firstStudentName}'";
            }

            if (!string.IsNullOrEmpty(lastStudentName))
            {
                query += $" AND last_name = N'{lastStudentName}'";
            }

            if (!string.IsNullOrEmpty(phoneNumber))
            {
                query += $" AND phone_number = '{phoneNumber}'";
            }

            DateTime minDateTime = new DateTime(1753, 1, 1);
            if (studentBirthday != minDateTime)
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
            SqlConnection connection = null;
            try
            {
                connection = Connection;
                connection.Open();

                string query = CreateStudentFilterQuery(studentID, firstStudentName, lastStudentName, phoneNumber, studentBirthday, gender, address);
                SqlCommand command = new SqlCommand(query, connection);
                
                // Add parameters for any DateTime values
                DateTime minDateTime = new DateTime(1753, 1, 1);
                if (studentBirthday != minDateTime)
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
            catch (Exception ex)
            {
                Console.WriteLine($"[GetStudentFilterResult:{ex.Message}]");
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

        public void SaveStudentListImportedDataTable(DataTable importedDT)
        {
            DeleteStudentList();
            foreach(DataRow row in importedDT.Rows)
            {
                string studentID = row.IsNull(0) ? string.Empty : (string)row[0];
                string firstName = row.IsNull(1) ? string.Empty : (string)row[1];
                string lastName = row.IsNull(2) ? string.Empty : (string)row[2];
                string phoneNumber = row.IsNull(3) ? string.Empty : (string)row[3];
                DateTime birthDay = row.IsNull(4) ? DateTime.MinValue : (DateTime)row[4];
                string gender = row.IsNull(5) ? string.Empty : (string)row[5];
                string address = row.IsNull(6) ? string.Empty : (string)row[6];

                byte[] imageData;
                if (row.IsNull(7))
                {
                    string defaultImagePath = "E:\\hello_csharp\\Day2_Again\\StudentManager\\anh_mac_dinh\\anh_mac_dinh2.jpg";
                    imageData = File.ReadAllBytes(defaultImagePath);
                }
                else
                {
                    imageData = (byte[])row[7];
                }

                Student st = new Student(studentID, firstName, lastName, phoneNumber, birthDay, gender, address, imageData);
                AddStudent(st);
            }
        }

        public void AddStudentListDataTable(DataTable addedStudentDataTable)
        {
            foreach (DataRow row in addedStudentDataTable.Rows)
            {
                string studentID = row.IsNull(0) ? string.Empty : (string)row[0];
                string firstName = row.IsNull(1) ? string.Empty : (string)row[1];
                string lastName = row.IsNull(2) ? string.Empty : (string)row[2];
                string phoneNumber = row.IsNull(3) ? string.Empty : (string)row[3];
                DateTime birthDay = row.IsNull(4) ? DateTime.MinValue : (DateTime)row[4];
                string gender = row.IsNull(5) ? string.Empty : (string)row[5];
                string address = row.IsNull(6) ? string.Empty : (string)row[6];

                byte[] imageData;
                if (row.IsNull(7))
                {
                    string defaultImagePath = "E:\\hello_csharp\\Day2_Again\\StudentManager\\anh_mac_dinh\\anh_mac_dinh2.jpg";
                    imageData = File.ReadAllBytes(defaultImagePath);
                }
                else
                {
                    imageData = (byte[])row[7];
                }

                Student st = new Student(studentID, firstName, lastName, phoneNumber, birthDay, gender, address, imageData);
                AddStudent(st);
            }
        }

        public bool DeleteStudentList()
        {
            SqlConnection connection = null;
            try
            {

                connection = Connection;
                connection.Open();

                string removeStudentQuery = "DELETE FROM Students";

                SqlCommand removeStudentCmd = new SqlCommand(removeStudentQuery, connection);
                if (removeStudentCmd.ExecuteNonQuery() > 0) return true;
                return false;
                 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetStudentDataTableByID:{ex.Message}]");
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
}
