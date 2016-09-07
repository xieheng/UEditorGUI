using UnityEngine;
using UnityEditor;
using System;

namespace UEditorGUI.Internal.Toolbar
{
    /// <summary>
    /// 
    /// </summary>
    internal class UToolbarEnumPopup : UEnumPopup
    {
        #region Construction

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumValue"></param>
        public UToolbarEnumPopup(System.Enum enumValue)
            : base(EditorStyles.toolbarPopup)
        {
            _enum = enumValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="enumValue"></param>
        public UToolbarEnumPopup(string caption, System.Enum enumValue)
            : base(caption, EditorStyles.toolbarPopup)
        {
            _enum = enumValue;
        }

        #endregion
    }
}
