using DataReaderSTUDENT.Model;

namespace DataReaderSTUDENT.Repository
{
    public interface IStudent
    {
        IEnumerable<Students> GetAllStudents();

        public Students GetStudent(int ID);
        public void AddStudent(Students student);

        public void UpdateStudent(int ID ,Students students);

        public void DeleteStudent(int ID);

    }
}
