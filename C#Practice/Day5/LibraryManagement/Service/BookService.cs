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

    }
}