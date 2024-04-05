using CourseManagerWPF.MVVM.ViewModels.Entitys;
using CourseManagerWPF.MVVM.ViewModels.Pages.Base;

namespace CourseManagerWPF.MVVM.ViewModels.Pages.EnityPages
{
    internal class CoursePageVM(CourseVM course) : PageVM
    {
        private CourseVM _course = course;

        public CourseVM Course
        {
            get => _course;
            set => Set(ref _course, value);
        }
    }
}
