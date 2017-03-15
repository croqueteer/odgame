using System;
using odgame;

namespace mybattle
{
    public class BattleRoom : IRoom<BattleSession>
    {
        public BattleRoom ()
        {
        }

        public void OnClose()
        {
            
        }

        public void OnUserJoined(BattleSession peer)
        {
            peer.Room = this;
        }

        public void OnUserLeft(BattleSession peer)
        {
            
        }

        public void OnMessage(BattleSession peer, IGameCommand<BattleSession> command)
        {
            
        }
    }
}

