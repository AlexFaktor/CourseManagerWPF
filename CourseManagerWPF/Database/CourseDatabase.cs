using CourseManagerDatabase.Database;
using CourseManagerWPF.MVVM.ViewModels.Entitys;
using CourseManagerWPF.MVVM.Views;

namespace CourseManagerWPF.Database
{
    public class CourseDatabase(ManagerRepository db)
    {
        public ManagerRepository _db { get; set; } = db;

        public List<CourseVM>GetCourseVMs()
        {
            return _db.GetCourses().Select(DataConvertor.FromCourseRecordToCourseVM).ToList();
        }

        public List<GroupVM> GetGroupVMs()
        {
            return _db.GetGroups().Select(DataConvertor.FromGroupRecordToGroupVM).ToList();
        }

        public List<StudentVM> GetStudentsVMs()
        {
            return _db.GetStudents().Select(DataConvertor.FromStudentRecordToStudentVM).ToList();
        }

        public List<TeacherVM> GetTeacherVMs()
        {
            return _db.GetTeachers().Select(DataConvertor.FromTeacherRecordToTeacherVM).ToList();
        }
    }
}
