using CourseManagerWPF.MVVM.ViewModels.Base;
using System.Collections.ObjectModel;

namespace CourseManagerWPF.MVVM.ViewModels.Entitys
{
    public class TeacherVM : ViewModel
    {
        private Guid _id;
        private string _name;
        private string _surname;
        private string _patronymic;
        private DateTime _birthday;
        private string _email;

        private ObservableCollection<GroupVM>? _groups;

        public TeacherVM(Guid id, string name, string surname, string patronymic, DateTime birthday, string email, List<GroupVM> groups)
        {
            _id = id;
            _name = name;
            _surname = surname;
            _patronymic = patronymic;
            _birthday = birthday;
            _email = email;
            _groups = new ObservableCollection<GroupVM>(groups);
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

        public string Surname
        {
            get => _surname;
            set => Set(ref _surname, value);
        }

        public string Patronymic
        {
            get => _patronymic;
            set => Set(ref _patronymic, value);
        }

        public DateTime Birthday
        {
            get => _birthday;
            set => Set(ref _birthday, value);
        }

        public string Email
        {
            get => _email;
            set => Set(ref _email, value);
        }

        public ObservableCollection<GroupVM>? Groups
        {
            get => _groups;
            set => Set(ref _groups, value);
        }
    }
}
