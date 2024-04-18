namespace CourseManagerDatabase.Entity.Extensions
{
    public static class StudentRecordExtensions
    {
        public static StudentRecord GetCopy(this StudentRecord record) 
        {
            return new StudentRecord()
            {
               Id = record.Id,
               Name = record.Name,
               Surname = record.Surname,
               Patronymic = record.Patronymic,
               Birthday = record.Birthday,
               Email = record.Email,
               Rating = record.Rating,
               GroupId = record.GroupId,
               Group = record.Group,
            };
        }
    }
}
