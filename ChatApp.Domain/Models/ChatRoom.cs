using ChatApp.Domain.Models.Base;

namespace ChatApp.Domain.Models
{
    public class ChatRoom : BaseEntity
    {
        public Guid Id { get; set; }
        public string ConnectionId { get; set; }
        public ICollection<ChatMessage> ChatMessages { get; set; }
    }
}
