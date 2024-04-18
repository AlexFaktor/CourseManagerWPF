using CourseManagerWPF.MVVM.ViewModels;
using CourseManagerWPF.MVVM.ViewModels.Entitys;
using CourseManagerWPF.MVVM.ViewModels.Pages;
using CourseManagerWPF.MVVM.ViewModels.Pages.EnityPages;
using System.Windows;
using System.Windows.Controls;

namespace CourseManagerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void RefreshList()
        {
            listCourses.Items.Refresh();
            listGroups.Items.Refresh();
            listStudents.Items.Refresh();
            listTeachers.Items.Refresh();
        }

        private void Button_NewCreatePage(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainVM vm)
            {
                vm.Page = new CreatePageVM();
            }
        }

        private void Button_RefreshList(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainVM)
            {
                listCourses.SelectedItem = null;
                listGroups.SelectedItem = null;
                listStudents.SelectedItem = null;
                listTeachers.SelectedItem = null;
            }
        }

        private void ListBox_UnselectedCourse(object sender, RoutedEventArgs e)
        {
            if (sender is ListBox listCourses && DataContext is MainVM vm)
            {
                if (listCourses.SelectedItem != null)
                    vm.Page = new CoursePageVM((CourseVM)listCourses.SelectedItem);
                else
                    vm.Page = new CreatePageVM();
                listCourses.Items.Refresh();
            }
        }


        private void ListBox_UnselectedGroup(object sender, RoutedEventArgs e)
        {
            if (sender is ListBox listGroups && DataContext is MainVM vm)
            {
                if (listGroups.SelectedItem != null)
                    vm.Page = new GroupPageVM((GroupVM)listGroups.SelectedItem);
                else
                    vm.Page = new CreatePageVM();
                listGroups.Items.Refresh();
            }
        }

        private void ListBox_UnselectedStudent(object sender, RoutedEventArgs e)
        {
            if (sender is ListBox listStudents && DataContext is MainVM vm)
            {
                if (listStudents.SelectedItem != null)
                    vm.Page = new StudentPageVM((StudentVM)listStudents.SelectedItem);
                else
                    vm.Page = new CreatePageVM();
                listStudents.Items.Refresh();
            }
        }

        private void ListBox_UnselectedTeacher(object sender, RoutedEventArgs e)
        {
            if (sender is ListBox listTeachers && DataContext is MainVM vm)
            {
                if (listTeachers.SelectedItem != null)
                    vm.Page = new TeacherPageVM((TeacherVM)listTeachers.SelectedItem);
                else
                    vm.Page = new CreatePageVM();
            }
        }
    }
}