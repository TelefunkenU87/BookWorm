namespace BookWorm.DTO
{
    public class BooksDTO
    {
        public int Id { get; set; }
        public int? AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? SeriesId { get; set; }
        public string SeriesName { get; set; }
        public string Title { get; set; }
        public byte[] CoverArt { get; set; }
        public string Description { get; set; }
        public int? Rating { get; set; }
    }
}
