using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class UGroup : UControlArea
    {
        #region Construction

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        public UGroup(string caption)
            : base(caption)
        {
        }

        #endregion

        #region Override

        /// <summary>
        /// 
        /// </summary>
        public override void OnGUI()
        {
            GUILayout.Toggle(true, caption, "DragTab");

            EditorGUILayout.BeginVertical("As TextArea",  GUILayout.MinHeight(10));
            {
                DrawControls();
            }
            EditorGUILayout.EndVertical();
        }

        #endregion
    }
}