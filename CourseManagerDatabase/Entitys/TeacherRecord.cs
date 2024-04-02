namespace CourseManagerDatabase.Entitys
{
    public class TeacherRecord
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Patronymic { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
        public string Email { get; set; } = string.Empty;
        public double Rating { get; set; }

        public ICollection<GroupRecord> Groups { get; set; } = [];
    }
}
