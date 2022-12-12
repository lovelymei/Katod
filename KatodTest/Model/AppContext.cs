using Microsoft.EntityFrameworkCore;

namespace Katod
{
    /// <summary>
    /// Класс, предоставляющий доступ к бд
    /// </summary>
    public class AppContext : DbContext
    {
        /// <summary>
        /// Определение набора данных для сущности BookModel
        /// </summary>
        public DbSet<BookModel> BookModel { get; set; }

        /// <summary>
        /// Конструктор класса AppContext без параметров
        /// </summary>
        /// <param name="options">Параметры, используемые DbContext</param>
        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Конструктор класса AppContext без параметров
        /// </summary>
        public AppContext()
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Конфигурация моделей
        /// </summary>
        /// <param name="modelBuilder"> для создания модели контекста </param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          base.OnModelCreating(modelBuilder);
        }
        /// <summary>
        /// Настройка бд
        /// </summary>
        /// <param name="optionsBuilder"> Используется для настройки экземпляров TOptions</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=katoddb;Trusted_Connection=True");
        }

    }
}
