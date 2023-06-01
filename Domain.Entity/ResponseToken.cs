namespace Domain.Entity

{
    public class ResponseToken<T>
    {
        public string MessageResponse { get; set; }
        public string Token { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }
}
