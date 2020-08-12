# Switchboard

Switchboard is the next evolutionary step from SmokeSignal. Switchboard can manage multiple concurrent connections asynchronously, rather than SmokeSignal's more basic `Connect, Receive, Reply, Disconnect` single connection at a time process. 

![Switchboard Ecosystem](https://raw.githubusercontent.com/igtampe/SwitchboardServer/master/Images/Switchboard%20Ecosystem.png)<br>
_The Switchboard Ecosystem with the server on the right, and the client on the left_

## On the Server

### GUI
No more console based nonsense. Switchboard shows you all active connections, and while the server is offline, allows you to easily modify server and extension settings.

### Expandable
Switchboard builds on the experience we acquired when creating SmokeSignal and SecuQuor. We allow programmers to build Switchboard Extensions, each with their own viewable and configurable settings. Switchboard's Server is only a class library which contains everything you need to make a server (forms, classes, etc.). All you need to do is create the extensions, and make a small program to start the server with them linked. <br><br>

Also, I'm _pretty_ sure that with the right wrapper, you could probably automatically load extensions from other dlls in a specified folder on launch. This is a bit beyond what I know right now, but I would be interested in trying it later.<br><br>

See the Example Server for a small demo.

### Multi-User Authentication
Switchboard, unlike SmokeSignal, is built from the ground up to include authentication. Instead of authenticating on each command, like SmokeSignal, users simply "log in", and their session is tied to their connection. Not only this, but now every command is an authenticated command, though the extension can choose to ignore the user.

## On the Client
Not mentioned in the help is the option to read the stream if there is any data by using the command `READ`.
Also, if the server connection ever hangs, you can break out of a read attempt by using the <kbd>Esc</kbd> key.

### Still simple
Switchboard aims to provide an improved connection response-time, and expanded capabilities for sending/receiving data, with the same level of simplicity as SmokeSignal.
While we can no longer offer the `ServerCommand()` function, the process of connecting to the server is still relatively simple. It is as folows:

1. Create a SwitchboardClient object with IP and Port
2. Connect to the server using `Connect()`.
3. Use `SendReceive(Data)` as a ServerCommand Equivalent.

Once you're done, simply close the connection using `close()`

### Flexible
Along with using `SendReceive()`, Switchboard also lets you only `send()` or `receive()` data using the appropriate functions. This opens the door to other possibilities, since using this, a client can act as a pseudo-server, allowing true two way communication.

### Easier to Use
Switchboard's Client is now its own separate class library, so it's more easily importable to your new project.

### Faster
Compared to SmokeSignal, a Switchboard Client should be a lot faster when dealing with repeated requests. Instead of having to open a connection for each request, a single connection can be maintained for the duration of the burst of requests. 
