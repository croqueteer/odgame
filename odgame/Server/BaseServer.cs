using System;
using System.Collections.Generic;
using System.Linq;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Command;
using Ninject;
using Ninject.Modules;
using Ninject.Extensions.Conventions;

namespace odgame
{
	public class BaseServer : AppServer<BaseSession, CommandRequestInfo>
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger
			(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		private IKernel kernel;
		private NinjectModule module;

		public BaseServer()
            : base (new DefaultReceiveFilterFactory<CommandReceiveFilter, CommandRequestInfo>())
        {
			log.InfoFormat("BASE {0}", AppDomain.CurrentDomain.BaseDirectory.ToString());
		}

		public BaseServer(NinjectModule module)
			: base(new DefaultReceiveFilterFactory<CommandReceiveFilter, CommandRequestInfo>())
		{
			log.InfoFormat("BASE {0}", AppDomain.CurrentDomain.BaseDirectory.ToString());
			this.module = module;
		}
		protected override bool Setup(IRootConfig rootConfig, IServerConfig config)
		{
			if (!base.Setup(rootConfig, config))
				return false;

			if (module != null)
			{
				kernel = new StandardKernel(module);
			} else { 
				kernel = new StandardKernel();//new ServerModule(serverConfig));
			}

			InjectorHelper.SetKernel(kernel);
			return true;
		}

		protected override bool SetupCommandLoaders(List<ICommandLoader<ICommand<BaseSession, CommandRequestInfo>>> commandLoaders)
		{
			List<ICommand<BaseSession, CommandRequestInfo>> list = new List<ICommand<BaseSession, CommandRequestInfo>>();
			list.Add(new BaseCommand());
			IEnumerable<ICommand<BaseSession, CommandRequestInfo>> _commands = list;

			commandLoaders.Add(new InjectCommandLoader<ICommand<BaseSession, CommandRequestInfo>>(_commands));
			return true;
		}

		protected override void OnStarted()
		{
			base.OnStarted();
		}

	}
}
