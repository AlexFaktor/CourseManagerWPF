using CourseManagerDatabase.Entity;
using CourseManagerWPF.MVVM.ViewModels.Base;

namespace CourseManagerWPF.MVVM.ViewModels.Entitys
{
    public class CourseVM(CourseRecord courseRecord) : ViewModel
    {
        private CourseRecord _courseRecord = courseRecord;

        public CourseRecord Course
        {
            get => _courseRecord;
            set => Set(ref _courseRecord, value);
        }

        public void ViewModelChange()
        {
            OnPropertyChanged();
        }
    }
}
