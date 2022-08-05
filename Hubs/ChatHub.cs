using Microsoft.AspNetCore.SignalR;

namespace SignalRChat_msgpack.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            // To send a string message through MessagePack:
            await Clients.All.SendAsync("ReceiveMessage", user, message);

            // To send object through MessagePack:
            var messageObject = new MessageFromUser(message, user);

            // The binary message
            byte[] binaryBlob = MessagePack.MessagePackSerializer.Serialize(messageObject);
            await Clients.All.SendAsync("ReceiveSerializedObject", "binary", binaryBlob);

            // The binary MessagePack message directly converted to JSON
            string blobToJson = MessagePack.MessagePackSerializer.ConvertToJson(binaryBlob);
            await Clients.All.SendAsync("ReceiveSerializedObject", "binary to JSON", blobToJson);

            /* Other ways to experiment with MessagePackSerializer:

                // The base64 message
                var base64Blob = MessagePack.MessagePackSerializer.Typeless.Serialize(messageObject);
                await Clients.All.SendAsync("ReceiveSerializedObject", "base64", base64Blob);

                // The base64 message deserialized back to an object, then converted to JSON
                var messageDeserialized = MessagePack.MessagePackSerializer.Typeless.Deserialize(base64Blob) as MessageFromUser;
                string messageJson = MessagePack.MessagePackSerializer.SerializeToJson(messageDeserialized);
                await Clients.All.SendAsync("ReceiveSerializedObject", "base64 to JSON", messageJson);
            
            */
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