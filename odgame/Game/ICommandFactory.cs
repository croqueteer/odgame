using System;
using SuperSocket.SocketBase;


namespace odgame
{
    public interface ICommandFactory<T> where T:AppSession<T, CommandRequestInfo>, IAppSession, new()
	{
		IGameCommand<T> Create(game.GameRequest req);
	}
}
