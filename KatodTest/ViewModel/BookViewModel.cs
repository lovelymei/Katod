using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Katod
{
    /// <summary>
    /// ViewModel
    /// </summary>
    public class BookViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Конструктор класса BookViewModel
        /// </summary>
        /// <param name="model">книга</param>
        public BookViewModel(BookModel model, Command deleteCommand, Command editCommand)
        {
            Book = model;
            if (model.Genre == "Классика")
                IsClassic = true;
            OnPropertyChanged("Book");
            DeleteSelectedBook = deleteCommand;
            OpenEditWindowCommand = editCommand;
        }

        /// <summary>
        /// Свойство команды для удаления книги
        /// </summary>
        public Command DeleteSelectedBook { get; }

        /// <summary>
        /// Свойство команды для открытия окна
        /// </summary>
        public Command OpenEditWindowCommand { get; }

        /// <summary>
        /// Книга
        /// </summary>
        public BookModel Book { get; private set; }

        /// <summary>
        /// Стоит ли у книги жанр "Классика"
        /// </summary>
        public bool IsClassic { get; private set; }

        /// <inheritdoc/>
		public event PropertyChangedEventHandler PropertyChanged;

        /// <inheritdoc/>
        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

