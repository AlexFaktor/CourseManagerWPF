using CourseManagerDatabase.Entity;
using CourseManagerWPF.MVVM.ViewModels.Base;
using System.Collections.ObjectModel;

namespace CourseManagerWPF.MVVM.ViewModels.Entitys
{
    public class GroupVM : ViewModel
    {
        private GroupRecord _groupRecord;

        public GroupVM(GroupRecord groupRecord)
        {
            _groupRecord = groupRecord;
        }

        public GroupRecord Group
        {
            get => _groupRecord;
            set => Set(ref _groupRecord, value);
        }

        public void ViewModelChange()
        {
            OnPropertyChanged();
        }
    }
}
