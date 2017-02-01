using System;
using System.Collections.Generic;
using odgame;

namespace mylobby
{
	public class CommandFactory : ICommandFactory
	{
		private static Dictionary<string, Func<IGameCommand>> commandMap = new Dictionary<string, Func<IGameCommand>>();

		public CommandFactory(IEnumerable<IGameCommand> commands)
    	{
			commandMap = new Dictionary<string, Func<IGameCommand>>();
        	foreach (IGameCommand command in commands)
        	{
				commandMap.Add(command.Id(), () => (IGameCommand)Activator.CreateInstance(command.GetType()));
			}
		}

		public IGameCommand Create(game.GameRequest req)
		{
			Func<IGameCommand> f;
			commandMap.TryGetValue(req.messageType, out f);
			if (f != null)
			{
				IGameCommand cmd = f();
				cmd.Init(req);
				return cmd;
			}
			return null;
		}
	}
}
