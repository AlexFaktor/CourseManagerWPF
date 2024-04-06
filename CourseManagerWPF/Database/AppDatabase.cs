using CourseManagerDatabase.Database;
using CourseManagerWPF.MVVM.ViewModels.Entitys;

namespace CourseManagerWPF.Database
{
    public class AppDatabase(SchoolRepository db)
    {
        private readonly SchoolRepository _db = db;

        public List<CourseVM> GetCourseVMs()
        {
            return _db.CourseService.GetCourses().Select(DataConvertor.FromCourseRecordToCourseVM).ToList();
        }

        public List<GroupVM> GetGroupVMs()
        {
            return _db.GroupService.GetGroups().Select(DataConvertor.FromGroupRecordToGroupVM).ToList();
        }

        public List<StudentVM> GetStudentsVMs()
        {
            return _db.StudentService.GetStudents().Select(DataConvertor.FromStudentRecordToStudentVM).ToList();
        }

        public List<TeacherVM> GetTeacherVMs()
        {
            return _db.TeacherService.GetTeachers().Select(DataConvertor.FromTeacherRecordToTeacherVM).ToList();
        }
    }
}
