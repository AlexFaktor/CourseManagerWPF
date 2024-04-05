using CourseManagerDatabase.Entity;

namespace CourseManagerDatabase.Database.Services
{
    public class TeacherService(SchoolDbContext db)
    {
        private readonly SchoolDbContext _db = db;
        public void AddTeacher(TeacherRecord teacherRecord) => _db.Teachers.Add(teacherRecord);

        public List<TeacherRecord> GetTeachers() => [.. _db.Teachers];

        public bool UpdateTeacher(TeacherRecord teacherRecord)
        {
            if (_db.Teachers.Any(c => c.Id == teacherRecord.Id))
            {
                DeleteTeacher(teacherRecord);
                AddTeacher(teacherRecord);
                return true;
            }
            return false;
        }

        public bool DeleteTeacher(TeacherRecord teacherRecord)
        {
            if (_db.Teachers.Any(g => g.Id == teacherRecord.Id))
            {
                _db.Teachers.Remove(_db.Teachers.First(g => g.Id == teacherRecord.Id));
                return true;
            }
            return false;
        }
    }
}
