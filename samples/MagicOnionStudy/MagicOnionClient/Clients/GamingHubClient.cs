using Grpc.Core;
using MagicOnion.Client;
using MyMagicOnionShared.Entities;
using MyMagicOnionShared.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MyMagicOnionClient.Clients
{
    public class GamingHubClient : IGamingHubReceiver
    {
        Dictionary<string, string> players = new Dictionary<string, string>();

        IGamingHub client;

        public async Task<string> ConnectAsync(ChannelBase grpcChannel, string roomName, string playerName)
        {
            this.client = await StreamingHubClient.ConnectAsync<IGamingHub, IGamingHubReceiver>(grpcChannel, this);

            var roomPlayers = await client.JoinAsync(roomName, playerName, 0);
            foreach (var player in roomPlayers)
            {
                (this as IGamingHubReceiver).OnJoin(player);
            }

            return players[playerName];
        }

        // methods send to server.

        public Task LeaveAsync()
        {
            return client.LeaveAsync();
        }

        public Task MoveAsync(int position)
        {
            return client.MoveAsync(position);
        }

        // dispose client-connection before channel.ShutDownAsync is important!
        public Task DisposeAsync()
        {
            return client.DisposeAsync();
        }

        // You can watch connection state, use this for retry etc.
        public Task WaitForDisconnect()
        {
            return client.WaitForDisconnect();
        }

        // Receivers of message from server.

        void IGamingHubReceiver.OnJoin(Player player)
        {
            Console.WriteLine("Join Player:" + player.Name);

            //var cube = string.CreatePrimitive(PrimitiveType.Cube);
            //cube.name = player.Name;
            //cube.transform.SetPositionAndRotation(player.Position, player.Rotation);
            var cube = player.Name;

            players[player.Name] = cube;
        }

        void IGamingHubReceiver.OnLeave(Player player)
        {
            Console.WriteLine("Leave Player:" + player.Name);

            if (players.TryGetValue(player.Name, out var cube))
            {
                //string.Destroy(cube);
            }
        }

        void IGamingHubReceiver.OnMove(Player player)
        {
            Console.WriteLine("Move Player:" + player.Name);

            if (players.TryGetValue(player.Name, out var cube))
            {
                //cube.transform.SetPositionAndRotation(player.Position, player.Rotation);
            }
        }
    }
}
