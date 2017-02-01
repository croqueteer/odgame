using System;
namespace odgame
{
	public interface IGameCommand
	{
		string Id();

		void Init(game.GameRequest req);

		void Execute(IGameSession session);
	}
}
