using CourseManagerWPF.MVVM.ViewModels.Base;
using System.Collections.ObjectModel;

namespace CourseManagerWPF.MVVM.ViewModels.Entitys
{
    public class CourseVM(Guid id, string name, List<GroupVM> groups) : ViewModel
    {
        private Guid _id = id;
        private string _name = name;
        private ObservableCollection<GroupVM> _groups = new ObservableCollection<GroupVM>(groups);

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

        public ObservableCollection<GroupVM> Groups
        {
            get => _groups;
            set => Set(ref _groups, value);
        }
    }
}
