using ChatApp.Domain.Models.Base;

namespace ChatApp.Domain.Models
{
    public class ChatMessage: BaseEntity
    {
        public Guid Id { get; set; }
        public string Sender { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public ChatRoom ChatRoom { get; set; }
        public Guid ChatRoomId { get; set; }
    }
}
