using System;
using System.Collections.Concurrent;
using SuperSocket.SocketBase;

namespace odgame
{
    public class LocalRoomRegistry<T, R> : IRoomRegistry<T, R> where T:AppSession<T, CommandRequestInfo>, IAppSession, new() where R:IRoom<T>, new()
	{
		ConcurrentDictionary<string, IRoom<T>> rooms = new ConcurrentDictionary<string, IRoom<T>>();

		public IRoom<T> FindRoom(string roomId)
		{
			IRoom<T> room;
			rooms.TryGetValue(roomId, out room);
			return room;
		}

		public IRoom<T> FindOrCreateRoom(string roomId)
		{
            IRoom<T> room = rooms.GetOrAdd(roomId, new R());
			return room;
		}




	}
}
