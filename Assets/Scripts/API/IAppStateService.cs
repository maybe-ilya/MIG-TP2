namespace MIG.API
{
    public interface IAppStateService : IService
    {
        void GoToMainMenu();
        void PlayGame();
        void QuitGame();
    }
}
