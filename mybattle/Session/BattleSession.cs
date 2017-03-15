using System;
using odgame;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;

namespace mybattle
{
    public class BattleSession : BaseSession<BattleSession>//RoomSession<BattleSession>//AppSession<BattleSession, CommandRequestInfo>
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BattleRoom Room
        {
            get; set;
        }

        protected override void OnSessionStarted()
        {
            log.Debug("New lobby session started");
        }

        protected override void HandleException(Exception e)
        {
        }

        protected override void OnSessionClosed()
        {
            log.Debug("lobby session closed");
        }
    }
}

