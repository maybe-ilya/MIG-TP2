namespace MIG.API
{
    public interface IGameStateService : IService
    {
        void WaitForInput();
        void Aim();
        void Shoot();
    }
}
