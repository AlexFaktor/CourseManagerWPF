using CourseManagerDatabase.Entity.Extensions;
using CourseManagerWPF.Commands;
using CourseManagerWPF.MVVM.ViewModels.Entitys;
using CourseManagerWPF.MVVM.ViewModels.Pages.Base;
using System.Windows;

namespace CourseManagerWPF.MVVM.ViewModels.Pages.EnityPages
{
    internal class TeacherPageVM : PageVM
    {
        private TeacherVM _teacher;

        public AppCommands Commands { get; set; }
        public TeacherPageVM(TeacherVM teacher)
        {
            _teacher = new(teacher.Teacher.GetCopy());

            var app = (App)Application.Current;
            Commands = app.Commands;
        }

        public TeacherVM Teacher
        {
            get => _teacher;
            set => Set(ref _teacher, value);
        }
    }
}
