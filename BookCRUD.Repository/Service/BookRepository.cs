using BookCRUD.DataAccess.Entity;
using System.Text.Json;

namespace BookCRUD.Repository.Services
{
    public class BookRepository : IBookRepository
    {
        private readonly string _filePath;
        private readonly string _directoryPath;
        private List<Book> _book;
        public BookRepository()
        {
            _filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Book.json");
            _directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");

            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]");
            }
            _book = GetAllbooks();

        }
        public Guid AddBook(Book book)
        {
            _book.Add(book);
            SaveDate();
            return book.Id;
        }

        public void DeleteBook(Guid id)
        {
            var book = GetBookById(id);
            _book.Remove(book);
            SaveDate();

        }

        public List<Book> GetAllbooks()
        {
            var bookJson = File.ReadAllText(_filePath);
            var bookList = JsonSerializer.Deserialize<List<Book>>(bookJson) ?? new List<Book>();
            return bookList;

        }

        public Book GetBookById(Guid id)
        {
            var book = _book.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                throw new ArgumentNullException($"The book with {id} is not found!");
            }
            return book;
        }

        public void UpdateBook(Book book)
        {
            var bookfromDb = GetBookById(book.Id);
            var index = _book.IndexOf(bookfromDb);
            _book[index] = book;
            SaveDate();
        }

        private void SaveDate()
        {
            var bookJson = JsonSerializer.Serialize(_book);
            File.WriteAllText(_filePath, bookJson);
        }
    }
}
