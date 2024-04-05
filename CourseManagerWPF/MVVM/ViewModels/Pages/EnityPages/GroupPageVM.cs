using CourseManagerWPF.MVVM.ViewModels.Entitys;
using CourseManagerWPF.MVVM.ViewModels.Pages.Base;

namespace CourseManagerWPF.MVVM.ViewModels.Pages.EnityPages
{
    internal class GroupPageVM(GroupVM group) : PageVM
    {
        private GroupVM _group = group;

        public GroupVM Group
        {
            get => _group;
            set => Set(ref _group, value);
        }
    }
}
