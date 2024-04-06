using CourseManagerDatabase.Database;
using CourseManagerWPF.Commands;
using CourseManagerWPF.Database;
using CourseManagerWPF.MVVM.ViewModels.Entitys;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace CourseManagerWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public SchoolDbContext DbContext { get; set; }
        public SchoolRepository DbRepository { get; set; }
        public AppDatabase Database { get; set; }
        public AppCommands Commands { get; set; }

        public ObservableCollection<CourseVM> Courses { get; set; }
        public ObservableCollection<GroupVM> Groups { get; set; }
        public ObservableCollection<StudentVM> Students { get; set; }
        public ObservableCollection<TeacherVM> Teachers { get; set; }

        public App()
        {
            DbContext = new SchoolDbContext();
            DbContext.Database.EnsureCreated();

            DbRepository = new SchoolRepository(DbContext);
            Database = new AppDatabase(DbRepository);

            Courses = new ObservableCollection<CourseVM>(Database.GetCourseVMs());
            Groups = new ObservableCollection<GroupVM>(Database.GetGroupVMs());
            Students = new ObservableCollection<StudentVM>(Database.GetStudentsVMs());
            Teachers = new ObservableCollection<TeacherVM>(Database.GetTeacherVMs());

            Commands = new AppCommands(DbContext, DbRepository, Database, Courses!, Groups!, Students!, Teachers!);
        }

        public void GetData()
        {
            Courses = new ObservableCollection<CourseVM>(Database.GetCourseVMs());
            Groups = new ObservableCollection<GroupVM>(Database.GetGroupVMs());
            Students = new ObservableCollection<StudentVM>(Database.GetStudentsVMs());
            Teachers = new ObservableCollection<TeacherVM>(Database.GetTeacherVMs());
        }

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

                AddCourse = new RelayCommand(OnAddCourseCommandExecuted, CanAddCourseCommandExecute);
                UpdateCourse = new RelayCommand(OnUpdateCourseCommandExecuted, CanUpdateCourseCommandExecute);
                DeleteCourse = new RelayCommand(OnDeleteCourseCommandExecuted, CanDeleteCourseCommandExecute);

                AddGroup = new RelayCommand(OnAddGroupCommandExecuted, CanAddGroupCommandExecute);
                UpdateGroup = new RelayCommand(OnUpdateGroupCommandExecuted, CanUpdateGroupCommandExecute);
                DeleteGroup = new RelayCommand(OnDeleteGroupCommandExecuted, CanDeleteGroupCommandExecute);
                ExportGroup = new RelayCommand(OnExportGroupCommandExecuted, CanExportGroupCommandExecute);
                ImportGroup = new RelayCommand(OnImportGroupCommandExecuted, CanImportGroupCommandExecute);

                AddStudent = new RelayCommand(OnAddStudentCommandExecuted, CanAddStudentCommandExecute);
                UpdateStudent = new RelayCommand(OnUpdateStudentCommandExecuted, CanUpdateStudentCommandExecute);
                DeleteStudent = new RelayCommand(OnDeleteStudentCommandExecuted, CanDeleteStudentCommandExecute);

                AddTeacher = new RelayCommand(OnAddTeacherCommandExecuted, CanAddTeacherCommandExecute);
                UpdateTeacher = new RelayCommand(OnUpdateTeacherCommandExecuted, CanUpdateTeacherCommandExecute);
                DeleteTeacher = new RelayCommand(OnDeleteTeacherCommandExecuted, CanDeleteTeacherCommandExecute);
            }



            public ICommand AddCourse { get; }
            public ICommand UpdateCourse { get; }
            public ICommand DeleteCourse { get; }

            public ICommand AddGroup { get; }
            public ICommand UpdateGroup { get; }
            public ICommand DeleteGroup { get; }
            public ICommand ExportGroup { get; }
            public ICommand ImportGroup { get; }

            public ICommand AddStudent { get; }
            public ICommand UpdateStudent { get; }
            public ICommand DeleteStudent { get; }

            public ICommand AddTeacher { get; }
            public ICommand UpdateTeacher { get; }
            public ICommand DeleteTeacher { get; }

            private bool CanAddCourseCommandExecute(object arg) => true;

            private void OnAddCourseCommandExecuted(object obj)
            {
                if (obj is CourseVM course)
                {
                    _dbRepository.CourseService.AddCourse(course.Course);
                    _courses.Add(course);
                }
            }

            private bool CanUpdateCourseCommandExecute(object arg) => true;

            private void OnUpdateCourseCommandExecuted(object obj)
            {
                if (obj is CourseVM course)
                {
                    _dbRepository.CourseService.DeleteCourse(course.Course);
                    _dbRepository.CourseService.AddCourse(course.Course);

                    _courses.Remove(_courses.First(c => c.Course.Id == course.Course.Id));
                    _courses.Add(course);
                }
            }

            private bool CanDeleteCourseCommandExecute(object arg) => true;

            private void OnDeleteCourseCommandExecuted(object obj)
            {
                if (obj is CourseVM course)
                {
                    _dbRepository.CourseService.DeleteCourse(course.Course);
                    _courses.Remove(_courses.First(c => c.Course.Id == course.Course.Id));
                }
            }

            private bool CanAddGroupCommandExecute(object arg) => true;

            private void OnAddGroupCommandExecuted(object obj)
            {
                if (obj is GroupVM group)
                {
                    _dbRepository.GroupService.AddGroup(group.Group);
                    _groups.Add(group);
                }
            }

            private bool CanUpdateGroupCommandExecute(object arg) => true;

            private void OnUpdateGroupCommandExecuted(object obj)
            {
                if (obj is GroupVM group)
                {
                    _dbRepository.GroupService.DeleteGroup(group.Group);
                    _dbRepository.GroupService.AddGroup(group.Group);

                    _groups.Remove(_groups.First(g => g.Group.Id == group.Group.Id));
                    _groups.Add(group);
                }
            }

            private bool CanDeleteGroupCommandExecute(object arg) => true;

            private void OnDeleteGroupCommandExecuted(object obj)
            {
                if (obj is GroupVM group)
                {
                    _dbRepository.GroupService.DeleteGroup(group.Group);
                    _groups.Remove(_groups.First(g => g.Group.Id == group.Group.Id));
                }
            }

            private bool CanExportGroupCommandExecute(object arg) => true;

            private void OnExportGroupCommandExecuted(object obj)
            {
                throw new NotImplementedException();
            }

            private bool CanImportGroupCommandExecute(object arg) => true;

            private void OnImportGroupCommandExecuted(object obj)
            {
                throw new NotImplementedException();
            }

            private bool CanAddStudentCommandExecute(object arg) => true;

            private void OnAddStudentCommandExecuted(object obj)
            {
                if (obj is StudentVM student)
                {
                    _dbRepository.StudentService.AddStudent(student.Student);
                    _students.Add(student);
                }
            }

            private bool CanUpdateStudentCommandExecute(object arg) => true;

            private void OnUpdateStudentCommandExecuted(object obj)
            {
                if (obj is StudentVM student)
                {
                    _dbRepository.StudentService.DeleteStudent(student.Student);
                    _dbRepository.StudentService.AddStudent(student.Student);

                    _students.Remove(_students.First(s => s.Student.Id == student.Student.Id));
                    _students.Add(student);
                }
            }

            private bool CanDeleteStudentCommandExecute(object arg) => true;

            private void OnDeleteStudentCommandExecuted(object obj)
            {
                if (obj is StudentVM student)
                {
                    _dbRepository.StudentService.DeleteStudent(student.Student);
                    _students.Remove(_students.First(s => s.Student.Id == student.Student.Id));
                }
            }

            private bool CanAddTeacherCommandExecute(object arg) => true;

            private void OnAddTeacherCommandExecuted(object obj)
            {
                if (obj is TeacherVM teacher)
                {
                    _dbRepository.TeacherService.AddTeacher(teacher.Teacher);
                    _teachers.Add(teacher);
                }
            }

            private bool CanUpdateTeacherCommandExecute(object arg) => true;

            private void OnUpdateTeacherCommandExecuted(object obj)
            {
                if (obj is TeacherVM teacher)
                {
                    _dbRepository.TeacherService.DeleteTeacher(teacher.Teacher);
                    _dbRepository.TeacherService.AddTeacher(teacher.Teacher);

                    _teachers.Remove(_teachers.First(s => s.Teacher.Id == teacher.Teacher.Id));
                    _teachers.Add(teacher);
                }
            }

            private bool CanDeleteTeacherCommandExecute(object arg) => true;

            private void OnDeleteTeacherCommandExecuted(object obj)
            {
                if (obj is TeacherVM teacher)
                {
                    _dbRepository.TeacherService.DeleteTeacher(teacher.Teacher);
                    _teachers.Remove(_teachers.First(s => s.Teacher.Id == teacher.Teacher.Id));
                }
            }
        }
    }
}
