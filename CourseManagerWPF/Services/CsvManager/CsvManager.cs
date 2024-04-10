using CourseManagerDatabase.Entity;
using CourseManagerWPF.MVVM.ViewModels.Entity.Extensions;
using CourseManagerWPF.MVVM.ViewModels.Entitys;
using CourseManagerWPF.Services.ScvManager.ScvMaps;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.IO;

namespace CourseManagerWPF.Services.ScvManager
{
    public class CsvManager
    {
        public static List<StudentVM> ReadStudents(string filePath, GroupVM group)
        {
            List<StudentVM> students = [];

            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                Delimiter = ","
            });

            csv.Context.RegisterClassMap<CsvHelperStudentMap>();

            while (csv.Read())
            {
                var record = csv.GetRecord<StudentRecord>();
                StudentVM student = new(new StudentRecord()
                {
                    Name = record.Name,
                    Surname = record.Surname,
                    Patronymic = record.Patronymic,
                    Birthday = record.Birthday,
                    Email = record.Email,
                    Rating = record.Rating,
                    Group = group.Group,
                    GroupId = group.Group.Id
                });
                students.Add(student);
            }

            return students;
        }

        public static void WriteStudents(string filePath, GroupVM group)
        {
            using var writer = new StreamWriter(filePath);
            using var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                Delimiter = ","
            });

            csv.Context.RegisterClassMap<CsvHelperStudentMap>();

            foreach (var student in group.Group.Students)
            {
                csv.WriteField(student.Name);
                csv.WriteField(student.Surname);
                csv.WriteField(student.Patronymic);
                csv.WriteField(student.Birthday.ToString("dd-MM-yyyy"));
                csv.WriteField(student.Email);
                csv.WriteField(student.Rating);
                csv.NextRecord();
            }
        }
    }
}
