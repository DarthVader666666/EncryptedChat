namespace EncryptedChat.Data.Entities
{
    public class Chat
    {
        public Guid UserOneId { get; set; }
        public Guid UserTwoId { get; set; }
        public ICollection<User>? Participants { get; set; }
    }
}
