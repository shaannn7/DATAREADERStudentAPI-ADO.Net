using DataReaderSTUDENT.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;

namespace DataReaderSTUDENT.Repository
{
    public class StudentRepository : IStudent
    {7
        private readonly IConfiguration _configuration;
        public string Cstring {  get; set; }
        public StudentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            Cstring = _configuration["ConnectionStrings:DefaultConnection"];
        }

        public IEnumerable<Students> GetAllStudents()
        {
            List<Students> students = new List<Students>();
            using (SqlConnection conn = new SqlConnection(Cstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM STUDENT7c", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Students student = new Students();
                    student.ID = Convert.ToInt32(rdr["STUDENT_ID"]);
                    student.Name = rdr["STUDENT_NAME"].ToString();
                    student.Mark = Convert.ToInt32(rdr["MARK"]);
                    student.Status = rdr["STUDENT_STATUS"].ToString();
                    students.Add(student);
                }
                return students;
            }
        }
        public Students GetStudent(int ID)
        {
            using (SqlConnection conn = new SqlConnection(Cstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM STUDENT7c WHERE STUDENT_ID = {ID}", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                Students student = new Students();
                while (rdr.Read())
                {
                    
                    student.ID = Convert.ToInt32(rdr["STUDENT_ID"]);
                    student.Name = rdr["STUDENT_NAME"].ToString();
                    student.Mark = Convert.ToInt32(rdr["MARK"]);
                    student.Status = rdr["STUDENT_STATUS"].ToString();
                    
                }
                return student;
            }

        }

        public void AddStudent(Students student)
        {
            using (SqlConnection conn = new SqlConnection(Cstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO STUDENT7c(STUDENT_NAME,MARK,STUDENT_STATUS) VALUES(@val2,@val3,@val4)",conn);
                cmd.Parameters.AddWithValue("val2",student.Name);
                cmd.Parameters.AddWithValue("val3", student.Mark);
                cmd.Parameters.AddWithValue("val4", student.Status);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateStudent(int ID ,Students student)
        {
            using(SqlConnection conn = new SqlConnection(Cstring)) 
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE STUDENT7c SET STUDENT_NAME = @Name, MARK = @Mark, STUDENT_STATUS = @Status WHERE STUDENT_ID = @ID", conn);
                cmd.Parameters.AddWithValue("Name", student.Name);
                cmd.Parameters.AddWithValue("Mark", student.Mark);
                cmd.Parameters.AddWithValue("Status", student.Status);
                cmd.Parameters.AddWithValue("ID", ID);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteStudent(int ID)
        {
            using(SqlConnection conn = new SqlConnection(Cstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM STUDENT7c WHERE STUDENT_ID = @ID", conn);
                cmd.Parameters.AddWithValue("ID", ID);
                cmd.ExecuteNonQuery();
            }
        }

    }
}
