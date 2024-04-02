using CourseManagerDatabase.Database;
using Microsoft.EntityFrameworkCore;
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

        public App()
        {
            DbContext = new ManagerDbContext();
            DbContext.Database.EnsureCreated();
            Db = new ManagerRepository(DbContext);
            
        }
    }
}
