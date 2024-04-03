using CourseManagerWPF.MVVM.ViewModels.Base;

namespace CourseManagerWPF.MVVM.ViewModels.Entitys
{
    public class StudentVM : ViewModel
    {
        private Guid _id;
        private string _name;
        private string _surname;
        private string _patronymic;
        private DateTime _birthday;
        private string _email;
        private double _rating;

        private GroupVM? _group;

        public StudentVM(Guid id, string name, string surname, string patronymic, DateTime birthday, string email, double rating, GroupVM group)
        {
            _id = id;
            _name = name;
            _surname = surname;
            _patronymic = patronymic;
            _birthday = birthday;
            _email = email;
            _rating = rating;
            _group = group;
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

        public double Rating
        {
            get => _rating;
            set => Set(ref _rating, value);
        }

        public GroupVM? Group
        {
            get => _group; 
            set => Set(ref _group, value);
        }
    }
}
