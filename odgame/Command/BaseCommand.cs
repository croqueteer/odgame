using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using ProtoBuf;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;

namespace odgame
{
	public class BaseCommand : ICommand<BaseSession, CommandRequestInfo>
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger
			(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		public string Name
		{
			get { return "SRC"; }
		}

		public void ExecuteCommand(BaseSession session, CommandRequestInfo requestInfo)
		{
			MemoryStream stream = new MemoryStream(requestInfo.Body);
			try
			{
				game.GameRequest req = Serializer.Deserialize<game.GameRequest>(stream);
				log.DebugFormat("Execute message {0},{1},{2},{3}", req.messageType, session.SessionID, session.LocalEndPoint.ToString(), session.RemoteEndPoint.ToString());
				ICommandFactory factory = InjectorHelper.Get<ICommandFactory>();
				IGameCommand command = factory.Create(req);
				command.Execute(session.GetGameSession());
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception:" + e.Message);
			}
		}

	}
}
