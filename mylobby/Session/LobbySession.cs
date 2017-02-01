using System;
using System.IO;
using ProtoBuf;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using odgame;

namespace mylobby
{
	public class LobbySession : IGameSession
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger
			(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		IClientHandle client;

		public LobbySession(IClientHandle client)
		{
			this.client = client;
		}

		public void OnSessionStarted()
		{
			log.Debug("New lobby session started");
		}

		public void HandleException(Exception e)
		{
		}

		public void OnSessionClosed()
		{
			log.Debug("lobby session closed");
		}

		public void Send(game.GameReply reply)
		{
			this.client.Send(reply);
		}
	}
}
