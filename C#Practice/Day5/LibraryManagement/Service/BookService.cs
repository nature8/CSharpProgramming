using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repository;

namespace LibraryManagementSystem.Services
{
    public class BookService
    {
        private readonly BookRepository _bookRepository;

        public BookService()
        {
            _bookRepository = new BookRepository();
        }

        // Add Book
        public void AddBook(Book book)
        {
            _bookRepository.AddBook(book);

            Console.WriteLine("Book Added Successfully.");
        }

        // View All Books
        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

        // Get Book By Id
        /*public Book? GetBookById(int bookId)
        {
            if (bookId <= 0)
                throw new Exception("Invalid Book ID.");

            return _bookRepository.GetBookById(bookId);
        }*/

        // Update Book
        public void UpdateBook(Book book)
        {
            if (book.BookID <= 0)
                throw new Exception("Invalid Book ID.");

            _bookRepository.UpdateBook(book);

            Console.WriteLine("Book Updated Successfully.");
        }

        // Delete Book
       public void DeleteBook(int bookId)
        {
            if (bookId <= 0)
                throw new Exception("Invalid Book ID.");

            _bookRepository.DeleteBook(bookId);

            Console.WriteLine("Book Deleted Successfully.");
        }

        // Search Book By Title
        /*public List<Book> SearchBookByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new Exception("Book title cannot be empty.");

            return _bookRepository.SearchBookByTitle(title);
        }

        // Search By Category
        public List<Book> SearchBookByCategory(int categoryId)
        {
            if (categoryId <= 0)
                throw new Exception("Invalid Category ID.");

            return _bookRepository.SearchBookByCategory(categoryId);
        }

        // Available Books
        public List<Book> GetAvailableBooks()
        {
            return _bookRepository.GetAvailableBooks();
        }

        // Validation
        private void ValidateBook(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Title))
                throw new Exception("Book title cannot be empty.");

            if (string.IsNullOrWhiteSpace(book.ISBN))
                throw new Exception("ISBN cannot be empty.");

            if (book.Quantity < 0)
                throw new Exception("Quantity cannot be negative.");

            if (book.PublishedYear < 1000 ||
                book.PublishedYear > DateTime.Now.Year)
                throw new Exception("Invalid Published Year.");

            if (book.AuthorID <= 0)
                throw new Exception("Invalid Author ID.");

            if (book.CategoryID <= 0)
                throw new Exception("Invalid Category ID.");
        }*/
    }
}