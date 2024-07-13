namespace YouTooCanKanban.Domain.Exceptions
{
    public sealed class NotFoundException : Exception
    {
        public NotFoundException(string message): base(message)
        {
        }

        public NotFoundException(string key, string objectName)
            : base($"The {objectName} was not found, Key: {key}")
        {
        }

        public NotFoundException(string key, string objectName, Exception innerException)
            : base($"The {objectName} was not found, Key: {key}", innerException)
        {
        }
    }
}
