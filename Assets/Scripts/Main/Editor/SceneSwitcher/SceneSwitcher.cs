using MIG.Editor;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

namespace MIG.Main.Editor
{
    public static class SceneSwitcher
    {
        private static SceneSwitcherSettings Settings
            => GameConfigLocator.Get<SceneSwitcherSettings>();

        private const string ROOT_MENU = "Scene Switch/";
        private const string BOOTSTRAP_SCENE_MENU = ROOT_MENU + "Bootstrap";
        private const string MAIN_MENU_SCENE_MENU = ROOT_MENU + "Main Menu";
        private const string GAME_SCENE_MENU = ROOT_MENU + "Game";

        [MenuItem(BOOTSTRAP_SCENE_MENU, true)]
        [MenuItem(MAIN_MENU_SCENE_MENU, true)]
        [MenuItem(GAME_SCENE_MENU, true)]
        private static bool CanSwitchScene() =>
            !EditorApplication.isPlaying;

        [MenuItem(BOOTSTRAP_SCENE_MENU)]
        private static void SwitchToBootstrapScene()
            => SwitchScene(Settings.BootstrapSceneIndex);
        
        [MenuItem(MAIN_MENU_SCENE_MENU)]
        private static void SwitchToMainMenuScene()
            => SwitchScene(Settings.MainMenuSceneIndex);
        
        [MenuItem(GAME_SCENE_MENU)]
        private static void SwitchToGameScene()
            => SwitchScene(Settings.GameSceneIndex);
        
        private static void SwitchScene(int sceneIndex)
        {
            var path = SceneUtility.GetScenePathByBuildIndex(sceneIndex);
            EditorSceneManager.OpenScene(path, OpenSceneMode.Single);
        }
    }
}
