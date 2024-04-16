using CourseManagerWPF.MVVM.ViewModels;
using CourseManagerWPF.MVVM.ViewModels.Entitys;
using CourseManagerWPF.MVVM.ViewModels.Pages;
using CourseManagerWPF.MVVM.ViewModels.Pages.EnityPages;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainVM vm)
            {
                vm.Page = new CreatePageVM();
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

        private void ListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Q  && sender is ListBox listBox)
            {
                listBox.SelectedItem = null;
                listBox.SelectedItem = null;
                listBox.SelectedItem = null;
            }
        }
    }
}