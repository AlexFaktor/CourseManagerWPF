using CourseManagerDatabase.Entitys;

namespace CourseManagerDatabase.Database
{
    public class ManagerRepository(ManagerDbContext context)
    {
        private readonly ManagerDbContext _db = context;

        public void DbSaveChanges() => _db.SaveChanges();

        public void AddCourse(CourseRecord courseRecord) => _db.Courses.Add(courseRecord);
        public void AddGroup(GroupRecord groupRecord) => _db.Groups.Add(groupRecord);
        public void AddStudent(StudentRecord studentRecord) => _db.Students.Add(studentRecord);
        public void AddTeacher(TeacherRecord teacherRecord) => _db.Teachers.Add(teacherRecord);

        public List<CourseRecord> GetCourses() => [.. _db.Courses];
        public List<GroupRecord> GetGroups() => [.. _db.Groups];
        public List<StudentRecord> GetStudents() => [.. _db.Students];
        public List<TeacherRecord> GetTeachers() => [.. _db.Teachers];

        public bool UpdateCourse(CourseRecord courseRecord)
        {
            if (_db.Courses.Any(c => c.Id == courseRecord.Id))
            {
                DeleteCourse(courseRecord);
                AddCourse(courseRecord);
                return true;
            }
            return false;
        }
        public bool UpdateGroup(GroupRecord groupRecord)
        {
            if (_db.Groups.Any(c => c.Id == groupRecord.Id))
            {
                DeleteGroup(groupRecord);
                AddGroup(groupRecord);
                return true;
            }
            return false;
        }
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

        public bool DeleteCourse(CourseRecord courseRecord)
        {
            if (_db.Courses.Any(c => c.Id == courseRecord.Id))
            {
                _db.Courses.Remove(_db.Courses.First(c => c.Id == courseRecord.Id));
                return true;
            }
            return false;
        }
        public bool DeleteGroup(GroupRecord groupRecord)
        {
            if (_db.Groups.Any(g => g.Id == groupRecord.Id))
            {
                _db.Groups.Remove(_db.Groups.First(g => g.Id == groupRecord.Id));
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
