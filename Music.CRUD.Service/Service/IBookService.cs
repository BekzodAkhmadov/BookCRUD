using BookCRUD.DataAccess.Entity;
using Music.CRUD.Service.DTOs;

namespace Music.CRUD.Service.Service
{
    public interface IBookService
    {
        /// <summary>
        /// Adds a new book to the collection and returns its unique identifier.
        /// </summary>
        /// <param name="bookDto">A BookDto object containing details of the book to be added.</param>
        /// <returns>The unique identifier (GUID) of the newly added book.</returns>
        Guid AddBook(BookDto bookDto);
        /// <summary>
        /// Deletes a book from the collection based on its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier (GUID) of the book to be deleted.</param>
        void DeleteBook(Guid id);
        /// <summary>
        /// Updates the details of an existing book in the collection.
        /// </summary>
        /// <param name="bookDto">A BookDto object containing the updated details of the book.</param>
        void UpdateBook(BookDto bookDto);
        /// <summary>
        /// Retrieves a list of all books in the collection with their details as data transfer objects (DTOs).
        /// </summary>
        /// <returns>A list of BookDto objects containing details of all the books.</returns>
        List<BookDto> GetAllbooks();
        /// <summary>
        /// Retrieves a list of books written by the specified author.
        /// </summary>
        /// <param name="author">The name of the author whose books are to be retrieved.</param>
        /// <returns>A lis of BookDto objects containing details of the books authoreed by the specified author.</returns>
        List<BookDto> GetAllBooksByAuthor(string author);
        /// <summary>
        /// Retrieves the top-rated boook from the collection.
        /// </summary>
        /// <returns>A BookDto object containing details of the highest-rated book.</returns>
        BookDto GetTopRatedBook();
        /// <summary>
        /// Retrieves a lis of books published after the specified year.
        /// </summary>
        /// <param name="year">The year after which books were published to be retrieved.</param>
        /// <returns>A list of BookDto objects containing details of the books published after the specified year.</returns>
        List<BookDto> GetBooksPublishedAfterYear(int year);
        /// <summary>
        /// Retrieves the most popular book from the collection.
        /// </summary>
        /// <returns>A BookDto object containing details of the most popular book.</returns>
        BookDto GetMostPopularBook();
        /// <summary>
        /// Searches for books whose titles contains specified keyword.
        /// </summary>
        /// <param name="keyword">The keyword to search for in book titles.</param>
        /// <returns>A list of BookDto objects containing details of the books with titles that match keyword.</returns>
        List<BookDto> SearchBooksByTitle(string keyword);
        /// <summary>
        /// Retrieves a list of books with a page count within the specified range.
        /// </summary>
        /// <param name="minPages">The minimum number of pages.</param>
        /// <param name="maxPages">The maximum number of pages.</param>
        /// <returns>A list of BookDto objects containing details of the book within the specified page range.</returns>
        List<BookDto> GetBooksWithinPageRange(int minPages, int maxPages);
        /// <summary>
        /// Retrieves the total number of copies sold for all books by the specified author.
        /// </summary>
        /// <param name="author">The name of the author whose total book sales are to be calculated.</param>
        /// <returns>The total number of copies sold for books written by the specified author.</returns>
        int GetTotalCopiesSoldByAuthor(string author);
        /// <summary>
        /// Retrieves a list of books sorted by their ratings in descending order.
        /// </summary>
        /// <returns>A list of BookDto objects containing details of the books, sorted by their ratings.</returns>
        List<BookDto> GetBooksSortedByRating();
        /// <summary>
        /// Retrieves a list of books published within the last specified number of years.
        /// </summary>
        /// <param name="years">The number of recent years to consider for retrieving books.</param>
        /// <returns>A lisst of BookDto objects containing details of the books published within the specified timeframe.</returns>
        List<BookDto> GetRecentBooks(int years);
    }
}