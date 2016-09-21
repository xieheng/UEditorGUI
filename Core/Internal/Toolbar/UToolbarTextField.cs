using UnityEngine;
using UnityEditor;

namespace UEditorGUI.Internal.Toolbar
{
    /// <summary>
    /// 
    /// </summary>
    internal class UToolbarTextField : UTextField
    {
        #region Construction

        /// <summary>
        /// 
        /// </summary>
        public UToolbarTextField()
            : base(EditorStyles.toolbarTextField)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="alignment"></param>
        public UToolbarTextField(string caption)
            : base(caption, EditorStyles.toolbarTextField)
        {
        }

        #endregion
    }
}