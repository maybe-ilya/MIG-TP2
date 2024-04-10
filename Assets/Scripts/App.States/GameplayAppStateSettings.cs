using MIG.API;
using UnityEngine;

namespace MIG.App.States
{
    [CreateAssetMenu(menuName = AppStatesConstants.ASSETS_MENU_PATH + nameof(GameplayAppStateSettings))]
    public sealed class GameplayAppStateSettings : ScriptableObject
    {
        [SerializeField]
        [SceneIndex]
        private int _gameplaySceneIndex;

        public int GameplaySceneIndex => _gameplaySceneIndex;
    }
}