using Microsoft.Data.SqlClient;
using LibraryManagementSystem.Models;
using System.Data;

namespace LibraryManagementSystem.Repository
{
    public class BookRepository
    {
        // Add Book
        public void AddBook(Book book)
        {
            using SqlConnection connection = DbConnection.GetConnection();

            string query = @"INSERT INTO Books
                            (Title, ISBN, PublishedYear, Quantity, CategoryID, AuthorID)
                            VALUES
                            (@Title, @ISBN, @PublishedYear, @Quantity, @CategoryID, @AuthorID)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Title", book.Title);
            command.Parameters.AddWithValue("@ISBN", book.ISBN);
            command.Parameters.AddWithValue("@PublishedYear", book.PublishedYear);
            command.Parameters.AddWithValue("@Quantity", book.Quantity);
            command.Parameters.AddWithValue("@CategoryID", book.CategoryID);
            command.Parameters.AddWithValue("@AuthorID", book.AuthorID);

            connection.Open();
            command.ExecuteNonQuery();
        }

        // View All Books
        public List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();

            using SqlConnection connection = DbConnection.GetConnection();

            string query = "SELECT * FROM Books";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                books.Add(new Book
                {
                    BookID = Convert.ToInt32(reader["BookID"]),
                    Title = reader["Title"].ToString()!,
                    ISBN = reader["ISBN"].ToString()!,
                    PublishedYear = Convert.ToInt32(reader["PublishedYear"]),
                    Quantity = Convert.ToInt32(reader["Quantity"]),
                    CategoryID = Convert.ToInt32(reader["CategoryID"]),
                    AuthorID = Convert.ToInt32(reader["AuthorID"])
                });
            }

            return books;
        }

        // Get Book By ID
        /*public Book? GetBookById(int bookId)
        {
            using SqlConnection connection = DbConnection.GetConnection();

            string query = "SELECT * FROM Books WHERE BookID = @BookID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BookID", bookId);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new Book
                {
                    BookID = Convert.ToInt32(reader["BookID"]),
                    Title = reader["Title"].ToString()!,
                    ISBN = reader["ISBN"].ToString()!,
                    PublishedYear = Convert.ToInt32(reader["PublishedYear"]),
                    Quantity = Convert.ToInt32(reader["Quantity"]),
                    CategoryID = Convert.ToInt32(reader["CategoryID"]),
                    AuthorID = Convert.ToInt32(reader["AuthorID"])
                };
            }

            return null;
        }*/

        // Update Book
        public void UpdateBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            using SqlConnection connection = DbConnection.GetConnection();

            string query = @"
                UPDATE Books
                SET Title = @Title,
                ISBN = @ISBN,
                PublishedYear = @PublishedYear,
                Quantity = @Quantity,
                CategoryID = @CategoryID,
                AuthorID = @AuthorID
                WHERE BookID = @BookID";

                using SqlCommand command = new SqlCommand(query, connection);

                // Parameters (safe & strongly typed)
                command.Parameters.Add("@BookID", SqlDbType.Int).Value = book.BookID;
                command.Parameters.Add("@Title", SqlDbType.NVarChar, 200).Value = book.Title;
                command.Parameters.Add("@ISBN", SqlDbType.NVarChar, 50).Value = book.ISBN;
                command.Parameters.Add("@PublishedYear", SqlDbType.Int).Value = book.PublishedYear;
                command.Parameters.Add("@Quantity", SqlDbType.Int).Value = book.Quantity;
                command.Parameters.Add("@CategoryID", SqlDbType.Int).Value = book.CategoryID;
                command.Parameters.Add("@AuthorID", SqlDbType.Int).Value = book.AuthorID;

                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected <= 0)
                {
                    throw new Exception("No book found with the given BookID.");
                }
        }

        // Delete Book
        public void DeleteBook(int bookId)
        {
            using SqlConnection connection = DbConnection.GetConnection();

            string query = "DELETE FROM Books WHERE BookID=@BookID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BookID", bookId);

            connection.Open();

            command.ExecuteNonQuery();
        }

        // Search By Title
        /*public List<Book> SearchBookByTitle(string title)
        {
            List<Book> books = new List<Book>();

            using SqlConnection connection = DbConnection.GetConnection();

            string query = @"SELECT * FROM Books
                             WHERE Title LIKE '%' + @Title + '%'";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Title", title);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                books.Add(new Book
                {
                    BookID = Convert.ToInt32(reader["BookID"]),
                    Title = reader["Title"].ToString()!,
                    ISBN = reader["ISBN"].ToString()!,
                    PublishedYear = Convert.ToInt32(reader["PublishedYear"]),
                    Quantity = Convert.ToInt32(reader["Quantity"]),
                    CategoryID = Convert.ToInt32(reader["CategoryID"]),
                    AuthorID = Convert.ToInt32(reader["AuthorID"])
                });
            }

            return books;
        }

        // Search By Category
        public List<Book> SearchBookByCategory(int categoryId)
        {
            List<Book> books = new List<Book>();

            using SqlConnection connection = DbConnection.GetConnection();

            string query = "SELECT * FROM Books WHERE CategoryID=@CategoryID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CategoryID", categoryId);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                books.Add(new Book
                {
                    BookID = Convert.ToInt32(reader["BookID"]),
                    Title = reader["Title"].ToString()!,
                    ISBN = reader["ISBN"].ToString()!,
                    PublishedYear = Convert.ToInt32(reader["PublishedYear"]),
                    Quantity = Convert.ToInt32(reader["Quantity"]),
                    CategoryID = Convert.ToInt32(reader["CategoryID"]),
                    AuthorID = Convert.ToInt32(reader["AuthorID"])
                });
            }

            return books;
        }

        // Available Books
        public List<Book> GetAvailableBooks()
        {
            List<Book> books = new List<Book>();

            using SqlConnection connection = DbConnection.GetConnection();

            string query = "SELECT * FROM Books WHERE Quantity > 0";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                books.Add(new Book
                {
                    BookID = Convert.ToInt32(reader["BookID"]),
                    Title = reader["Title"].ToString()!,
                    ISBN = reader["ISBN"].ToString()!,
                    PublishedYear = Convert.ToInt32(reader["PublishedYear"]),
                    Quantity = Convert.ToInt32(reader["Quantity"]),
                    CategoryID = Convert.ToInt32(reader["CategoryID"]),
                    AuthorID = Convert.ToInt32(reader["AuthorID"])
                });
            }

            return books;
        }*/
    }
}