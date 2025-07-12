using ChatApp.Application.Features.Interfaces;
using ChatApp.Application.Models.ChatMessage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;


namespace SignalR_WebApplication.Hubs
{
    public class SiteChatHub(IChatRoomService _chatRoomService,IChatMessageService _messageService) : Hub
    {
        public async Task ShowMessage(string sender,string text)
        {

            await Clients.Caller.SendAsync("ShowMessage", sender, text);
        }

        public override async Task OnConnectedAsync()
        {
            //if (Context.User.Identity.IsAuthenticated)
            //{
            //    await base.OnConnectedAsync();
            //    return;
            //}
            //var roomId = await _chatRoomService.CreateChatRoom(Context.ConnectionId);

            //await Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());
            //await Clients.Caller.
            //    SendAsync("getNewMessage", "پشتیبانی ", "سلام وقت بخیر 👋 . چطور میتونم کمکتون کنم؟", DateTime.Now.ToShortTimeString());

       //    await Clients.Caller.SendAsync("ShowMessage", "abolfazl", "shabani");
            await base.OnConnectedAsync();
        }

        /// <summary>
        /// پیوستن پشتیبان ها به گروه
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        /// 
        [Authorize]
        public async Task JoinRoom(Guid roomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());
        }

        /// <summary>
        /// ترک گروه توسط پشتیبان
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        [Authorize]
        public async Task LeaveRoom(Guid roomId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomId.ToString());
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }



  


    }
}
