using ChatApp.Domain.Models;
using ChatApp.Infrastructure.Context;
using ChatApp.Infrastructure.Repositories;
using Project.Application.Contracts.Persistence;
using Project.Domain.Entities;

namespace Project.Persistence.Repositories;

public class ChatMessageRepository : GenericRepository<ChatMessage>, IChatMessageRepository
{
    public ChatMessageRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
