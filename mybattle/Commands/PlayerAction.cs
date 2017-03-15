using System;
using odgame;

namespace mybattle
{
    public class PlayerAction : IGameCommand<BattleSession>
    {
        public string Id()
        {
            return "PlayerAction";
        }

        public void Init(game.GameRequest req)
        {
            
        }

        public void Execute(BattleSession session)
        {
            session.Room.OnMessage(session, this);
        }
    }
}

