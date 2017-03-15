using System;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using Ninject;
using Ninject.Extensions.Conventions;

using odgame;

namespace mylobby
{
	public class LobbyServer : BaseServer<LobbySession>
	{
		public LobbyServer() : base(new ServerModule())
		{
		}

		protected override void OnStarted()
		{
			base.OnStarted();
		}
	}
}
