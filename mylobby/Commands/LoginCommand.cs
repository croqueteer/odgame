using System;
using odgame;

namespace mylobby
{
	public class LoginCommand : IGameCommand
	{
		private const string ID = "Login";

		public string Id()
		{
			return ID;
		}

		public void Init(game.GameRequest req)
		{ 
		}

		public void Execute(IGameSession session)
		{
			game.GameReply reply = new game.GameReply();
			reply.messageType = ID;
			session.Send(reply);
		}
	}
}
