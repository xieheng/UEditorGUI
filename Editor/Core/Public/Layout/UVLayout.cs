using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class UVLayout : ULayout
    {
        #region Override

        /// <summary>
        /// 
        /// </summary>
        protected override void BeginGUI()
        {
            EditorGUILayout.BeginVertical();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void EndGUI()
        {
            EditorGUILayout.EndVertical();
        }

        #endregion
    }
}