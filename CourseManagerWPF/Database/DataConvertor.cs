using CourseManagerDatabase.Entitys;
using CourseManagerWPF.MVVM.ViewModels.Entitys;

namespace CourseManagerWPF.Database
{
    public class DataConvertor
    {
        public static CourseVM FromCourseRecordToCourseVM(CourseRecord record)
        {
            var groups = record.Groups.ToList();

            return new CourseVM(record.Id, record.Name, groups.Select(FromGroupRecordToGroupVM).ToList());
        }

        public static CourseRecord FromCourseVMToCourseRecord(CourseVM vm)
        {
            return new CourseRecord()
            {
                Id = vm.Id,
                Name = vm.Name,
                Groups = (ICollection<GroupRecord>)vm.Groups.Select(FromGroupVMToGroupRecord),
            };
        }

        public static GroupVM FromGroupRecordToGroupVM(GroupRecord record)
        {
            return new GroupVM(
                record.Id,
                record.Name,
                FromCourseRecordToCourseVM(record.Course),
                record.Students.Select(FromStudentRecordToStudentVM).ToList(),
                FromTeacherRecordToTeacherVM(record.Teacher));

        }

        public static GroupRecord FromGroupVMToGroupRecord(GroupVM vm)
        {
            return new GroupRecord()
            {
                Id = vm.Id,
                Name = vm.Name,
                Course = FromCourseVMToCourseRecord(vm.Course),
                Students = (ICollection<StudentRecord>)vm.Students.Select(FromStudentVMToStudentRecord),
                Teacher = FromTeacherVMToTeacherRecord(vm.Teacher),
            };
        }

        public static StudentVM FromStudentRecordToStudentVM(StudentRecord record)
        {
            return new StudentVM(
                record.Id,
                record.Name,
                record.Surname,
                record.Patronymic,
                record.Birthday,
                record.Email,
                record.Rating,
                FromGroupRecordToGroupVM(record.Group));
        }

        public static StudentRecord FromStudentVMToStudentRecord(StudentVM vm)
        {
            return new StudentRecord()
            {
                Id = vm.Id,
                Name = vm.Name,
                Surname = vm.Surname,
                Patronymic = vm.Patronymic,
                Birthday = vm.Birthday,
                Email = vm.Email,
                Rating = vm.Rating,
                Group = FromGroupVMToGroupRecord(vm.Group)
            };
        }

        public static TeacherVM FromTeacherRecordToTeacherVM(TeacherRecord record)
        {
            return new TeacherVM(
                record.Id,
                record.Name,
                record.Surname,
                record.Patronymic,
                record.Birthday,
                record.Email,
                record.Groups.Select(FromGroupRecordToGroupVM).ToList());
        }

        public static TeacherRecord FromTeacherVMToTeacherRecord(TeacherVM vm)
        {
            var groupsVM = vm.Groups;
            return new TeacherRecord()
            {
                Id = vm.Id,
                Name = vm.Name,
                Surname = vm.Surname,
                Patronymic = vm.Patronymic,
                Birthday = vm.Birthday,
                Email = vm.Email,
                Groups = (ICollection<GroupRecord>)groupsVM.Select(FromGroupVMToGroupRecord)
            };
        }
    }
}
