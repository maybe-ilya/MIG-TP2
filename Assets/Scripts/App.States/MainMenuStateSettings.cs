using MIG.API;
using UnityEngine;

namespace MIG.App.States
{
    [CreateAssetMenu(menuName = AppStatesConstants.ASSETS_MENU_PATH + nameof(MainMenuStateSettings))]
    public class MainMenuStateSettings : ScriptableObject
    {
        [SerializeField]
        [SceneIndex]
        private int _mainMenuSceneIndex;

        public int MainMenuSceneIndex => _mainMenuSceneIndex;
    }
}