namespace EncryptedChat.Data.Entities
{
    public class Chat
    {
        public Guid ChatId { get; set; }
        public Guid UserOneId { get; set; }
        public Guid UserTwoIdId { get; set; }
    }
}
