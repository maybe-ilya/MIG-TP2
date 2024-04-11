using MIG.API;
using UnityEngine;
using UnityEngine.UI;

namespace MIG.Main.Placeholder.UI
{
    internal sealed class GameHUD : MonoBehaviour
    {
        [SerializeField]
        [CheckObject]
        private Button _exitGameButton;

        private void OnEnable()
            => _exitGameButton.onClick.AddListener(OnExitButtonClick);

        private void OnDisable()
            => _exitGameButton.onClick.RemoveListener(OnExitButtonClick);

        private void OnExitButtonClick()
            => GameServices.GetService<IAppStateService>().GoToMainMenu();
    }
}