using System;
namespace odgame
{
	public class RoomSession : IGameSession
	{
		IRoom room { get; set;}
		IClientHandle client;

		public RoomSession(IClientHandle handle)
		{
			this.client = handle;
		}

		public void OnSessionStarted()
		{ }
		public void HandleException(Exception e)
		{ }
		public void OnSessionClosed()
		{ }
		public void Send(game.GameReply reply)
		{
			this.client.Send(reply);
		}
	}
}
