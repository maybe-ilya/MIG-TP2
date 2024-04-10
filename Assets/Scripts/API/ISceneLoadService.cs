using Cysharp.Threading.Tasks;

namespace MIG.API
{
    public interface ISceneLoadService : IService
    {
        UniTask LoadSceneAsync(int sceneIndex);
        UniTask LoadSceneAsync(string sceneName);
    }
}