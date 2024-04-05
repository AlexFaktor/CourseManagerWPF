using CourseManagerDatabase.Entity;

namespace CourseManagerDatabase.Database.Services
{
    public class StudentService(SchoolDbContext db)
    {
        private readonly SchoolDbContext _db = db;

        public void AddStudent(StudentRecord studentRecord) => _db.Students.Add(studentRecord);

        public List<StudentRecord> GetStudents() => [.. _db.Students];

        public bool UpdateStudent(StudentRecord studentRecord)
        {
            if (_db.Students.Any(c => c.Id == studentRecord.Id))
            {
                DeleteStudent(studentRecord);
                AddStudent(studentRecord);
                return true;
            }
            return false;
        }

        public bool DeleteStudent(StudentRecord studentRecord)
        {
            if (_db.Students.Any(g => g.Id == studentRecord.Id))
            {
                _db.Students.Remove(_db.Students.First(g => g.Id == studentRecord.Id));
                return true;
            }
            return false;
        }
    }
}
