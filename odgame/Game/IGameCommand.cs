using System;
using SuperSocket.SocketBase;


namespace odgame
{
    public interface IGameCommand<T> where T:AppSession<T, CommandRequestInfo>, IAppSession, new()
	{
		string Id();

		void Init(game.GameRequest req);

		void Execute(T session);
	}
}
