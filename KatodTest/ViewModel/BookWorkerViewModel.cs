using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Katod
{
    /// <summary>
    /// ViewModel для MainWindow
    /// </summary>
    internal class BookWorkerViewModel : INotifyPropertyChanged 
    {
        /// <summary>
        /// Команда открытия окна
        /// </summary>
        private Command _openAddWindowCommand;
        /// <summary>
        /// Команда сортировки по году
        /// </summary>
        private Command _sortByYearCommand;
        /// <summary>
        /// Команда сортировки по автору
        /// </summary>
        private Command _sortByAuthorCommand;

        /// <summary>
        /// Список книг (BookViewModel)
        /// </summary>
        private ObservableCollection<BookViewModel> _allBooks = new ObservableCollection<BookViewModel>();

        /// <summary>
        /// Свойство для ObservableCollection<BookViewModel>
        /// </summary>
        public ObservableCollection<BookViewModel> AllBooks
        {
            get { return _allBooks; }
            set { _allBooks = value; OnPropertyChanged("AllBooks"); }
        }

        /// <summary>
        /// Свойство команды для открытия окна
        /// </summary>
        public Command OpenAddWindowCommand
        {
            get
            {
                return _openAddWindowCommand ??
                  (_openAddWindowCommand = new Command(obj =>
                  {
                      AddEditWindow window = new AddEditWindow();
                      window.ShowDialog();
                      AllBooks = LoadBooks();
                  }));
            }
        }

        /// <summary>
        /// Свойство команды для сортировки по году
        /// </summary>
        public Command SortByYearCommand
        {
            get
            {
                return _sortByYearCommand ??
                    (_sortByYearCommand = new Command(obj =>
                    {
                        AllBooks = new ObservableCollection<BookViewModel>(_allBooks.OrderBy(c => c.Book.Year));
                    }));
            }
        }

        /// <summary>
        /// свойство команды для сортировки по Автору
        /// </summary>
        public Command SortByAuthorCommand
        {
            get
            {
                return _sortByAuthorCommand ??
                    (_sortByAuthorCommand = new Command(obj =>
                    {
                        AllBooks = new ObservableCollection<BookViewModel>(_allBooks.OrderBy(c => c.Book.Author));
                    }));
            }
        }

        /// <inheritdoc/>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Конструктор класса BookWorkerViewModel
        /// </summary>
        public BookWorkerViewModel()
        {
           AllBooks = LoadBooks();
        }

        /// <inheritdoc/>
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }


        /// <summary>
        /// Загрузка книг
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<BookViewModel> LoadBooks()
        {
            return new ObservableCollection<BookViewModel>(BookWorker.GetAllBooks().Select(b => new BookViewModel(b,
                    new Command(ob => { 
                        BookWorker.DeleteBook(b.Id);
                        AllBooks.Remove(AllBooks.First(c => c.Book.Id == b.Id));
                    }),
                    new Command(ob =>
                    {
                        var wnd = new AddEditWindow(b);
                        var dialogResult = wnd.ShowDialog();
                        AllBooks = LoadBooks();
                    })
                    )));
        }
    }
}
