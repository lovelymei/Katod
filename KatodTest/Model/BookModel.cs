using System;
using System.Linq;

namespace Katod
{
    /// <summary>
    /// Книга
    /// </summary>
    public class BookModel: ICloneable
    {
        /// <summary>
        /// Конструктор класса BookModel
        /// </summary>
        public BookModel()
        {
        }

        /// <summary>
        /// Конструктор класса BookModel
        /// </summary>
        /// <param name="title"> Название книги</param>
        /// <param name="author"> Автор </param>
        /// <param name="genre"> Тематика/жанр</param>
        /// <param name="year"> Год издания</param>
        public BookModel(string title, string author, string genre, int year)
        {
            Title = title;
            Author = author;
            Genre = genre;
            Year = year;
        }

        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название книги
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Автор
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Жанр
        /// </summary>
        public string Genre { get; set; }

        /// <summary>
        /// Год издания
        /// </summary>
        public int Year { get; set; }

        /// <inheritdoc/>
        public object Clone()
        {
            var clone = new BookModel(Title, Author, Genre, Year);
            clone.Id = Id;
            return clone;
        }
    }
}
