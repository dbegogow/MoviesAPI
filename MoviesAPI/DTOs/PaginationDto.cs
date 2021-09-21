namespace MoviesAPI.DTOs
{
    public class PaginationDto
    {
        private int recordsPerPage = 10;
        private readonly int maxRecordsPerPage = 50;

        public int Page { get; set; } = 1;

        public int RecordsPerPage
        {
            get => recordsPerPage;
            set => recordsPerPage = (value > this.maxRecordsPerPage) ? maxRecordsPerPage : value;
        }
    }
}
