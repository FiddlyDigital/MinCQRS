
namespace YouTooCanKanban.DAL.Models
{
    public class FilterParameters
    {
        public string? FilterBy { get; set; }
        public string? FilterOperator { get; set; }
        public string? FilterValue { get; set; }

        public FilterParameters(string? filterStatement)
        {
            if (!string.IsNullOrEmpty(filterStatement))
            {
                var filterElements = filterStatement.Split(" ");
                var filterBy = filterElements.FirstOrDefault();
                var @operator = filterElements.ElementAtOrDefault(1);
                var value = filterElements.LastOrDefault();

                if (filterElements.Length == 3 && !string.IsNullOrEmpty(filterBy) && !string.IsNullOrEmpty(value))
                {
                    FilterBy = filterBy;
                    FilterOperator = @operator;
                    FilterValue = value;
                }
            }
        }

        public static FilterParameters Create(string? filterStatement)
        {
            return new FilterParameters(filterStatement);
        }
    }
}
