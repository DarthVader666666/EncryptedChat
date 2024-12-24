namespace EncryptedChat.Data.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public byte[]? Avatar { get; set; }
        public string? Ip { get; set; }
        public ICollection<User>? Contacts { get; set; }
        public ICollection<Group>? Groups { get; set; }
        public ICollection<Message>? Messages { get; set; }
    }
}
