using MagicOnion.Server.Hubs;
using MyMagicOnionShared.Entities;
using MyMagicOnionShared.Services;
using System.Numerics;

namespace MagicOnionServer.Services
{
    // Server implementation
    // implements : StreamingHubBase<THub, TReceiver>, THub
    public class GamingHub : StreamingHubBase<IGamingHub, IGamingHubReceiver>, IGamingHub
    {
        // this class is instantiated per connected so fields are cache area of connection.
        IGroup room;
        Player self;
        IInMemoryStorage<Player> storage;

        public async Task<Player[]> JoinAsync(string roomName, string userName, int position)
        {
            self = new Player() { Name = userName, Position = position };

            // Group can bundle many connections and it has inmemory-storage so add any type per group. 
            (room, storage) = await Group.AddAsync(roomName, self);

            // Typed Server->Client broadcast.
            Broadcast(room).OnJoin(self);

            return storage.AllValues.ToArray();
        }

        public async Task LeaveAsync()
        {
            await room.RemoveAsync(this.Context);
            Broadcast(room).OnLeave(self);
        }

        public async Task MoveAsync(int position)
        {
            self.Position = position;
            Broadcast(room).OnMove(self);
        }

        public Task WaitForDisconnect()
        {
            throw new NotImplementedException();
        }

        // You can hook OnConnecting/OnDisconnected by override.
        //protected override async ValueTask OnDisconnected()
        //{
        //    // on disconnecting, if automatically removed this connection from group.
        //    return CompletedTask;
        //}
    }
}
