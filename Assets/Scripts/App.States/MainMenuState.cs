using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using MIG.API;
using MIG.AppState;

namespace MIG.App.States
{
    [UsedImplicitly]
    public sealed class MainMenuState : AbstractAppState, IMainMenuState
    {
        private readonly ISceneLoadService _sceneLoadService;
        private readonly MainMenuStateSettings _settings;
        private readonly ILogService _logger;

        public MainMenuState(
            ISceneLoadService sceneLoadService,
            MainMenuStateSettings settings,
            ILogService logger
        )
        {
            _sceneLoadService = sceneLoadService;
            _settings = settings;
            _logger = logger;
        }

        public void Enter()
            => LoadMainMenuScene().Forget();

        private async UniTaskVoid LoadMainMenuScene()
        {
            _logger.Log(StateLogChannel,"Going to main menu");
            await _sceneLoadService.LoadSceneAsync(_settings.MainMenuSceneIndex);
            _logger.Log(StateLogChannel,"Main menu loaded");
        }
    }
}