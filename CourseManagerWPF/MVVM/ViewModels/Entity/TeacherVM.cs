using CourseManagerDatabase.Entity;
using CourseManagerWPF.MVVM.ViewModels.Base;

namespace CourseManagerWPF.MVVM.ViewModels.Entitys
{
    public class TeacherVM : ViewModel
    {
        private TeacherRecord _teacherRecord;

        public TeacherVM(TeacherRecord teacherRecord)
        {
            _teacherRecord = teacherRecord;
        }

        public TeacherRecord Teacher
        {
            get => _teacherRecord;
            set => Set(ref _teacherRecord, value);
        }

        public void ViewModelChange()
        {
            OnPropertyChanged();
        }
    }
}
