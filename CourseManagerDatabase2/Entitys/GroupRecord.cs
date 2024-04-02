namespace CourseManagerDatabase.Entitys
{
    public class GroupRecord
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public Guid CourseId { get; set; }
        public CourseRecord? Course { get; set; }

        public ICollection<StudentRecord> Students { get; set; } = [];

        public Guid TeacherId { get; set; }
        public TeacherRecord? Teacher { get; set; }
    }
}
