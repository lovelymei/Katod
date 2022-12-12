using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Katod
{
    /// <summary>
    /// ViewModel для обновления/добавления книг
    /// </summary>
    internal class AddEditBookViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Книга
        /// </summary>
        private BookModel _book;

        /// <summary>
        /// Свойство для книги
        /// </summary>
        public BookModel Book => _book;

        /// <summary>
        /// Команда для редактирования/добавления книги
        /// </summary>
        private Command _addEditBookCommand;

        /// <summary>
        /// Конструктор класса AddEditBookViewModel - в случае добавления книги
        /// </summary>
        public AddEditBookViewModel()
        {
            _book = new BookModel();
        }

        /// <summary>
        /// Конструктор класса AddEditBookViewModel - в случае редактирования книги
        /// </summary>
        /// <param name="book"></param>
        public AddEditBookViewModel(BookModel book)
        {
            _book = book.Clone() as BookModel;
        }

        /// <summary>
        /// Команда для закрытия окна
        /// </summary>
        private Command _closeCommand;

        /// <summary>
        /// Свойство команды закрытия окна
        /// </summary>
        public Command CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new Command(obj =>
                {
                    var wnd = obj as Window;
                    wnd.Close();
                }));
            }
        }

        /// <summary>
        /// Свойство команды добавления/редактирования книги
        /// </summary>
        public Command AddEditBookCommand
        {
            get
            {
                return _addEditBookCommand ??
                  (_addEditBookCommand = new Command(obj =>
                  {
                      var wnd = obj as Window;
                      try
                      {
                          AddEditBook();
                          wnd.Close();
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                      }
                  }));
            }
        }

        /// <summary>
        /// добавление/редактирование книги
        /// </summary>
        private void AddEditBook()
        {
            var editingBook = BookWorker.GetBookById(_book.Id);
            if (editingBook == null)
            {
                Add();
            }
            else
            {
                Edit();
            }
        }

        /// <summary>
        /// Проверка поля "год"
        /// </summary>
        /// <exception cref="Exception">Год меньше 1000 или больше 2023</exception>
        private void CheckYear()
        {
            if (_book.Year < 1 || _book.Year > DateTime.Now.Year)
            {
                throw new Exception("Ошибка в поле 'Год'");
            }
        }

        /// <summary>
        /// Проверка поля "Автор"
        /// </summary>
        /// <exception cref="Exception">В строке есть цифры</exception>
        private void CheckAuthor()
        {
            var charList = _book.Author.ToCharArray().ToList();
            var containsDigits = false;

            foreach (var symbol in charList)
            {
                if (char.IsDigit(symbol))
                {
                    containsDigits = true;
                }
            }

            if (containsDigits)
            {
                throw new Exception("Ошибка в поле 'Автор'");
            }
        }

        /// <summary>
        /// Проверка полей "год" и "автор"
        /// </summary>
        private void Checking()
        {
            CheckAuthor();
            CheckYear();
        }

        /// <summary>
        /// Добавление книги
        /// </summary>
        private void Add()
        {
            Checking();
            BookWorker.AddBook(_book.Title, _book.Author, _book.Genre, _book.Year);
        }

        /// <summary>
        /// Редактирование книги
        /// </summary>
        private void Edit()
        {
            Checking();
            BookWorker.EditBook(_book);
        }

        /// <inheritdoc/>
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
