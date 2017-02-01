using System;
using SuperSocket.SocketBase.Protocol;
using SuperSocket.Facility.Protocol;

namespace odgame
{
	public class CommandReceiveFilter : FixedHeaderReceiveFilter<CommandRequestInfo>
	{
		public CommandReceiveFilter()
			: base(4)
		{
		}

		protected override int GetBodyLengthFromHeader(byte[] header, int offset, int length)
		{
			return BitConverter.ToInt32(header, offset);
		}

		protected override CommandRequestInfo ResolveRequestInfo(ArraySegment<byte> header, byte[] bodyBuffer, int offset, int length)
		{
			byte[] bytes = new byte[length];
			Array.Copy(bodyBuffer, offset, bytes, 0, length);
			return new CommandRequestInfo(bytes);
		}

	}
}
