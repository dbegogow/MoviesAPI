namespace MoviesAPI.DTOs
{
    public class PaginationDto
    {
        private int _recordsPerPage = 10;
        private readonly int maxRecordsPerPage = 50;

        public int Page { get; set; } = 1;

        public int RecordsPerPage
        {
            get => _recordsPerPage;
            set => _recordsPerPage = (value > this.maxRecordsPerPage) ? maxRecordsPerPage : value;
        }
    }
}
