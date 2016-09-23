using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class USearchField : UTextField
    {
        #region Construction

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alignment"></param>
        public USearchField()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alignment"></param>
        public USearchField(string caption)
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
            if (!visible)
                return;

            EditorGUILayout.BeginHorizontal();
            {
                EditorGUI.BeginChangeCheck();
                {
                    _text = GUILayout.TextField(_text, GUI.skin.FindStyle("ToolbarSeachTextField"), GUILayout.Width(120));
                }
                bool changed = EditorGUI.EndChangeCheck();

                if (string.IsNullOrEmpty(_text))
                {
                    GUILayout.Label(string.Empty, GUI.skin.FindStyle("ToolbarSeachCancelButtonEmpty"));
                }
                else
                {
                    if (GUILayout.Button(string.Empty, GUI.skin.FindStyle("ToolbarSeachCancelButton")))
                    {
                        _text = string.Empty;
                        changed = true;

                        GUI.FocusControl(null);
                    }
                }

                if (changed)
                {
                    OnTextChangedHandler();
                }
            }
            EditorGUILayout.EndHorizontal();
        }

        #endregion
    }
}