using CourseManagerDatabase.Entity;

namespace CourseManagerDatabase.Database.Services
{
    public class CourseService(SchoolDbContext db)
    {
        private readonly SchoolDbContext _db = db;

        public void AddCourse(CourseRecord courseRecord) => _db.Courses.Add(courseRecord);

        public List<CourseRecord> GetCourses() => [.. _db.Courses];

        public bool UpdateCourse(CourseRecord courseRecord)
        {
            if (_db.Courses.Any(c => c.Id == courseRecord.Id))
            {
                DeleteCourse(courseRecord);
                AddCourse(courseRecord);
                return true;
            }
            return false;
        }

        public bool DeleteCourse(CourseRecord courseRecord)
        {
            if (_db.Courses.Any(c => c.Id == courseRecord.Id))
            {
                _db.Courses.Remove(_db.Courses.First(c => c.Id == courseRecord.Id));
                return true;
            }
            return false;
        }
    }
}
