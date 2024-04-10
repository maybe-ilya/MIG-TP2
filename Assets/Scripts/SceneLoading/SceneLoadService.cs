using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using MIG.API;
using UnityEngine.SceneManagement;

namespace MIG.SceneLoading
{
    [UsedImplicitly]
    public sealed class SceneLoadService : ISceneLoadService
    {
        public async UniTask LoadSceneAsync(int sceneIndex) 
            => await SceneManager.LoadSceneAsync(sceneIndex).ToUniTask();

        public async UniTask LoadSceneAsync(string sceneName)
            => await SceneManager.LoadSceneAsync(sceneName).ToUniTask();
    }
}
