using System;
namespace odgame
{
	public class RoomSessionFactory : ISessionFactory
	{
		public IGameSession Create(IClientHandle handle)
		{
			return new RoomSession(handle);
		}
	}
}
