using System;
using System.Collections.Concurrent;

namespace odgame
{
	public class LocalRoomRegistry : IRoomRegistry
	{
		ConcurrentDictionary<string, IRoom> rooms = new ConcurrentDictionary<string, IRoom>();

		public IRoom FindRoom(string roomId)
		{
			IRoom room;
			rooms.TryGetValue(roomId, out room);
			return room;
		}

		public IRoom FindOrCreateRoom(string roomId)
		{
			IRoom room;
			rooms.TryGetValue(roomId, out room);
			return room;
		}




	}
}
