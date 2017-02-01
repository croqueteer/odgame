using System;
using odgame;

namespace mylobby
{
	public class SessionFactory : ISessionFactory
	{
		public IGameSession Create(IClientHandle client)
		{
			return new LobbySession(client);
		}
	}
}
