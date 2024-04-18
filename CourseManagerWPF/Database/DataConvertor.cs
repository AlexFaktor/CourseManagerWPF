using CourseManagerDatabase.Entity;
using CourseManagerWPF.MVVM.ViewModels.Entitys;

namespace CourseManagerWPF.Database
{
    public class DataConvertor
    {
        public static CourseVM FromCourseRecordToCourseVM(CourseRecord record)
        {
            return new CourseVM(record);
        }

        public static CourseRecord FromCourseVMToCourseRecord(CourseVM vm)
        {
            return vm.Course;
        }

        public static GroupVM FromGroupRecordToGroupVM(GroupRecord record)
        {
            return new GroupVM(record);

        }

        public static GroupRecord FromGroupVMToGroupRecord(GroupVM vm)
        {
            return vm.Group;
        }

        public static StudentVM FromStudentRecordToStudentVM(StudentRecord record)
        {
            return new StudentVM(record);
        }

        public static StudentRecord FromStudentVMToStudentRecord(StudentVM vm)
        {
            return vm.Student;
        }

        public static TeacherVM FromTeacherRecordToTeacherVM(TeacherRecord record)
        {
            return new TeacherVM(record);

        }

        public static TeacherRecord FromTeacherVMToTeacherRecord(TeacherVM vm)
        {
            return vm.Teacher;
        }

    }
}
