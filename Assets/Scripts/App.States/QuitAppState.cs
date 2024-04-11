using JetBrains.Annotations;
using MIG.API;
using MIG.AppState;
#if UNITY_EDITOR
using UnityEditor;
#else
using UnityEngine;
#endif

namespace MIG.App.States
{
    [UsedImplicitly]
    public sealed class QuitAppState : AbstractAppState, IQuitAppState
    {
        private readonly ILogService _logger;

        public QuitAppState(ILogService logger)
        {
            _logger = logger;
        }

        public void Enter()
            => QuitAppInternal();

        private void QuitAppInternal()
        {
            _logger.Log(LogChannel, "Bye bye!");
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        }
    }
}