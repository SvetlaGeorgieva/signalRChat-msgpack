# signalRChat-msgpack
SignalR Chat app with MessagePack serialization

## How to run project
- Start project
  - In Visual Studio -> Press F5 or click on the run button. 
  - In Visual studion code -> In terminal in project's root folder run command `dotnet watch run --project SignalRChat_msgpack.csproj`
- As a result, a new browser tab will open with address: https://localhost:7276/
- Open one (or more) browser tabs and paste the same address: https://localhost:7276/

These tabs are like a chat instances, which can send messages, and each will receive the messages from all other 'chat instances'.

## How to capture server-client communication with Fiddler Everywhere
- Open Fiddler Everywhere
- Click on 'Open Browser'
- In the new opened browser instance, paste the address: https://localhost:7276/
- A WebSocket tunnel session will appear in the Live Traffic grid.
- All messages from/to this chat instance will be visible in the WebSocket tunnel -> Inspectors -> Messages
- The Message tab will show the serialized with MessagePack object that was sent from the server.
