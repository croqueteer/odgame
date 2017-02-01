using System;
namespace odgame
{
	public interface IClientHandle
	{
		void Send(game.GameReply reply);
	}
}
