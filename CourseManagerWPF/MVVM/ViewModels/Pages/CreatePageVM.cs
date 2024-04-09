using CourseManagerDatabase.Entity;
using CourseManagerWPF.Commands;
using CourseManagerWPF.MVVM.ViewModels.Entitys;
using CourseManagerWPF.MVVM.ViewModels.Pages.Base;
using System.Windows;

namespace CourseManagerWPF.MVVM.ViewModels.Pages
{
    internal class CreatePageVM : PageVM
    {
        private CourseVM _course;
        private GroupVM _group;
        private StudentVM _student;
        private TeacherVM _teacher;

        public AppCommands Commands { get; set; }

        public CreatePageVM()
        {
            _course = new CourseVM(new CourseRecord());
            _group = new GroupVM(new GroupRecord());
            _student = new StudentVM(new StudentRecord());
            _teacher = new TeacherVM(new TeacherRecord());

            var app = (App)Application.Current;
            Commands = app.Commands;
        }

        public CourseVM Course
        {
            get => _course;
            set => Set(ref _course, value);
        }
        public GroupVM Group
        {
            get => _group;
            set => Set(ref _group, value);
        }
        public StudentVM Student
        {
            get => _student;
            set => Set(ref _student, value);
        }
        public TeacherVM Teacher
        {
            get => _teacher;
            set => Set(ref _teacher, value);
        }

        public CourseVM GetCourse { get => CreateCourse(Course.Course); }
        private static CourseVM CreateCourse(CourseRecord course)
        {
            return new CourseVM(new CourseRecord()
            {
                Name = course.Name,
                Groups = course.Groups
            });
        }

        public GroupVM GetGroup { get => CreateGroup(Group.Group); }
        private static GroupVM CreateGroup(GroupRecord group)
        {
            var courseOfGroup = group.Course;
            var teacherOfGroup = group.Teacher;

            Guid courseId = courseOfGroup != null ? courseOfGroup!.Id : Guid.Empty;
            Guid teahetId = teacherOfGroup != null ? teacherOfGroup!.Id : Guid.Empty;

            return new GroupVM(new GroupRecord()
            {
                Name = group.Name,
                CourseId = courseId,
                Course = group.Course,
                Students = group.Students,
                TeacherId = teahetId,
                Teacher = group.Teacher,
            });
        }

        public StudentVM GetStudent { get => CreateStudent(Student.Student); }
        private static StudentVM CreateStudent(StudentRecord student)
        {
            return new StudentVM(new StudentRecord()
            {
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname,
                Patronymic = student.Patronymic,
                Birthday = student.Birthday,
                Email = student.Email,
                Rating = student.Rating,
                GroupId = student.GroupId,
                Group = student.Group,
            });
        }

        public TeacherVM GetTeacher { get => CreateTeacher(Teacher.Teacher); }
        private static TeacherVM CreateTeacher(TeacherRecord teacher)
        {
            return new TeacherVM(new TeacherRecord()
            {
                Id = teacher.Id,
                Name = teacher.Name,
                Surname = teacher.Surname,
                Patronymic = teacher.Patronymic,
                Birthday = teacher.Birthday,
                Email = teacher.Email,
                Groups = teacher.Groups,
            });
        }
    }
}
