using System;
using System.IO;
using ProtoBuf;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;

namespace odgame
{
	public class BaseSession : AppSession<BaseSession, CommandRequestInfo>, IClientHandle
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
			(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		IGameSession session;

		public BaseSession()
		{
			ISessionFactory factory = InjectorHelper.Get<ISessionFactory>();
			session = factory.Create(this);
		}

		public IGameSession GetGameSession()
		{
			return session;
		}

		protected override void OnSessionStarted()
		{
			log.Debug("New session");
			session.OnSessionStarted();
		}

		protected override void HandleException(Exception e)
		{
			log.ErrorFormat("Application error: {0}", e.Message);
			session.HandleException(e);
		}

		protected override void OnSessionClosed(CloseReason reason)
		{
			log.DebugFormat("session: {0} disconnecting, remove listener and clean up", this.SessionID);
			//add you logics which will be executed after the session is closed
			base.OnSessionClosed(reason);
			session.OnSessionClosed();
		}

		protected void OnSessionClosed()
		{
			log.DebugFormat("session: {0} disconnecting, remove listener and clean up", this.SessionID);
			//add you logics which will be executed after the session is closed
			base.OnSessionClosed(CloseReason.Unknown);
			session.OnSessionClosed();
		}

		public void Send(game.GameReply reply)
		{
			var outputStream = new MemoryStream();
			Serializer.Serialize<game.GameReply>(outputStream, reply);
			byte[] response = PacketProtocol.WrapMessage(outputStream.ToArray());
			base.Send(response, 0, response.Length);
		}
	}
}
