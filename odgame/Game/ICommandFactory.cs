using System;
namespace odgame
{
	public interface ICommandFactory
	{
		IGameCommand Create(game.GameRequest req);
	}
}
