using CourseManagerDatabase.Entity;

namespace CourseManagerDatabase.Database.Services
{
    public class GroupService(SchoolDbContext db)
    {
        private readonly SchoolDbContext _db = db;

        public void AddGroupRecord(GroupRecord groupRecord) => _db.Groups.Add(groupRecord);

        public List<GroupRecord> GetGroups() => [.. _db.Groups];

        public bool UpdateGroup(GroupRecord groupRecord)
        {
            if (_db.Groups.Any(c => c.Id == groupRecord.Id))
            {
                DeleteGroup(groupRecord);
                AddGroupRecord(groupRecord);
                return true;
            }
            return false;
        }

        public bool DeleteGroup(GroupRecord groupRecord)
        {
            if (_db.Groups.Any(g => g.Id == groupRecord.Id))
            {
                _db.Groups.Remove(_db.Groups.First(g => g.Id == groupRecord.Id));
                return true;
            }
            return false;
        }
    }
}
