using CourseManagerDatabase.Database;

namespace CourseManagerWPF.Database
{
    internal class Database(ManagerRepository db)
    {
        public ManagerRepository _db { get; set; } = db;




    }
}
