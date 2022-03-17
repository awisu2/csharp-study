using Google.Protobuf.Collections;
using Grpc.Core;

namespace GrpcGreeter.Services
{
    public class UserService : Users.UsersBase
    {
        private readonly ILogger<UserService> _logger;
        private readonly List<User> _users;
        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
            _users = new List<User>();
            _users.Add(new User { Id = 1, Name = "a", Age = 11 });
            _users.Add(new User { Id = 2, Name = "b", Age = 12 });
            _users.Add(new User { Id = 3, Name = "c", Age = 13 });
            _users.Add(new User { Id = 4, Name = "d", Age = 14 });
            _users.Add(new User { Id = 5, Name = "e", Age = 15 });
            _users.Add(new User { Id = 6, Name = "f", Age = 16 });
            _users.Add(new User { Id = 7, Name = "g", Age = 17 });
        }


        private int maxUsersId
        {
            get
            {
                int id = 0;
                foreach (var user in _users)
                {
                    if (user.Id > id)
                    {
                        id = user.Id;
                    }
                }
                return id;
            }
        }

        public override Task<CreateUsersReply> CreateUsers(CreateUsersRequest request, ServerCallContext context)
        {
            var name = request.Name;
            var age = request.Age;
            var Id = maxUsersId + 1;

            var user = new User
            {
                Id = Id,
                Name = name,
                Age = age,
            };

            return Task.FromResult(new CreateUsersReply
            {
                User = user
            });
        }

        public override Task<ReadUsersReply> ReadUsers(ReadUsersRequest request, ServerCallContext context)
        {
            var Id = request.UserId;
            var user = _users.Find(user => user.Id == Id);
            return Task.FromResult(new ReadUsersReply
            {
                User = user
            });
        }

        public override Task<ReadsUsersReply> ReadsUsers(ReadsUsersRequest request, ServerCallContext context)
        {
            var reply = new ReadsUsersReply{};
            foreach (var user in _users.ToArray())
            {
                reply.Users.Add(user);
            }
            return Task.FromResult(reply);
        }

        public override Task<UpdateUsersReply> UpdateUsers(UpdateUsersRequest request, ServerCallContext context)
        {
            var Id = request.UserId;
            var name = request.Name;
            var age = request.Age;
            var user = _users.Find(user => user.Id == Id);
            if (user != null)
            {
                user.Name = name;
                user.Age = age;
            }

            return Task.FromResult(new UpdateUsersReply
            {
                User = user
            });
        }

        public override Task<DeleteUsersReply> DeleteUsers(DeleteUsersRequest request, ServerCallContext context)
        {
            var Id = request.UserId;
            var user = _users.Find(user => user.Id == Id);
            if (user != null)
            {
                _users.Remove(user);
            }

            return Task.FromResult(new DeleteUsersReply
            {
            });
        }
    }
}
