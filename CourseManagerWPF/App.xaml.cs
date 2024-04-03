using CourseManagerDatabase.Database;
using CourseManagerWPF.MVVM.ViewModels.Entitys;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;

namespace CourseManagerWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public ManagerDbContext DbContext { get; set; }
        public ManagerRepository Db { get; set; }

        public ObservableCollection<CourseVM> Courses { get; set; }
        public ObservableCollection<GroupVM> Groups { get; set; }
        public ObservableCollection<StudentVM> Students { get; set; }
        public ObservableCollection<TeacherVM> Teachers { get; set; }

        public App()
        {
            DbContext = new ManagerDbContext();
            DbContext.Database.EnsureCreated();
            Db = new ManagerRepository(DbContext);

            
            
        }
    }
}
