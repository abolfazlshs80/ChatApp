namespace ChatApp.Application.Features.Interfaces
{
    public interface IChatRoomService
    {
        Task<Guid> CreateChatRoom(string ConnectionId);
        Task<Guid> GetChatRoomForConnection(string CoonectionId);
    }
}
