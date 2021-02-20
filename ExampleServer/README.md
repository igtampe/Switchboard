![ColloquorBanner](https://raw.githubusercontent.com/igtampe/ColloquorClient/master/Resources/Colloquor%20(Banner).png)
*The example server for Switchboard is Colloquor's server. Small improvements where made from the original repo.*


Colloquor is a basic chat application, which allows users to connect to "channels" and communicate with each other. I wrote it mostly as an example of what Switchboard can do. Colloquor lives entirely within the cool little Colloquor extension for Switchboard. This server includes it. 

![Colloquor4Picture](https://raw.githubusercontent.com/igtampe/ColloquorClient/master/Resources/Colloquor4.png)
See the client, and the histroy of Colloquor over here: https://github.com/igtampe/ColloquorClient

## How it works
This version of Colloquor actually works surprisingly similarly to the original. Channels only keep the latest message, and send it upon request to clients. It's up to the clients to determine if they've previously received the message to display it.

Colloquor uses Switchboard's Authentication and user system, in order to keep track the channel users are sending messages or requesting messages from.

The extension has the following commands:
```
(All Commands have the prefix "CQUOR ")
JOIN (Channel) (Pass) : Joins the specified channel. Return's channel's welcome message
LISTCHANNELS          : Shows a list of all channels as CHANNEL_NAME:HAS_PASSWORD,CHANNEL_NAME:HAS_PASSWORD....
SEND (Message)        : Sends the message to the channel the user is in.
REQUEST               : Retrieves the latest message on the channel the user is in.
LEAVE                 : Leaves the channel the user is in.
PING                  : Ping the Colloquor Extension to make sure it exists and the user has access. Replies PONG if successfull.
```

The client streamlines this with the class ColloquorClient, which extends SwitchboardClient. You can just grab the file and put it onto other applications, just like the Colloquor Extension here. 
