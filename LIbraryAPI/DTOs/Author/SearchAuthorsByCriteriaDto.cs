namespace LIbraryAPI.DTOs.Author
{
    public class SearchAuthorsByCriteriaDto
    {
        public int? AUTHOR_ID { get; set; }

        public string? AUTHOR_NAME { get; set; }

        public string? AUTHOR_SURNAME { get; set; }

        public int? AGE { get; set; }
    }
}
