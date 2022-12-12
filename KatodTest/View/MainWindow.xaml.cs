using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Katod
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext =  new BookWorkerViewModel();
        }
    }
}
