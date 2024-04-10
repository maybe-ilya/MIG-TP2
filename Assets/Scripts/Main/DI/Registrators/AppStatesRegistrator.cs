using MIG.API;
using MIG.App.States;
using MIG.AppState;
using UnityEngine;
using VContainer;

namespace MIG.Main
{
    public sealed class AppStatesRegistrator : AbstractRegistrator
    {
        [SerializeField]
        [CheckObject]
        private MainMenuStateSettings _mainMenuStateSettings;

        [SerializeField]
        [CheckObject]
        private GameplayAppStateSettings _gameplayAppStateSettings;
        
        public override void Register(IContainerBuilder builder)
        {
            builder.RegisterInstance(_mainMenuStateSettings);
            builder.RegisterInstance(_gameplayAppStateSettings);
            
            builder.Register<MainMenuState>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<GameplayAppState>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<QuitAppState>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<AppStateService>(Lifetime.Singleton).AsImplementedInterfaces();

            builder.RegisterBuildCallback(OnContainerBuild);
        }

        private void OnContainerBuild(IObjectResolver resolver) 
            => resolver.Resolve<IAppStateService>().GoToMainMenu();
    }
}
