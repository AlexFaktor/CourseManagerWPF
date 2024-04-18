using CourseManagerDatabase.Entity;

namespace CourseManagerDatabase.Database.Services
{
    public class TeacherService(SchoolDbContext db)
    {
        private readonly SchoolDbContext _db = db;
        public void AddTeacherRecord(TeacherRecord teacherRecord) => _db.Teachers.Add(teacherRecord);

        public List<TeacherRecord> GetTeachers() => [.. _db.Teachers];

        public bool UpdateTeacher(TeacherRecord teacherRecord)
        {
            var existingTeacher = _db.Teachers.FirstOrDefault(t => t.Id == teacherRecord.Id);
            if (existingTeacher != null)
            {
                existingTeacher.Name = teacherRecord.Name;
                existingTeacher.Surname = teacherRecord.Surname;
                existingTeacher.Patronymic = teacherRecord.Patronymic;
                existingTeacher.Birthday = teacherRecord.Birthday;
                existingTeacher.Email = teacherRecord.Email;
                existingTeacher.Groups = teacherRecord.Groups;
                _db.SaveChanges();
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
