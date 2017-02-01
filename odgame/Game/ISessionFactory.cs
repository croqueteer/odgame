using System;
namespace odgame
{
	public interface ISessionFactory
	{
		IGameSession Create(IClientHandle client);
	}
}
