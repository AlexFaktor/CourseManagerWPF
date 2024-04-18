namespace CourseManagerDatabase.Entity.Extensions
{
    public static class GroupRecordExtensions
    {
        public static GroupRecord GetCopy(this GroupRecord record) 
        {
            return new GroupRecord()
            {
                Id = record.Id,
                Name = record.Name,
                CourseId = record.CourseId,
                Course = record.Course,
                Students = record.Students,
                TeacherId = record.TeacherId,
                Teacher = record.Teacher,
            };
        }
    }
}
