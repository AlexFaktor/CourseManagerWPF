using CourseManagerWPF.MVVM.ViewModels.Pages;
using System.Windows.Controls;
using System.Windows.Input;

namespace CourseManagerWPF.MVVM.Views
{
    /// <summary>
    /// Логика взаимодействия для CreateV.xaml
    /// </summary>
    public partial class CreateV : UserControl
    {
        public CreateV()
        {
            InitializeComponent();
        }

        private void Button_PreviewMouseDownCourse(object sender, MouseButtonEventArgs e)
        {
            if (sender is Button button)
            {
                button.CommandParameter = (button.DataContext as CreatePageVM)!.GetCourse;
            }
        }

        private void Button_PreviewMouseDownGroup(object sender, MouseButtonEventArgs e)
        {
            if (sender is Button button)
            {
                button.CommandParameter = (button.DataContext as CreatePageVM)!.GetGroup;
            }
        }

        private void Button_PreviewMouseDownStudent(object sender, MouseButtonEventArgs e)
        {
            if (sender is Button button)
            {
                button.CommandParameter = (button.DataContext as CreatePageVM)!.GetStudent;
            }
        }

        private void Button_PreviewMouseDownTeacher(object sender, MouseButtonEventArgs e)
        {
            if (sender is Button button)
            {
                button.CommandParameter = (button.DataContext as CreatePageVM)!.GetTeacher;
            }
        }
    }
}
