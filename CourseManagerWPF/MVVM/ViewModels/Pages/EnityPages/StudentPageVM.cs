using CourseManagerWPF.MVVM.ViewModels.Entitys;
using CourseManagerWPF.MVVM.ViewModels.Pages.Base;

namespace CourseManagerWPF.MVVM.ViewModels.Pages.EnityPages
{
    internal class StudentPageVM : PageVM
    {
        private StudentVM _student;

        public StudentVM Student
        {
            get => _student;
            set => Set(ref _student, value);
        }
    }
}
