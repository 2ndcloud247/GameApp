using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Web;
namespace AppDB
{
//    create table students(
//Id int primary key identity,
//Name varchar(100) NOT null,
//Age INT NOT NULL,
//Email varchar(100) NOT null unique,
//);
    internal class Program
    {
        public static string connectionstring= "Data Source=.\\sqlexpress;Initial Catalog=MyDB;Integrated Security=True;TrustServerCertificate=True";
        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Student Management System");
                Console.WriteLine("1. View Students");
                Console.WriteLine("2. Add Student");
                Console.WriteLine("3. Update Student Record");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Exit");
                Console.Write("Please select an option (1-5): ");

                switch (Console.ReadLine())
                {
                    case "1": ViewStudents(); break;
                    case "2": AddStudents(); break;
                    case "3": UpdateStudentRecored(); break;
                    case "4": Deletestudent(); break;
                    case "5": running = false; break;
                    default: Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadLine();
                }
            }
        }

        public static void ViewStudents()
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                string query = "SELECT * FROM students";
                SqlCommand cmd=new SqlCommand (query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("\nID | Name | Age | Email");
                Console.WriteLine("-------------------------");
                while(reader.Read())
                {
                    Console.WriteLine($"{reader["Id"]} | {reader["Name"]} | {reader["Age"]} | {reader["Email"]} ");
                }

            }

        }

        public static void AddStudents()
        {

            Console.Write("Enter Name:");
            string name = Console.ReadLine();

            Console.Write("Enter Age:");

            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter Email:");
            string email = Console.ReadLine();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                string checkemail = "select count(*) from students where email=@email";
                SqlCommand cmdcheck= new SqlCommand (checkemail, conn);
                cmdcheck.Parameters.AddWithValue("@email", email);
                int count =(int)cmdcheck.ExecuteScalar();
                if (count > 0)
                {
                    Console.WriteLine("Email already exists! Try another email address");
                    return;
                }

                string query = "INSERT INTO students (Name, Age, Email) VALUES (@Name, @Age, @Email)";
                SqlCommand cmd=new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Age", age);
                cmd.Parameters.AddWithValue("@Email", email);
                int result =cmd.ExecuteNonQuery();
                Console.WriteLine(result > 0 ? "Student added successfully." : "Failed to add student to the table.");

            }

        }

        public static void UpdateStudentRecored()
        {
            Console.Write("Enter student ID to Update: ");
            int id =int.Parse(Console.ReadLine());
            Console.Write("Enter New Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Age:");

            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter Email:");
            string email = Console.ReadLine();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                string queryUpdate = "UPDATE students SET Name = @Name, Age = @Age, Email = @Email WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(queryUpdate, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Age", age);
                cmd.Parameters.AddWithValue("@Email", email);
                int result = cmd.ExecuteNonQuery();
                Console.WriteLine(result > 0 ? "Student record updated successfully." : "Failed to update student record.");
            }
        }

        public static void Deletestudent()
        {
            Console.Write("Enter student ID to delete:");
            int id = int.Parse(Console.ReadLine());
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                string queryDelete = "DELETE FROM students WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(queryDelete, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                int result = cmd.ExecuteNonQuery();
                Console.WriteLine(result > 0 ? "Student deleted successfully." : "Failed to delete student.");
            }

        }
    }
}
