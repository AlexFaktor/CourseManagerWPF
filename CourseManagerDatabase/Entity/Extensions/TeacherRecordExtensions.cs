namespace CourseManagerDatabase.Entity.Extensions
{
    public static class TeacherRecordExtensions
    {
        public static TeacherRecord GetCopy(this TeacherRecord record) 
        {
            return new TeacherRecord()
            {
                Id = record.Id,
                Name = record.Name,
                Surname = record.Surname,
                Patronymic = record.Patronymic,
                Birthday = record.Birthday,
                Email = record.Email,
                Groups = record.Groups,
            };
        }
    }
}
