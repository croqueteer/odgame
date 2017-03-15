using System;
using System.IO;
using ProtoBuf;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using odgame;

namespace mylobby
{
    public class LobbySession : BaseSession<LobbySession>
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger
			(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected override void OnSessionStarted()
		{
            base.OnSessionStarted();
			log.Debug("New lobby session started");
		}

        protected override void HandleException(Exception e)
		{
		}

        protected override void OnSessionClosed()
		{
            base.OnSessionStarted();
			log.Debug("lobby session closed");
		}

        public void SendEvent(game.GameReply reply)
		{
            base.Send(reply);
		}
	}
}
