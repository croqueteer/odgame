using System;
using SuperSocket.SocketBase;


namespace odgame
{
    public class DistributedRoomRegistry<T, R> : IRoomRegistry<T, R> where T:AppSession<T, CommandRequestInfo>, IAppSession, new() where R:IRoom<T>
	{
		public IRoom<T> FindRoom(string roomId)
		{
			return null;
		}

		public IRoom<T> FindOrCreateRoom(string roomId)
		{
			return null;
		}
	}
}
