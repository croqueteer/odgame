using System;
using System.IO;
using ProtoBuf;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;

namespace odgame
{
    public class BaseSession<T> : AppSession<T, CommandRequestInfo> where T:AppSession<T, CommandRequestInfo>, IAppSession, new()
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
			(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		protected override void OnSessionStarted()
		{
			log.Debug("New session");
		}

        protected override void HandleException(Exception e)
		{
			log.ErrorFormat("Application error: {0}", e.Message);
		}

        protected override void OnSessionClosed(CloseReason reason)
		{
			log.DebugFormat("session: {0} disconnecting, remove listener and clean up", this.SessionID);
			//add you logics which will be executed after the session is closed
			base.OnSessionClosed(reason);
		}

        protected virtual void OnSessionClosed()
		{
			log.DebugFormat("session: {0} disconnecting, remove listener and clean up", this.SessionID);
			//add you logics which will be executed after the session is closed
			base.OnSessionClosed(CloseReason.Unknown);
		}

        public virtual void Send(game.GameReply reply)
		{
			var outputStream = new MemoryStream();
			Serializer.Serialize<game.GameReply>(outputStream, reply);
			byte[] response = PacketProtocol.WrapMessage(outputStream.ToArray());
			base.Send(response, 0, response.Length);
		}
	}
}
