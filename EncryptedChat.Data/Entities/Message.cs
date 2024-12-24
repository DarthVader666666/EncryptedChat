namespace EncryptedChat.Data.Entities
{
    public class Message
    {
        public Guid MessageId { get; set; }
        public Guid UserId { get; set; }
        public DateTime TimeSent { get; set; }
        public string? Content { get; set; }
    }
}
