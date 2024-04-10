using CourseManagerDatabase.Entity.Extensions;
using CourseManagerWPF.Commands;
using CourseManagerWPF.MVVM.ViewModels.Entitys;
using CourseManagerWPF.MVVM.ViewModels.Pages.Base;
using System.Windows;

namespace CourseManagerWPF.MVVM.ViewModels.Pages.EnityPages
{
    internal class CoursePageVM : PageVM
    {
        private CourseVM _course;
        public AppCommandsBinding Commands { get; set; }

        public CoursePageVM(CourseVM course)
        {
            _course = new(course.Course.GetCopy());

            var app = (App)Application.Current;
            Commands = app.Commands;
        }

        public CourseVM Course
        {
            get => _course;
            set => Set(ref _course, value);
        }
    }
}
