using System;
using MIG.API;
using UnityEditor;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MIG.Main
{
    public class AbstractLifetimeScope : LifetimeScope
    {
        [SerializeField]
        [CheckObject]
        private AbstractRegistrator[] _registrators = Array.Empty<AbstractRegistrator>();

        protected override void Configure(IContainerBuilder builder)
        {
            foreach (var registrator in _registrators)
            {
                registrator.Register(builder);
            }
        }
        
        [ContextMenu("Gather Registrators")]
        protected void GatherRegistrators()
        {
            _registrators = GetComponentsInChildren<AbstractRegistrator>();
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
}