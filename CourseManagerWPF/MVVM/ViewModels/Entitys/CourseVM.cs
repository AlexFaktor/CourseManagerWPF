using CourseManagerWPF.MVVM.ViewModels.Base;
using System.Collections.ObjectModel;

namespace CourseManagerWPF.MVVM.ViewModels.Entitys
{
    internal class CourseVM : ViewModel
    {
        private Guid _id;
        private string _name;
        private ObservableCollection<GroupVM> _groups;

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }
    }
}
