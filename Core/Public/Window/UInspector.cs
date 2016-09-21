using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class UInspectorTargetObject : ScriptableObject
    {
        /// <summary>
        /// 
        /// </summary>
        public UInspectorTargetObject()
        {
            hideFlags = HideFlags.DontSave;
            name = "UInspector Target Object";
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class UInspector : Editor
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private ULayout _layout = new UVLayout();

        #endregion

        #region Static

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void Active<T>() where T : UInspectorTargetObject
        {
            T targetObject = ScriptableObject.CreateInstance<T>();
            Selection.activeObject = targetObject;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        public static void Active<T>(string name) where T : UInspectorTargetObject
        {
            T targetObject = ScriptableObject.CreateInstance<T>();
            targetObject.name = name;

            Selection.activeObject = targetObject;
        }

        #endregion

        #region Public

        /// <summary>
        /// 
        /// </summary>
        /// <param name="widget"></param>
        public void AddWidget(UWidget widget)
        {
            _layout.AddWidget(widget);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="layout"></param>
        public void AddLayout(ULayout layout)
        {
            _layout.AddLayout(layout);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void OnInspectorGUI()
        {
            _layout.OnGUI();
            Repaint();
        }

        #endregion
    }
}