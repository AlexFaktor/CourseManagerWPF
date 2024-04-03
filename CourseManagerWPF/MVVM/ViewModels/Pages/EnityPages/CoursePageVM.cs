using CourseManagerWPF.MVVM.ViewModels.Entitys;
using CourseManagerWPF.MVVM.ViewModels.Pages.Base;

namespace CourseManagerWPF.MVVM.ViewModels.Pages.EnityPages
{
    internal class CoursePageVM : PageVM
    {
        private CourseVM _course;

        public CourseVM Course
        {
            get => _course;
            set => Set(ref  _course, value);
        }
    }
}
