using System;
namespace odgame
{
	public interface IRoomRegistry
	{
		IRoom FindRoom(string roomId);

		IRoom FindOrCreateRoom(string roomId);
	}
}
