using CourseManagerDatabase.Database;
using CourseManagerWPF.Database;
using CourseManagerWPF.MVVM.Models;
using CourseManagerWPF.MVVM.ViewModels.Entity.Extensions;
using CourseManagerWPF.MVVM.ViewModels.Entitys;
using CourseManagerWPF.Services.DocumentСreator;
using CourseManagerWPF.Services.ScvManager;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;

namespace CourseManagerWPF.Commands
{
    public class AppCommands
    {
        private SchoolDbContext _dbContext;
        private SchoolRepository _dbRepository;
        private AppDatabase _database;

        private ObservableCollection<CourseVM> _courses;
        private ObservableCollection<GroupVM> _groups;
        private ObservableCollection<StudentVM> _students;
        private ObservableCollection<TeacherVM> _teachers;

        public AppCommands(SchoolDbContext dbContext, SchoolRepository dbRepository, AppDatabase database,
            ObservableCollection<CourseVM> courses,
            ObservableCollection<GroupVM> groups,
            ObservableCollection<StudentVM> students,
            ObservableCollection<TeacherVM> teachers)
        {
            _dbContext = dbContext;
            _dbRepository = dbRepository;
            _database = database;

            _courses = courses;
            _groups = groups;
            _students = students;
            _teachers = teachers;
        }

        public void AddCourse(CourseVM course)
        {
            course.Course.Id = Guid.NewGuid();
            _dbRepository.CourseService.AddCourseRecord(course.Course);
            _courses.Add(course);

            _dbRepository.DbSaveChanges();
        }
        public void UpdateCourse(CourseVM courseVM)
        {
            var newCourse = courseVM.Course;
            var course = _courses.First(c => c.Course.Id == courseVM.Course.Id);

            course.Course.Name = newCourse.Name;
            course.Course.Groups = newCourse.Groups;

            _dbRepository.DbSaveChanges();
        }
        public void DeleteCourse(CourseVM course)
        {
            _dbRepository.CourseService.DeleteCourse(course.Course);
            _courses.Remove(_courses.First(c => c.Course.Id == course.Course.Id));

            _dbRepository.DbSaveChanges();
        }

        public void AddGroup(GroupVM group)
        {
            group.Group.Id = Guid.NewGuid();
            _dbRepository.GroupService.AddGroupRecord(group.Group);
            _groups.Add(group);

            _dbRepository.DbSaveChanges();
        }
        public void UpdateGroup(GroupVM groupVM)
        {
            var newGroup = groupVM.Group;
            var group = _groups.First(c => c.Group.Id == groupVM.Group.Id);

            group.Group.Name = newGroup.Name;
            group.Group.Course = newGroup.Course;
            group.Group.CourseId = newGroup.CourseId;
            group.Group.Teacher = newGroup.Teacher;
            group.Group.TeacherId = newGroup.TeacherId;

            _dbRepository.DbSaveChanges();
        }
        public void DeleteGroup(GroupVM group)
        {
            _dbRepository.GroupService.DeleteGroup(group.Group);
            _groups.Remove(_groups.First(g => g.Group.Id == group.Group.Id));

            _dbRepository.DbSaveChanges();
        }
        public void ExportGroup(GroupVM groupVM)
        {
            SaveFileDialog saveFileDialog = new()
            {
                InitialDirectory = @"c:\",
                Filter = "Save as docx (*.docx)|*.docx|Save as pdf (*.pdf)|*.pdf|Save as csv (*.csv)|*.csv "
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = saveFileDialog.FileName;
                string extension = Path.GetExtension(selectedFilePath).Trim();
                switch (extension)
                {
                    case ".docx":
                        var group = groupVM.Group;
                        DocumentCreator.CreateStudentTableDocx([.. group.Students],
                                                               group.Course?.Name == null ? "No name" : group.Course.Name,
                                                               group.Name,
                                                               selectedFilePath);
                        break;
                    case ".pdf":
                        var groupp = groupVM.Group;
                        DocumentCreator.CreateStudentTablePdf([.. groupp.Students],
                                                               groupp.Course?.Name == null ? "No name" : groupp.Course.Name,
                                                               groupp.Name,
                                                               selectedFilePath);
                        break;
                    case ".csv":
                        CsvManager.WriteStudents(selectedFilePath, groupVM);
                        break;
                    default:
                        break;
                }
            }
        }
        public void ImportGroup(GroupVM group)
        {
            OpenFileDialog openFileDialog = new()
            {
                Filter = "csv of students (*.csv)|*.csv|text of students (*.txt)|*.txt|all files (*.*)|*.*"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                group.CleanStudents();
                var students = CsvManager.ReadStudents(openFileDialog.FileName, group);
                foreach (var student in students)
                    AddStudent(new StudentVM(student.Student));
            }
        }

        public void AddStudent(StudentVM student)
        {
            student.Student.Id = Guid.NewGuid();
            _dbRepository.StudentService.AddStudentRecord(student.Student);
            _students.Add(student);

            _dbRepository.DbSaveChanges();
        }
        public void UpdateStudent(StudentVM studentVM)
        {
            var newStudent = studentVM.Student;
            var student = _students.First(s => s.Student.Id == studentVM.Student.Id);

            student.Student.Name = newStudent.Name;
            student.Student.Surname = newStudent.Surname;
            student.Student.Patronymic = newStudent.Patronymic;
            student.Student.Birthday = newStudent.Birthday;
            student.Student.Email = newStudent.Email;
            student.Student.Rating = newStudent.Rating;
            student.Student.Group = newStudent.Group;
            student.Student.GroupId = newStudent.GroupId;   

            _dbRepository.DbSaveChanges();
        }
        public void DeleteStudent(StudentVM student)
        {
            _dbRepository.StudentService.DeleteStudent(student.Student);
            _students.Remove(_students.First(s => s.Student.Id == student.Student.Id));

            _dbRepository.DbSaveChanges();
        }

        public void AddTeacher(TeacherVM teacher)
        {
            teacher.Teacher.Id = Guid.NewGuid();
            _dbRepository.TeacherService.AddTeacherRecord(teacher.Teacher);
            _teachers.Add(teacher);

            _dbRepository.DbSaveChanges();
        }
        public void UpdateTeacher(TeacherVM teacherVM)
        {
            var newTeacher = teacherVM.Teacher;
            var teacher = _teachers.First(t => t.Teacher.Id == teacherVM.Teacher.Id);

            teacher.Teacher.Name = newTeacher.Name;
            teacher.Teacher.Surname = newTeacher.Surname;
            teacher.Teacher.Patronymic = newTeacher.Patronymic;
            teacher.Teacher.Birthday = newTeacher.Birthday;
            teacher.Teacher.Email = newTeacher.Email;

            _dbRepository.DbSaveChanges();
        }
        public void DeleteTeacher(TeacherVM teacher)
        {
            _dbRepository.TeacherService.DeleteTeacher(teacher.Teacher);
            _teachers.Remove(_teachers.First(s => s.Teacher.Id == teacher.Teacher.Id));

            _dbRepository.DbSaveChanges();
        }
    }
}
