namespace CourseManagerWPF.MVVM.Models
{
    internal class Teacher
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
