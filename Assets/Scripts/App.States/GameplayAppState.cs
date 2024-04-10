using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using MIG.API;
using MIG.AppState;

namespace MIG.App.States
{
    [UsedImplicitly]
    public sealed class GameplayAppState : AbstractAppState, IGameplayAppState
    {
        private readonly ISceneLoadService _sceneLoadService;
        private readonly ILogService _logger;
        private readonly GameplayAppStateSettings _settings;

        public GameplayAppState(
            ISceneLoadService sceneLoadService,
            ILogService logger,
            GameplayAppStateSettings settings
        )
        {
            _sceneLoadService = sceneLoadService;
            _logger = logger;
            _settings = settings;
        }

        public void Enter()
            => LoadGameplayScene().Forget();

        private async UniTaskVoid LoadGameplayScene()
        {
            _logger.Log(StateLogChannel, "Loading gameplay scene");
            await _sceneLoadService.LoadSceneAsync(_settings.GameplaySceneIndex);
            _logger.Log(StateLogChannel,"Gameplay scene loaded");
        }
    }
}