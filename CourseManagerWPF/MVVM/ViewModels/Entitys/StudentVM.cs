using CourseManagerDatabase.Entitys;
using CourseManagerWPF.MVVM.ViewModels.Base;

namespace CourseManagerWPF.MVVM.ViewModels.Entitys
{
    public class StudentVM : ViewModel
    {
        private StudentRecord _studentRecord;

        public StudentVM(StudentRecord studentRecord)
        {
            _studentRecord = studentRecord;
        }

        public StudentRecord Student
        {
            get => _studentRecord;
            set => Set(ref _studentRecord, value);
        }
    }
}
