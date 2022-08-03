using Microsoft.AspNetCore.SignalR;

namespace SignalRChat_msgpack.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            //await Clients.All.SendAsync("ReceiveMessage", user, message);

            string messageSerialized = MessagePack.MessagePackSerializer.SerializeToJson(new MessageFromUser(message, user));
            await Clients.All.SendAsync("ReceiveSerializedMessage", messageSerialized);

        }
    }

    [MessagePack.MessagePackObject]
    public class MessageFromUser
    {
        public MessageFromUser(string message, string user)
        {
            this.Message = message;
            this.User = user;
            this.Verb = " also says: ";
        }

        [MessagePack.Key("user")]
        public string User { get; set; }
        [MessagePack.Key("verb")]
        public string Verb { get; set; }
        [MessagePack.Key("message")]
        public string Message { get; set; }
    }
}