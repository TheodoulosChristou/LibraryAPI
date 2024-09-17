namespace LIbraryAPI.DTOs.AuthorBook
{
    public class SearchAuthorBookResultDto
    {
        public int? AUTHOR_ID { get; set; }

        public string? AUTHOR_NAME { get; set; }

        public string? AUTHOR_SURNAME { get; set; }

        public int? AGE { get; set; }

        public int? BOOK_ID { get; set; }

        public string? BOOK_NAME { get; set; }

        public DateTime? DATE_PUBLISHED { get; set; }
    }
}
