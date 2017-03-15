using System;
using SuperSocket.SocketBase;


namespace odgame
{
    public class RoomSession<T> : BaseSession<T> where T:AppSession<T, CommandRequestInfo>, IAppSession, new()
	{
		IRoom<T> room { get; set;}

        protected override void OnSessionStarted()
		{ }
        protected override void HandleException(Exception e)
		{ }
        protected override void OnSessionClosed()
		{ }
        public void SendEvent(game.GameReply reply)
        {
            base.Send(reply);
        }
	}
}
