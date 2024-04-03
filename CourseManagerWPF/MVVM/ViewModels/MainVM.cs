using CourseManagerWPF.MVVM.ViewModels.Base;
using CourseManagerWPF.MVVM.ViewModels.Entitys;
using System.Collections.ObjectModel;

namespace CourseManagerWPF.MVVM.ViewModels
{
    internal class MainVM : ViewModel
    {
        private ObservableCollection<CourseVM> _courses;
        private ObservableCollection<GroupVM> _groups;
        private ObservableCollection<StudentVM> _students;
        private ObservableCollection<TeacherVM> _teachers;

        public ObservableCollection<CourseVM>? Courses
        {
            get => _courses;
            set => Set(ref _courses, value);
        }

        public ObservableCollection<GroupVM>? Groups
        {
            get => _groups;
            set => Set(ref _groups, value);
        }

        public ObservableCollection<StudentVM>? Students
        {
            get => _students;
            set => Set(ref _students, value);
        }

        public ObservableCollection<TeacherVM>? Teachers
        {
            get => _teachers;
            set => Set(ref _teachers, value);
        }
    }
}
