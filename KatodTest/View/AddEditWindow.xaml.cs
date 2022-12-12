using System.Windows;

namespace Katod
{
    /// <summary>
    /// Логика взаимодействия для AddEditWindow.xaml
    /// </summary>
    public partial class AddEditWindow : Window
    {
        public AddEditWindow()
        {
            InitializeComponent();
            DataContext = new AddEditBookViewModel();
        }

        public AddEditWindow(BookModel book)
        {
            InitializeComponent();
            DataContext = new AddEditBookViewModel(book);
        }
    }
}
