using System;
using System.Collections.Generic;
using odgame;

namespace mylobby
{
	public class CommandFactory : ICommandFactory<LobbySession>
	{
		private static Dictionary<string, Func<IGameCommand<LobbySession>>> commandMap = new Dictionary<string, Func<IGameCommand<LobbySession>>>();

		public CommandFactory(IEnumerable<IGameCommand<LobbySession>> commands)
    	{
            commandMap = new Dictionary<string, Func<IGameCommand<LobbySession>>>();
            foreach (IGameCommand<LobbySession> command in commands)
        	{
                commandMap.Add(command.Id(), () => (IGameCommand<LobbySession>)Activator.CreateInstance(command.GetType()));
			}
		}

        public IGameCommand<LobbySession> Create(game.GameRequest req)
		{
            Func<IGameCommand<LobbySession>> f;
			commandMap.TryGetValue(req.messageType, out f);
			if (f != null)
			{
                IGameCommand<LobbySession> cmd = f();
				cmd.Init(req);
				return cmd;
			}
			return null;
		}
	}
}
