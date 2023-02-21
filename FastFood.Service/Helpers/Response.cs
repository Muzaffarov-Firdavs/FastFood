namespace FastFood.Service.Helpers
{
    public class Response<TResponse>
    {
        public int StatusCode { get; set; } = 404;
        public string Message { get; set; } = "Not Found";
        public TResponse Result { get; set; }
    }
}
