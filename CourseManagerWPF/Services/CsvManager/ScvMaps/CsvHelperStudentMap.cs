using CourseManagerDatabase.Entity;
using CsvHelper.Configuration;

namespace CourseManagerWPF.Services.ScvManager.ScvMaps
{
    public class CsvHelperStudentMap : ClassMap<StudentRecord>
    {
        public CsvHelperStudentMap()
        {
            Map(m => m.Name).Index(0);
            Map(m => m.Surname).Index(1);
            Map(m => m.Patronymic).Index(2);
            Map(m => m.Birthday).Index(3);
            Map(m => m.Email).Index(4);
            Map(m => m.Rating).Index(5);
        }
    }
}
