using ChatApp.Domain.Models;
using ChatApp.Infrastructure.Context;
using ChatApp.Infrastructure.Repositories;
using Project.Application.Contracts.Persistence;

namespace Project.Persistence.Repositories;

public class ChatRoomRepository : GenericRepository<ChatRoom>, IChatRoomRepository
{
    public ChatRoomRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
