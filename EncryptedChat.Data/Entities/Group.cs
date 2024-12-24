namespace EncryptedChat.Data.Entities
{
    public class Group
    {
        public int GroupId { get; set; }
        public Guid OwnerId { get; set; }
        public string? GroupName { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
