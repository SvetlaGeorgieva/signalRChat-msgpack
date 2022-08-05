# signalRChat-msgpack
SignalR Chat app with MessagePack serialization

## How to run project
- Start project
  - In Visual Studio -> Press F5 or click on the run button. 
  - In Visual studion code 
    - Open terminal in project's root folder run command
    - Run command `npm install`
    - Run command `dotnet watch run --project SignalRChat_msgpack.csproj`
- As a result, a new browser tab will open with address: https://localhost:7276/
- Open one (or more) browser tabs and paste the same address: https://localhost:7276/

These tabs are like a chat instances, which can send messages, and each will receive the messages from all other 'chat instances'.

## How to see the binary data the browser
- Open developer tools (F12)
- Open Network tab
- Refresh the page https://localhost:7276/
- Find the WebSocket tunnel with Name starting with 'chatHub?id='
- Select Messages tab
- Now in the app -> fill in the User and Message data -> click 'Send Message'
- New messages will appear in the WebSocket tunnel. Upon inspection you can see that the data is in binary format. The first message in the tunnel will state: `{"protocol":"messagepack","version":1}`
![image](https://user-images.githubusercontent.com/6852385/183067961-1dbe9a94-8dc8-47b7-b5cc-34784020c15b.png)


## How to capture server-client communication with Fiddler Everywhere
- Open Fiddler Everywhere
- Click on 'Open Browser'
- In the new opened browser instance, paste the address: https://localhost:7276/
- A WebSocket tunnel session will appear in the Live Traffic grid. (WebSocket tunnels have Status Code = 101. You can use this to filter the Grid)
- All messages from/to this chat instance will be visible in the WebSocket tunnel -> Inspectors -> Messages
- The Message tab will show the serialized with MessagePack object that was sent from the server.
![image](https://user-images.githubusercontent.com/6852385/183068385-b5e5c9b1-0972-41ef-8424-0f868177188a.png)

