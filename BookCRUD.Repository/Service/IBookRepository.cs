using BookCRUD.DataAccess.Entity;

namespace BookCRUD.Repository.Services
{
    public interface IBookRepository
    {
        /// <summary>
        /// Adds new boook to the storage
        /// </summary>
        /// <param name="book">An instance of the <see cref="Book"/> class representing the music to add.</param>
        /// <returns>The ID of the added book as an integer.</returns>
        Guid AddBook(Book book);
        /// <summary>
        /// Deletes a book from the storage based on its unique identifier
        /// </summary>
        /// <param name="id">The unique identifier (GUID) of the book to delete.</param>
        void DeleteBook(Guid id);
        /// <summary>
        /// Updates the details of an existing book in the storage.
        /// </summary>
        /// <param name="id">An instance of <see cref="Book"/> class representing the updated book details.</param>
        void UpdateBook(Book book);
        /// <summary>
        /// Retrieves a book from the storage by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier (GUID) of the book to retrieve.</param>
        /// <returns>An instance of th <see cref="Book"/> class representing the book the specified ID. </returns>
        Book GetBookById(Guid id);
        /// <summary>
        /// Retrieves a list of all books from the storage.
        /// </summary>
        /// <returns>A list of <see cref="Book"/> objects representing all the book in the storage.</returns>
        List<Book> GetAllbooks();

    }
}