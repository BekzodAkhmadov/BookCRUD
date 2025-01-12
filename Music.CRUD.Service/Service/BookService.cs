using BookCRUD.DataAccess.Entity;
using BookCRUD.Repository.Services;
using Music.CRUD.Service.DTOs;

namespace Music.CRUD.Service.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService()
        {
            _bookRepository = new BookRepository();
        }

        public Guid AddBook(BookDto bookDto)
        {
            var book = ConvertToBookEntity(bookDto);
            var bookId = _bookRepository.AddBook(book);
            return bookId;
        }

        public void UpdateBook(BookDto bookDto)
        {
            var book = ConvertToBookEntity(bookDto);
            _bookRepository.UpdateBook(book);
        }
        public void DeleteBook(Guid id)
        {
            _bookRepository.DeleteBook(id);
        }

        public List<BookDto> GetAllbooks()
        {
            return _bookRepository.GetAllbooks()
                .Select(book => ConvertToBookDto(book))
                .ToList();
        }

        public List<BookDto> GetAllBooksByAuthor(string author)
        {
            return GetAllbooks()
                .Where(book => book.Author
                .Contains(author, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<BookDto> GetBooksPublishedAfterYear(int year)
        {
            return GetAllbooks()
                .Where(book => book.PublishedDate.Year > year)
                .ToList();
        }

        public List<BookDto> GetBooksSortedByRating()
        {
            return GetAllbooks()
                .OrderByDescending(book => book.Rating)
                .ThenBy(book => book.Author)
                .ToList();
        }

        public List<BookDto> GetBooksWithinPageRange(int minPages, int maxPages)
        {
            return GetAllbooks()
                .Where(book => book.Pages >= minPages && book.Pages <= maxPages)
                .ToList();
        }

        public BookDto GetMostPopularBook()
        {
            return GetAllbooks()
                .OrderByDescending(book => book.NumberOfCopiesSold)
                .FirstOrDefault() ?? throw new InvalidOperationException("The storage is empty!");
        }

        public List<BookDto> GetRecentBooks(int years)
        {
            return GetAllbooks()
                .Where(book => book.PublishedDate.Year >= DateTime.Now.Year - years)
                .ToList();
        }

        public BookDto GetTopRatedBook()
        {
            return GetBooksSortedByRating()
                .FirstOrDefault() ?? throw new InvalidOperationException("The storage is empty!");
        }

        public int GetTotalCopiesSoldByAuthor(string author)
        {
            return GetAllbooks()
                .Where(book => book.Author == author)
                .Max(book => book.NumberOfCopiesSold);
        }

        public List<BookDto> SearchBooksByTitle(string keyword)
        {
            return GetAllbooks()
                .Where(book => book.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        private Book ConvertToBookEntity(BookDto bookDto)
        {
            return new Book()
            {
                Id = bookDto.Id ?? Guid.NewGuid(),
                Author = bookDto.Author,
                NumberOfCopiesSold = bookDto.NumberOfCopiesSold,
                Pages = bookDto.Pages,
                PublishedDate = bookDto.PublishedDate,
                Rating = bookDto.Rating,
                Title = bookDto.Title,

            };
        }
        private BookDto ConvertToBookDto(Book book)
        {
            return new BookDto()
            {
                Id = book.Id,
                Author = book.Author,
                Title = book.Title,
                Rating = book.Rating,
                PublishedDate = book.PublishedDate,
                NumberOfCopiesSold = book.NumberOfCopiesSold,
                Pages = book.Pages,

            };
        }


    }
}
