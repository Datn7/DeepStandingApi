namespace DeepStandingApi.Models
{
    public class Book : BaseEntity
    {
        public string Title { get; set; } = "";
        public DateTime PublishedDate { get; set; }

        // step 2
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
