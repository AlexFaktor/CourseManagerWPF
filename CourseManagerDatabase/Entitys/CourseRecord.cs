using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManagerDatabase.Entitys
{
    public class CourseRecord
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<GroupRecord> Groups { get; set; } = [];
    }
}
