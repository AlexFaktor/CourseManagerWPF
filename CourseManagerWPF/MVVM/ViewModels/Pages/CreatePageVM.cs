using CourseManagerDatabase.Entity;
using CourseManagerWPF.MVVM.ViewModels.Entitys;
using CourseManagerWPF.MVVM.ViewModels.Pages.Base;

namespace CourseManagerWPF.MVVM.ViewModels.Pages
{
    internal class CreatePageVM : PageVM
    {
        private CourseVM _course;
        private GroupVM _group;
        private StudentVM _student;
        private TeacherVM _teacher;

        public CreatePageVM()
        {
            _course = new CourseVM(new CourseRecord());
            _group = new GroupVM(new GroupRecord());
            _student = new StudentVM(new StudentRecord());
            _teacher = new TeacherVM(new TeacherRecord());
        }

        public CourseVM Course
        {
            get => _course;
            set => Set(ref _course, value);
        }
        public GroupVM Group
        {
            get => _group;
            set => Set(ref _group, value);
        }
        public StudentVM Student
        {
            get => _student;
            set => Set(ref _student, value);
        }
        public TeacherVM Teacher
        {
            get => _teacher;
            set => Set(ref _teacher, value);
        }
    }
}
