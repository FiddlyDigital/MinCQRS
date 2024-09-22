namespace YouTooCanKanban.API.Client.Models
{
    public class GetListParams
    {
        public required int Page { get; set; }
        public required int PageSize { get; set; }
        public string? SortBy { get; set; }
        public string? SortDir { get; set; }
        public string? Filter { get; set; }
    }
}
