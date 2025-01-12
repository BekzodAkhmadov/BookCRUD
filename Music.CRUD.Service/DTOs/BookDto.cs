namespace Music.CRUD.Service.DTOs
{
    public class BookDto
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public double Rating { get; set; }
        public int NumberOfCopiesSold { get; set; }
        public int PublishedDate { get; set; }
    }
}
