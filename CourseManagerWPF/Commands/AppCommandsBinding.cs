using CourseManagerWPF.Commands.Base;
using CourseManagerWPF.MVVM.ViewModels.Entity.Extensions;
using CourseManagerWPF.MVVM.ViewModels.Entitys;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Input;

namespace CourseManagerWPF.Commands
{

    public class AppCommandsBinding
    {
        private readonly AppCommands _appCommands;

        public AppCommandsBinding(AppCommands appCommands)
        {
            _appCommands = appCommands;

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

        private static MainWindow GetMainWindow()
        {
            var app = (App)Application.Current;
            return (MainWindow)app.MainWindow;
        } 

        private bool CanAddCourseCommandExecute(object arg) => true;

        private void OnAddCourseCommandExecuted(object obj)
        {
            if (obj is CourseVM course)
            {
                _appCommands.AddCourse(course);
                GetMainWindow().RefreshList();
            }
        }

        private bool CanUpdateCourseCommandExecute(object arg) => true;

        private void OnUpdateCourseCommandExecuted(object obj)
        {
            if (obj is CourseVM course)
            {
                _appCommands.UpdateCourse(course);
                GetMainWindow().RefreshList();
            }
        }

        private bool CanDeleteCourseCommandExecute(object arg) => true;

        private void OnDeleteCourseCommandExecuted(object obj)
        {
            if (obj is CourseVM course)
            {
                _appCommands.DeleteCourse(course);
            }
        }

        private bool CanAddGroupCommandExecute(object arg) => true;

        private void OnAddGroupCommandExecuted(object obj)
        {
            if (obj is GroupVM group)
            {
                _appCommands.AddGroup(group);
                GetMainWindow().RefreshList();
            }
        }

        private bool CanUpdateGroupCommandExecute(object arg) => true;

        private void OnUpdateGroupCommandExecuted(object obj)
        {
            if (obj is GroupVM group)
            {
                _appCommands.UpdateGroup(group);
                GetMainWindow().RefreshList();
            }
        }

        private bool CanDeleteGroupCommandExecute(object arg) => true;

        private void OnDeleteGroupCommandExecuted(object obj)
        {
            if (obj is GroupVM group)
            {
                _appCommands.DeleteGroup(group);
            }
        }

        private bool CanExportGroupCommandExecute(object arg) => true;

        private void OnExportGroupCommandExecuted(object obj)
        {
            if (obj is GroupVM group)
            {
                AppCommands.ExportGroup(group);
            }
        }

        private bool CanImportGroupCommandExecute(object arg) => true;

        private void OnImportGroupCommandExecuted(object obj)
        {
            if (obj is GroupVM group)
            {
                _appCommands.ImportGroup(group);
                GetMainWindow().RefreshList();
            }
        }

        private bool CanAddStudentCommandExecute(object arg) => true;

        private void OnAddStudentCommandExecuted(object obj)
        {
            if (obj is StudentVM student)
            {
                _appCommands.AddStudent(student);
                GetMainWindow().RefreshList();
            }
        }

        private bool CanUpdateStudentCommandExecute(object arg) => true;

        private void OnUpdateStudentCommandExecuted(object obj)
        {
            if (obj is StudentVM student)
            {
                _appCommands.UpdateStudent(student);
                GetMainWindow().RefreshList();
            }
        }

        private bool CanDeleteStudentCommandExecute(object arg) => true;

        private void OnDeleteStudentCommandExecuted(object obj)
        {
            if (obj is StudentVM student)
            {
                _appCommands.DeleteStudent(student);
            }
        }

        private bool CanAddTeacherCommandExecute(object arg) => true;

        private void OnAddTeacherCommandExecuted(object obj)
        {
            if (obj is TeacherVM teacher)
            {
                _appCommands.AddTeacher(teacher);
                GetMainWindow().RefreshList();
            }
        }

        private bool CanUpdateTeacherCommandExecute(object arg) => true;

        private void OnUpdateTeacherCommandExecuted(object obj)
        {
            if (obj is TeacherVM teacher)
            {
                _appCommands.UpdateTeacher(teacher);
                GetMainWindow().RefreshList();
            }
        }

        private bool CanDeleteTeacherCommandExecute(object arg) => true;

        private void OnDeleteTeacherCommandExecuted(object obj)
        {
            if (obj is TeacherVM teacher)
            {
                _appCommands.DeleteTeacher(teacher);
            }
        }
    }
}
