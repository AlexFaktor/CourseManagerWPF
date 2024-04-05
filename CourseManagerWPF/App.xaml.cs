using CourseManagerDatabase.Database;
using CourseManagerWPF.Database;
using CourseManagerWPF.MVVM.ViewModels.Entitys;
using System.Collections.ObjectModel;
using System.Windows;

namespace CourseManagerWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public SchoolDbContext DbContext { get; set; }
        public SchoolRepository DbRepository { get; set; }
        public CourseDatabase Database { get; set; }

        public ObservableCollection<CourseVM> Courses { get; set; }
        public ObservableCollection<GroupVM> Groups { get; set; }
        public ObservableCollection<StudentVM> Students { get; set; }
        public ObservableCollection<TeacherVM> Teachers { get; set; }

        public App()
        {
            DbContext = new SchoolDbContext();
            DbContext.Database.EnsureCreated();

            DbRepository = new SchoolRepository(DbContext);
            Database = new CourseDatabase(DbRepository);

            Courses = new ObservableCollection<CourseVM>(Database.GetCourseVMs());
            Groups = new ObservableCollection<GroupVM>(Database.GetGroupVMs());
            Students = new ObservableCollection<StudentVM>(Database.GetStudentsVMs());
            Teachers = new ObservableCollection<TeacherVM>(Database.GetTeacherVMs());
        }
    }
}
