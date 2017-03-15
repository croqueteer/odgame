using System;
using SuperSocket.SocketBase;


namespace odgame
{
    public interface IRoom<T> where T:AppSession<T, CommandRequestInfo>, IAppSession, new()
	{
        void OnClose();

        void OnUserJoined(T peer);

        void OnUserLeft(T peer);

        void OnMessage(T peer, IGameCommand<T> command);
	}
}
