namespace Domain.Entity

{
    public class ResponseEntity<T>
    {
        public int id { get; set; }
        public int UserId { get; set; }
        public int TipoUsers { get; set; }
        public string? MessageResponse { get; set; }
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
