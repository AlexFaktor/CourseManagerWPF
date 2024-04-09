using CourseManagerDatabase.Database;
using CourseManagerWPF.Database;
using CourseManagerWPF.MVVM.ViewModels.Entitys;
using System.Collections.ObjectModel;
using System.Windows.Input;

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
                course.Course.Id = Guid.NewGuid();
                _dbRepository.CourseService.AddCourse(course.Course);
                _courses.Add(course);

                _dbRepository.DbSaveChanges();
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

                _dbRepository.DbSaveChanges();
            }
        }

        private bool CanDeleteCourseCommandExecute(object arg) => true;

        private void OnDeleteCourseCommandExecuted(object obj)
        {
            if (obj is CourseVM course)
            {
                _dbRepository.CourseService.DeleteCourse(course.Course);
                _courses.Remove(_courses.First(c => c.Course.Id == course.Course.Id));

                _dbRepository.DbSaveChanges();
            }
        }

        private bool CanAddGroupCommandExecute(object arg) => true;

        private void OnAddGroupCommandExecuted(object obj)
        {
            if (obj is GroupVM group)
            {
                group.Group.Id = Guid.NewGuid();
                _dbRepository.GroupService.AddGroup(group.Group);
                _groups.Add(group);

                _dbRepository.DbSaveChanges();
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

                _dbRepository.DbSaveChanges();
            }
        }

        private bool CanDeleteGroupCommandExecute(object arg) => true;

        private void OnDeleteGroupCommandExecuted(object obj)
        {
            if (obj is GroupVM group)
            {
                _dbRepository.GroupService.DeleteGroup(group.Group);
                _groups.Remove(_groups.First(g => g.Group.Id == group.Group.Id));

                _dbRepository.DbSaveChanges();
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
                student.Student.Id = Guid.NewGuid();
                _dbRepository.StudentService.AddStudent(student.Student);
                _students.Add(student);

                _dbRepository.DbSaveChanges();
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

                _dbRepository.DbSaveChanges();
            }
        }

        private bool CanDeleteStudentCommandExecute(object arg) => true;

        private void OnDeleteStudentCommandExecuted(object obj)
        {
            if (obj is StudentVM student)
            {
                _dbRepository.StudentService.DeleteStudent(student.Student);
                _students.Remove(_students.First(s => s.Student.Id == student.Student.Id));

                _dbRepository.DbSaveChanges();
            }
        }

        private bool CanAddTeacherCommandExecute(object arg) => true;

        private void OnAddTeacherCommandExecuted(object obj)
        {
            if (obj is TeacherVM teacher)
            {
                teacher.Teacher.Id = Guid.NewGuid();
                _dbRepository.TeacherService.AddTeacher(teacher.Teacher);
                _teachers.Add(teacher);

                _dbRepository.DbSaveChanges();
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

                _dbRepository.DbSaveChanges();
            }
        }

        private bool CanDeleteTeacherCommandExecute(object arg) => true;

        private void OnDeleteTeacherCommandExecuted(object obj)
        {
            if (obj is TeacherVM teacher)
            {
                _dbRepository.TeacherService.DeleteTeacher(teacher.Teacher);
                _teachers.Remove(_teachers.First(s => s.Teacher.Id == teacher.Teacher.Id));

                _dbRepository.DbSaveChanges();
            }
        }

    }
}
