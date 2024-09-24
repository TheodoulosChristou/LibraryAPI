namespace LIbraryAPI.DTOs.Order
{
    public class SearchOrderResultDto
    {
        public int? ORDER_ID { get; set; }

        public int? BOOK_ID { get; set; }

        public string? BOOK_NAME { get; set; }

        public int? USER_ID { get; set; }

        public string? USER_FIRSTNAME { get; set; }

        public string? USER_LASTNAME { get; set; }

        public string? AUTHOR_NAME { get; set; }
    }
}
