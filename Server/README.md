# SwitchboardServer

Switchboard is the next evolutionary step from SmokeSignal. Unlike it, Switchboard can manage multiple concurrent connections at a time, all maintained active, rather than SmokeSignal's more basic `Connect, Receive, Reply, Disconnect` process. 

See the client here: https://github.com/igtampe/SwitchboardClient

## GUI
No more console based nonsense. Switchboard shows you all active connections, and while the server is offline, allows you to easily modify server and extension settings.

## Expandable
Switchboard builds on the experience we aquiered when creating SmokeSignal and SecuQuor, allowing programmers to build Switchboard Extensions, each with their own viewable and configurable settings.

## Multi-User Authentication
Switchboard, unlike SmokeSignal, is built from the ground up to include authentication. Instead of authenticating on each command, like SmokeSignal, users simply "log in", and their session is tied to their connection. Not only this, but now every command is an authenticated command, though the extension can choose to ignore the user.
