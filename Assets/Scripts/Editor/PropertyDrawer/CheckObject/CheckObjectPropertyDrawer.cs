using System;
using MIG.API;
using UnityEditor;
using UnityEngine;

namespace MIG.Editor
{
    [CustomPropertyDrawer(typeof(CheckObjectAttribute))]
    public sealed class CheckObjectPropertyDrawer : PropertyDrawer
    {
        private static CheckObjectDrawerSettings Settings =>
            GameConfigLocator.Get<CheckObjectDrawerSettings>();

        private CheckObjectAttribute CheckAttr => attribute as CheckObjectAttribute;

        public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
        {
            if (!IsPropertySupported(property)) throw new Exception($"{property.propertyType} is not supported");

            using (GetScope(property))
            {
                EditorGUI.PropertyField(rect, property, label, property.hasVisibleChildren);
            }
        }

        private IDisposable GetScope(SerializedProperty property)
        {
            var color = GetPropertyColor(property);
            switch (CheckAttr.Highlight)
            {
                case CheckHighlight.Background:
                    return new GUIBackgroundColorScope(color);
                case CheckHighlight.Content:
                    return new GUIContentColorScope(color);
                default:
                    return new GUIColorScope(color);
            }
        }

        private Color GetPropertyColor(SerializedProperty property)
        {
            return IsPropertyValid(property) ? Settings.ValidColor : Settings.InvalidColor;
        }

        private bool IsPropertySupported(SerializedProperty property)
        {
            switch (property.propertyType)
            {
                case SerializedPropertyType.ObjectReference:
                case SerializedPropertyType.ExposedReference:
                case SerializedPropertyType.ManagedReference:
                    return true;

                default:
                    return false;
            }
        }

        private bool IsPropertyValid(SerializedProperty property)
        {
            switch (property.propertyType)
            {
                case SerializedPropertyType.ObjectReference:
                    return property.objectReferenceValue != null;
                case SerializedPropertyType.ExposedReference:
                    return property.exposedReferenceValue != null;
                case SerializedPropertyType.ManagedReference:
                    return property.managedReferenceValue != null;
                default:
                    return false;
            }
        }
    }
}