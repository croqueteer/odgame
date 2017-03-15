using System;
using odgame;

namespace mylobby
{
	public class LoginCommand : IGameCommand<LobbySession>
	{
		public string Id()
		{
			return "Login";
		}

		public void Init(game.GameRequest req)
		{ 
		}

		public void Execute(LobbySession session)
		{
			game.GameReply reply = new game.GameReply();
            reply.messageType = Id();
            session.SendEvent(reply);
		}
	}
}
