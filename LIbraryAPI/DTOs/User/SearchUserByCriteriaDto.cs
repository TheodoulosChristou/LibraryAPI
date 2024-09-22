namespace LIbraryAPI.DTOs.User
{
    public class SearchUserByCriteriaDto
    {
        public int? USER_ID { get; set; }

        public string? FIRST_NAME { get; set; }

        public string? LAST_NAME { get; set; }

        public string? ADDRESS { get; set; }

        public string? PHONE_NUMBER { get; set; }

        public string? EMAIL { get; set; }
    }
}
