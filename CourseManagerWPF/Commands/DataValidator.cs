using CourseManagerWPF.MVVM.ViewModels.Entitys;
using System.Windows;

namespace CourseManagerWPF.Commands
{
    public class DataValidator
    {
        public static bool IsCourseValid(CourseVM course)
        {
            var app = (App)Application.Current;
            var courses = app.Courses;

            if (course == null)
                return false;
            if (course.Course == null || course.Course.Name == string.Empty)
            {
                MessageBox.Show("Name cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (courses.Any(c => c.Course.Name == course.Course.Name))
            {
                MessageBox.Show("A course with this name already exists", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        public static bool IsGroupValid(GroupVM group)
        {
            var app = (App)Application.Current;
            var groups = app.Groups;

            if (group == null)
                return false;
            if (group.Group == null || group.Group.Name == string.Empty)
            {
                MessageBox.Show("Name cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (groups.Any(g => g.Group.Name == group.Group.Name))
            {
                MessageBox.Show("A group with this name already exists", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        public static bool IsStudentValid(StudentVM student)
        {
            var app = (App)Application.Current;
            var students = app.Students;

            if (student == null)
                return false;
            if (student.Student == null || student.Student.Name == string.Empty)
            {
                MessageBox.Show("Name cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (students.Any(s =>
            s.Student.Name == student.Student.Name &&
            s.Student.Surname == student.Student.Surname &&
            s.Student.Patronymic == student.Student.Patronymic &&
            s.Student.Birthday == student.Student.Birthday))
            {
                MessageBox.Show("A student with this name, surname, patronymic, and birthday already exists", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        public static bool IsTeacherValid(TeacherVM teacher)
        {
            var app = (App)Application.Current;
            var teachers = app.Teachers;

            if (teacher == null)
                return false;
            if (teacher.Teacher == null || teacher.Teacher.Name == string.Empty)
            {
                MessageBox.Show("Name cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (teachers.Any(t =>
            t.Teacher.Name == teacher.Teacher.Name &&
            t.Teacher.Surname == teacher.Teacher.Surname &&
            t.Teacher.Patronymic == teacher.Teacher.Patronymic &&
            t.Teacher.Birthday == teacher.Teacher.Birthday))
            {
                MessageBox.Show("A teacher with this name, surname, patronymic, and birthday already exists", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}

