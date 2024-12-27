namespace EncryptedChat.Data.Entities
{
    public class Group
    {
        public Guid GroupId { get; set; }
        public Guid OwnerId { get; set; }
        public string? GroupName { get; set; }
        public ICollection<User>? Participants { get; set; }
    }
}
