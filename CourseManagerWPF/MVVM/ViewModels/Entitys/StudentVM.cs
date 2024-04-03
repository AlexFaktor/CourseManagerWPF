using CourseManagerWPF.MVVM.ViewModels.Base;

namespace CourseManagerWPF.MVVM.ViewModels.Entitys
{
    internal class StudentVM : ViewModel
    {
        private Guid _id;
        private string _name;
        private string _surname;
        private string _patronymic;
        private DateTime _birthday;
        private string _email;
        private double _rating;

        private GroupVM _group;
    }
}
