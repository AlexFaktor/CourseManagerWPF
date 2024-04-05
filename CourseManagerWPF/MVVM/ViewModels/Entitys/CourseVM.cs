using CourseManagerDatabase.Entitys;
using CourseManagerWPF.MVVM.ViewModels.Base;
using System.Collections.ObjectModel;

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
    }
}
