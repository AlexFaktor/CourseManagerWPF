using CourseManagerWPF.MVVM.ViewModels.Base;
using System.Collections.ObjectModel;

namespace CourseManagerWPF.MVVM.ViewModels.Entitys
{
    public class GroupVM : ViewModel
    {
        private Guid _id;
        private string _name;

        private CourseVM _course;
        private ObservableCollection<StudentVM> _students;
        private TeacherVM? _teacher;

        public GroupVM(Guid id, string name, CourseVM course, List<StudentVM> students, TeacherVM teacher)
        {
            _id = id;
            _name = name;
            _course = course;
            _students = new ObservableCollection<StudentVM>(students);
            _teacher = teacher;
        }

        public Guid Id
        {
            get => _id;
            set => Set(ref _id, value);
        }

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public CourseVM Course
        {
            get => _course;
            set => Set(ref _course, value);
        }

        public ObservableCollection<StudentVM> Students
        {
            get => _students;
            set => Set(ref _students, value);
        }

        public TeacherVM? Teacher
        {
            get => _teacher;
            set => Set(ref _teacher, value);
        }
    }
}
