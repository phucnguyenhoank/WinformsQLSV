using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager
{
    public class Student
    {
        private string id, firstName, lastName, phoneNumber, address;
        DateTime birthDay;
        string gender;    // True is Male, False is Female
        byte[] imageData;

        public Student() { }

        // Hàm khởi tạo với các tham số tùy chọn
        public Student(string id = "", string firstName = "", string lastName = "", string phoneNumber = "", DateTime? birthDay = null, string gender = "", string address = "", byte[] imageData = null)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            BirthDay = birthDay ?? DateTime.MinValue; // Giá trị mặc định cho birthDay là DateTime.MinValue nếu không được truyền vào
            Gender = gender;
            Address = address;
            ImageData = imageData;
        }

        public string Id { get { return id; } set { id = value; } }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public DateTime BirthDay { get {  return birthDay; } set {  birthDay = value; } }
        public string Gender { get {  return gender; } set {  gender = value; } }
        public string PhoneNumber { get {  return phoneNumber; } set {  phoneNumber = value; } }
        public string Address { get { return address; } set { address = value; } }

        public byte[] ImageData { get { return imageData; } set {  imageData = value; } }

    }
}
