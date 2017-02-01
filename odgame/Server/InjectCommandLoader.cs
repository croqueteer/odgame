using System;
using System.Collections.Generic;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Command;

namespace odgame
{
	public class InjectCommandLoader<TCommand> : CommandLoaderBase<TCommand> where TCommand : class, ICommand
	{
		public override bool Initialize(IRootConfig rootConfig, IAppServer appServer)
		{
			return true;
		}

		private readonly IEnumerable<TCommand> _commands;

		public InjectCommandLoader(IEnumerable<TCommand> commands)
		{
			_commands = commands;
		}

		public override bool TryLoadCommands(out IEnumerable<TCommand> commands)
		{
			commands = _commands;
			return true;
		}	
	}
}
