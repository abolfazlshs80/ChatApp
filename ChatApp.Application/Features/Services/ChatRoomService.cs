using ChatApp.Application.Features.Interfaces;
using ChatApp.Domain.Models;
using Project.Application.Contracts.Persistence;

namespace ChatApp.Application.Features.Services
{
    public class ChatRoomService(IChatRoomRepository _chatRoomRepository, IUnitOfWork unitOfWork) : IChatRoomService
    {
        public async Task<Guid> CreateChatRoom(string ConnectionId)
        {
            var existChatRoom = _chatRoomRepository.FindFirstOrDefault(p => p.ConnectionId == ConnectionId);
            if (existChatRoom != null)
            {
                return await Task.FromResult(existChatRoom.Id);
            }

            ChatRoom chatRoom = new ChatRoom()
            {
                ConnectionId = ConnectionId,
                Id = Guid.NewGuid(),
            };
            await _chatRoomRepository.Add(chatRoom);
            await unitOfWork.Save();
            return await Task.FromResult(chatRoom.Id);
        }

        public async Task<Guid> GetChatRoomForConnection(string CoonectionId)
        {
            var chatRoom = _chatRoomRepository.FindFirstOrDefault(p => p.ConnectionId == CoonectionId);
            return await Task.FromResult(chatRoom.Id);
        }
        //public async Task<List<Guid>> GetAllrooms()
        //{
        //    var rooms = _context.ChatRooms
        //        .Include(p => p.ChatMessages)
        //        .Where(p => p.ChatMessages.Any())
        //        .Select(p =>
        //            p.Id).ToList();
        //    return await Task.FromResult(rooms);
        //}
    }


}
