using System;
using SuperSocket.SocketBase.Protocol;

namespace odgame
{
	public class CommandRequestInfo : BinaryRequestInfo
	{
		public CommandRequestInfo(byte[] bytes) : base("SRC", bytes)
		{

		}
	}
}
