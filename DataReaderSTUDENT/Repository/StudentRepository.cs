using DataReaderSTUDENT.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace DataReaderSTUDENT.Repository
{
    public class StudentRepository : IStudent
    {
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
    }
}
