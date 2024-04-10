using CourseManagerWPF.MVVM.ViewModels.Entitys;
using System.Windows;

namespace CourseManagerWPF.MVVM.ViewModels.Entity.Extensions
{
    public static class GroupVMExtensions
    {
        public static void CleanStudents(this GroupVM groupVM)
        {
            var group = groupVM.Group;
            var studentsGroup = group.Students;
            
            var app = (App)Application.Current;
            var db = app.DbRepository;
            var studentsApp = app.Students;

            var studentsGroupVM = studentsApp.Where(s => studentsGroup.Contains(s.Student)).ToList();

            foreach ( var student in studentsGroupVM)
            {
                db.StudentService.DeleteStudent(student.Student);
                studentsApp.Remove(studentsApp.First(s => s.Student.Id == student.Student.Id));

                db.DbSaveChanges();
            }
        }
    }
}
