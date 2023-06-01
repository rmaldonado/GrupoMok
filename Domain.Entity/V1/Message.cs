namespace Domain.Entity.V1
{
    public partial class Message
    {
        public int Id { get; set; }
        public string MessageCode { get; set; }
        public string MessageEsp { get; set; }
        public string MessageEng { get; set; }
    }
}
