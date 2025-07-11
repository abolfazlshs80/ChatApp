using ChatApp.Domain.Models;

namespace Project.Application.Contracts.Persistence
{
    public interface IChatMessageRepository : IGenericRepository<ChatMessage>
    {
    }
}
