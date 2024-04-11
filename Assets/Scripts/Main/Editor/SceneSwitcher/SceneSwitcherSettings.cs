using MIG.API;
using MIG.Editor;
using UnityEngine;

namespace MIG.Main.Editor
{
    [GameConfig(
        savePath: "ProjectSettings/SceneSwitcherSettings.asset",
        settingsPath: "Project/Scene Switcher",
        isPreference: false)]
    public sealed class SceneSwitcherSettings : GameConfig
    {
        [SerializeField]
        [SceneIndex]
        private int _bootstrapSceneIndex;

        [SerializeField]
        [SceneIndex]
        private int _mainMenuSceneIndex;

        [SerializeField]
        [SceneIndex]
        private int _gameSceneIndex;

        public int BootstrapSceneIndex => _bootstrapSceneIndex;
        public int MainMenuSceneIndex => _mainMenuSceneIndex;
        public int GameSceneIndex => _gameSceneIndex;
    }
}
