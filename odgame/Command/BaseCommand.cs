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
    public class BaseCommand<T> : ICommand<T, CommandRequestInfo> where T:AppSession<T, CommandRequestInfo>, IAppSession, new()
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger
			(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		public string Name
		{
			get { return "SRC"; }
		}

		public void ExecuteCommand(T session, CommandRequestInfo requestInfo)
		{
			MemoryStream stream = new MemoryStream(requestInfo.Body);
			try
			{
				game.GameRequest req = Serializer.Deserialize<game.GameRequest>(stream);
				log.DebugFormat("Execute message {0},{1},{2},{3}", req.messageType, session.SessionID, session.LocalEndPoint.ToString(), session.RemoteEndPoint.ToString());
				ICommandFactory<T> factory = InjectorHelper.Get<ICommandFactory<T>>();
				IGameCommand<T> command = factory.Create(req);
				command.Execute(session);
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception:" + e.Message);
			}
		}

	}
}
