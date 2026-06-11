namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int BookID { get; set; }

        public string Title { get; set; } = string.Empty;

        public string ISBN { get; set; } = string.Empty;

        public int PublishedYear { get; set; }

        public int Quantity { get; set; }

        public int CategoryID { get; set; }

        public int AuthorID { get; set; }
    }
}