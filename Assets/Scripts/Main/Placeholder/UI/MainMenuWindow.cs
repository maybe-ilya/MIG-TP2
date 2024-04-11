using MIG.API;
using UnityEngine;
using UnityEngine.UI;

namespace MIG.Main.Placeholder.UI
{
    internal sealed class MainMenuWindow : MonoBehaviour
    {
        [SerializeField]
        [CheckObject]
        private Button _startGameButton;
        
        [SerializeField]
        [CheckObject]
        private Button _quitGameButton;

        private static IAppStateService AppStateService
            => GameServices.GetService<IAppStateService>();
        
        private void OnEnable()
        {
            _startGameButton.onClick.AddListener(OnStartGameButtonClick);
            _quitGameButton.onClick.AddListener(OnQuitGameButtonClick);
        }

        private void OnDisable()
        {
            _startGameButton.onClick.RemoveListener(OnStartGameButtonClick);
            _quitGameButton.onClick.RemoveListener(OnQuitGameButtonClick);
        }

        private void OnStartGameButtonClick() 
            => AppStateService.PlayGame();

        private void OnQuitGameButtonClick() 
            => AppStateService.QuitGame();
    }
}
