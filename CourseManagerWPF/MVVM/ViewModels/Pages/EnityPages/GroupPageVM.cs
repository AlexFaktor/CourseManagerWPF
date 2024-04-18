using CourseManagerDatabase.Entity.Extensions;
using CourseManagerWPF.Commands;
using CourseManagerWPF.MVVM.ViewModels.Entitys;
using CourseManagerWPF.MVVM.ViewModels.Pages.Base;
using System.Windows;

namespace CourseManagerWPF.MVVM.ViewModels.Pages.EnityPages
{
    internal class GroupPageVM : PageVM
    {
        private GroupVM _group;

        public AppCommandsBinding Commands { get; set; }
        public GroupPageVM(GroupVM group)
        {
            _group = new(group.Group.GetCopy());

            var app = (App)Application.Current;
            Commands = app.Commands;
        }

        public GroupVM Group
        {
            get => _group;
            set => Set(ref _group, value);
        }
    }
}
