using CourseManagerWPF.MVVM.ViewModels.Entitys;
using CourseManagerWPF.MVVM.ViewModels.Pages.Base;

namespace CourseManagerWPF.MVVM.ViewModels.Pages.EnityPages
{
    internal class StudentPageVM(StudentVM student) : PageVM
    {
        private StudentVM _student = student;

        public StudentVM Student
        {
            get => _student;
            set => Set(ref _student, value);
        }
    }
}
