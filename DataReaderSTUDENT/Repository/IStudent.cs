using DataReaderSTUDENT.Model;

namespace DataReaderSTUDENT.Repository
{
    public interface IStudent
    {
        IEnumerable<Students> GetAllStudents();
        //public void AddStudent(Students student);

    }
}
