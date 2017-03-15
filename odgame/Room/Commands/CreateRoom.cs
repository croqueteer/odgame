using System;
using SuperSocket.SocketBase;
using System.Collections.Generic;

namespace odgame
{
    public class CreateRoom<T, R> : IGameCommand<T> where T:AppSession<T, CommandRequestInfo>, IAppSession, new() where R:IRoom<T>, new()
    {
        private string roomId;

        public string Id()
        {
            return "CreateRoom";
        }

        public void Init(game.GameRequest req)
        {
            string type = req.messageType;
            List<game.Value> values = new List<game.Value>();
            foreach (game.Value v in req.values)
            {
                values.Add(v);
            }
            roomId = values[0].strValue;
        }

        public void Execute(T session)
        {
            //var room = new R();
            var roomRegistry = InjectorHelper.Get<IRoomRegistry<T, R>>();
            var room = roomRegistry.FindOrCreateRoom(roomId);
            room.OnUserJoined(session);
        }
    }
}

