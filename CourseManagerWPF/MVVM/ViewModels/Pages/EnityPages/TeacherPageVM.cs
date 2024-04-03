using CourseManagerWPF.MVVM.ViewModels.Entitys;
using CourseManagerWPF.MVVM.ViewModels.Pages.Base;

namespace CourseManagerWPF.MVVM.ViewModels.Pages.EnityPages
{
    internal class TeacherPageVM : PageVM
    {
        private TeacherVM _teacher;

        public TeacherVM Teacher
        {
            get => _teacher;
            set => Set(ref _teacher, value);
        }
    }
}
