using System;
namespace odgame
{
	public interface IGameSession
	{
		void OnSessionStarted();
		void HandleException(Exception e);
		void OnSessionClosed();
		void Send(game.GameReply reply);
	}
}
