# Switchboard

Switchboard is the next evolutionary step from SmokeSignal. Unlike it, Switchboard can manage multiple concurrent connections at a time, all maintained active, rather than SmokeSignal's more basic `Connect, Receive, Reply, Disconnect` process. 

![Switchboard Ecosystem](https://raw.githubusercontent.com/igtampe/SwitchboardServer/master/Images/Switchboard%20Ecosystem.png)<br>
_The Switchboard Ecosystem with the server on the right, and the client on the left_

## On the Server

### GUI
No more console based nonsense. Switchboard shows you all active connections, and while the server is offline, allows you to easily modify server and extension settings.

### Expandable
Switchboard builds on the experience we aquiered when creating SmokeSignal and SecuQuor, allowing programmers to build Switchboard Extensions, each with their own viewable and configurable settings.

### Multi-User Authentication
Switchboard, unlike SmokeSignal, is built from the ground up to include authentication. Instead of authenticating on each command, like SmokeSignal, users simply "log in", and their session is tied to their connection. Not only this, but now every command is an authenticated command, though the extension can choose to ignore the user.

## On the Client
Not mentioned in the help is the option to read the stream if there is any data by using the command `READ`.
Also, if the server connection ever hangs, you can break out of a read attempt by using the <kbd>Esc</kbd> key.

### Still simple
Switchboard aims to provide an improved connection response-time, and expanded capabilities for sending/receiving data, with the same level of simplicity to SmokeSignal.
While we can no longer offer the `ServerCommand()` function, the process of connecting to the server is still relatively simple. It is as folows:

1. Create a SwitchboardClient object with IP and Port
2. Connect to the server using `Connect()`.
3. Use `SendReceive(Data)` as a ServerCommand Equivalent.

Once you're done, simply close the connection using `close()`

### Flexible
Along with usign `SendReceive()`, Switchboard also lets you only `send()` or `receive()` data using the appropriate functions. This opens the door to other possibilities, since using this, a client can act as a pseudo-server, allowing true two way communication.

### Faster
Compared to SmokeSignal, a Switchboard Client should be a lot faster when dealing with repeated requests. Instead of having to open a connection for each request, a single connection can be maintained for the duration of the burst of requests. 
