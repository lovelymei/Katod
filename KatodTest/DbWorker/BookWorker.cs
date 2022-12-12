using System.Collections.Generic;
using System.Linq;

namespace Katod
{
    /// <summary>
    /// Репозиторий
    /// </summary>
    public class BookWorker
    { 
        /// <summary>
        /// Получить все книги
        /// </summary>
        /// <returns></returns>
        public static List<BookModel> GetAllBooks()
        {
            using (AppContext db = new AppContext())
            {
                var result = db.BookModel.ToList();
                return result;
            }
        }

        /// <summary>
        /// Добавить книгу
        /// </summary>
        /// <param name="title">Название</param>
        /// <param name="author">Автор</param>
        /// <param name="genre">Жанр</param>
        /// <param name="year">Год издания</param>
        public static void AddBook(string title, string author, string genre, int year)
        {
            using (AppContext db = new AppContext())
            {
                var newBook = new BookModel
                {
                    Title = title,
                    Author = author,
                    Genre = genre,
                    Year = year
                };
                db.BookModel.Add(newBook);
                db.SaveChanges();  
            }
        }

        /// <summary>
        /// Редактировать книгу
        /// </summary>
        /// <param name="book">Книга для редактирования</param>
        public static void EditBook (BookModel book)
        {
            using (AppContext db = new AppContext())
            {
                var editingBook = GetBookById(book.Id);
                if (editingBook != null)
                {
                    editingBook.Title = book.Title;
                    editingBook.Author = book.Author;
                    editingBook.Genre = book.Genre;
                    editingBook.Year = book.Year;
                    db.Update(editingBook);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Удалить книгу
        /// </summary>
        /// <param name="id">идентификатор</param>
        public static void DeleteBook(int id)
        {
            var book = GetBookById(id);
            using (AppContext db = new AppContext())
            {
                if (book != null)
                {
                    db.BookModel.Remove(book);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Получить книгу по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        public static BookModel GetBookById(int id)
        {
            using (AppContext db = new AppContext())
            {
                bool IsExist = db.BookModel.Any(b => b.Id == id);
                if (IsExist)
                {
                    return db.BookModel.FirstOrDefault(b => b.Id == id);
                }
            }
            return null;
        }
    }
}
