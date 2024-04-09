namespace CourseManagerDatabase.Entity.Extensions
{
    public static class CourseRecordExtensions
    {
        public static CourseRecord GetCopy(this CourseRecord record) 
        {
            return new CourseRecord()
            {
                Id = record.Id,
                Name = record.Name,
                Groups = record.Groups
            };
        }
    }
}
