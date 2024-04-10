using CourseManagerDatabase.Database;
using CourseManagerWPF.Database;
using CourseManagerWPF.MVVM.ViewModels.Entity.Extensions;
using CourseManagerWPF.MVVM.ViewModels.Entitys;
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
            _dbRepository.CourseService.AddCourse(course.Course);
            _courses.Add(course);

            _dbRepository.DbSaveChanges();
        }
        public void UpdateCourse(CourseVM course) 
        {
            _dbRepository.CourseService.DeleteCourse(course.Course);
            _dbRepository.CourseService.AddCourse(course.Course);

            _courses.Remove(_courses.First(c => c.Course.Id == course.Course.Id));
            _courses.Add(course);

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
            _dbRepository.GroupService.AddGroup(group.Group);
            _groups.Add(group);

            _dbRepository.DbSaveChanges();
        }
        public void UpdateGroup(GroupVM group) 
        {
            _dbRepository.GroupService.DeleteGroup(group.Group);
            _dbRepository.GroupService.AddGroup(group.Group);

            _groups.Remove(_groups.First(g => g.Group.Id == group.Group.Id));
            _groups.Add(group);

            _dbRepository.DbSaveChanges();
        }
        public void DeleteGroup(GroupVM group) 
        {
            _dbRepository.GroupService.DeleteGroup(group.Group);
            _groups.Remove(_groups.First(g => g.Group.Id == group.Group.Id));

            _dbRepository.DbSaveChanges();
        }
        public void ExportGroup(GroupVM group) 
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
                        
                        break;
                    case ".pdf":
                        
                        break;
                    case ".csv":
                        CsvManager.WriteStudents(selectedFilePath, group);
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
                    AddStudent(student);
            }
        }

        public void AddStudent(StudentVM student) 
        {
            student.Student.Id = Guid.NewGuid();
            _dbRepository.StudentService.AddStudent(student.Student);
            _students.Add(student);

            _dbRepository.DbSaveChanges();
        }
        public void UpdateStudent(StudentVM student) 
        {
            _dbRepository.StudentService.DeleteStudent(student.Student);
            _dbRepository.StudentService.AddStudent(student.Student);

            _students.Remove(_students.First(s => s.Student.Id == student.Student.Id));
            _students.Add(student);

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
            _dbRepository.TeacherService.AddTeacher(teacher.Teacher);
            _teachers.Add(teacher);

            _dbRepository.DbSaveChanges();
        }
        public void UpdateTeacher(TeacherVM teacher) 
        {
            _dbRepository.TeacherService.DeleteTeacher(teacher.Teacher);
            _dbRepository.TeacherService.AddTeacher(teacher.Teacher);

            _teachers.Remove(_teachers.First(s => s.Teacher.Id == teacher.Teacher.Id));
            _teachers.Add(teacher);

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
