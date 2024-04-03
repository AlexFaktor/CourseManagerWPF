using CourseManagerWPF.MVVM.ViewModels.Base;
using System.Collections.ObjectModel;

namespace CourseManagerWPF.MVVM.ViewModels.Entitys
{
    internal class GroupVM : ViewModel
    {
        private Guid _id; 
        private string _name;

        private ObservableCollection<StudentVM> _students;
        private TeacherVM _teacher;
    }
}
