using UnityEngine;

namespace MIG.Editor
{
    [GameConfig(
        "Library/CheckObjectDrawerSettings.asset",
        "Preferences/Check Object Drawer Settings",
        true)]
    public sealed class CheckObjectDrawerSettings : GameConfig
    {
        [SerializeField]
        private Color _validColor = Color.green;

        [SerializeField]
        private Color _invalidColor = Color.red;

        public Color ValidColor => _validColor;

        public Color InvalidColor => _invalidColor;
    }
}