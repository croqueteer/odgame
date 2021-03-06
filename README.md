# odgame
PoC game skeleton for future projects

# pre-requisites
* abstract away server infrastructure code, to have gamelogic separated, isolated and modular
* support udp & tcp
* support running multiple servers in one container by configuration (think running serviceroom and battleserver in one visual-studio process)

# terminology
## service
ye'olde server providing session and commands to carry out whatever task (think serviceroom or spectator)
## room
server providing an environment for a number of sessions to be connected and interact with eachother

# projects
* odgame: DLL containing server infrastructure code de-coupled from gamelogic
* mylobby: DLL containing game logic for a lobby service
* myserver: Program booting up server defined in configuration (app.config is the interesting part here)

# How does it work
To implement a service, the gamelogic needs to implement a few interfaces from the odgame DLL:
* ICommandFactory
* IGameCommand
* ISessionFactory
* ISession
plus extend the BaseServer class.
To run a service, in the myserver app.config, we need to define the class in the gamelogic implementing BaseServer
