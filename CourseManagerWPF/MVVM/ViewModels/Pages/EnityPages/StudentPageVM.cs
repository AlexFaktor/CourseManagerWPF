using CourseManagerDatabase.Entity.Extensions;
using CourseManagerWPF.Commands;
using CourseManagerWPF.MVVM.ViewModels.Entitys;
using CourseManagerWPF.MVVM.ViewModels.Pages.Base;
using System.Windows;

namespace CourseManagerWPF.MVVM.ViewModels.Pages.EnityPages
{
    internal class StudentPageVM : PageVM
    {
        private StudentVM _student;

        public AppCommandsBinding Commands { get; set; }
        public StudentPageVM(StudentVM student)
        {
            _student = new(student.Student.GetCopy());

            var app = (App)Application.Current;
            Commands = app.Commands;
        }

        public StudentVM Student
        {
            get => _student;
            set => Set(ref _student, value);
        }
    }
}
