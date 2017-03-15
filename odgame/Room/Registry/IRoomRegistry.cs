using System;
using SuperSocket.SocketBase;


namespace odgame
{
    public interface IRoomRegistry<T, R> where T:AppSession<T, CommandRequestInfo>, IAppSession, new() where R:IRoom<T>
	{
		IRoom<T> FindRoom(string roomId);

		IRoom<T> FindOrCreateRoom(string roomId);
	}
}
