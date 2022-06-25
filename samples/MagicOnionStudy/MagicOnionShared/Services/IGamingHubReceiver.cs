using MyMagicOnionShared.Entities;

namespace MyMagicOnionShared.Services
{
    public interface IGamingHubReceiver
    {
        // return type should be `void` or `Task`, parameters are free.
        void OnJoin(Player player);
        void OnLeave(Player player);
        void OnMove(Player player);
    }
}
