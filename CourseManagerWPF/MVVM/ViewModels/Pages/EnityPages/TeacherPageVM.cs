using CourseManagerWPF.MVVM.ViewModels.Entitys;
using CourseManagerWPF.MVVM.ViewModels.Pages.Base;

namespace CourseManagerWPF.MVVM.ViewModels.Pages.EnityPages
{
    internal class TeacherPageVM(TeacherVM teacher) : PageVM
    {
        private TeacherVM _teacher = teacher;

        public TeacherVM Teacher
        {
            get => _teacher;
            set => Set(ref _teacher, value);
        }
    }
}
