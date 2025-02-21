namespace AztroWebApplication.Models
{
    public class ErrorResponse
    {
        public string Title { get; set; } = string.Empty;
        public string StatusCode { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}