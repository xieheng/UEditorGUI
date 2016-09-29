using UnityEngine;
using UnityEditor;
using System;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class UEnumMaskPopup : UEnumPopup
    {
        #region Construction 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public UEnumMaskPopup(System.Enum value)
            : base(value)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="value"></param>
        public UEnumMaskPopup(string caption, System.Enum value)
            : base(caption, value)
        {

        }

        #endregion

        #region Override

        /// <summary>
        /// 
        /// </summary>
        protected override void UpdateGUI()
        {
            EditorGUI.BeginChangeCheck();
            {
                if (style == GUIStyle.none)
                {
                    EditorGUILayout.EnumMaskField(caption, _enum);
                }
                else
                {
                    EditorGUILayout.EnumMaskField(caption, _enum, style);
                }
            }
            bool changed = EditorGUI.EndChangeCheck();

            if (changed)
            {
                OnValueChangedHandler();
            }
        }

        #endregion
    }
}