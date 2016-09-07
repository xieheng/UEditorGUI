using UnityEngine;
using UnityEditor;

namespace UEditorGUI.Internal.Toolbar
{
    /// <summary>
    /// 
    /// </summary>
    internal class UToolbarButton : UButton
    {
        #region Construction

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        public UToolbarButton(string caption)
            : base(caption, EditorStyles.toolbarButton)
        {
            _autoSize = false;
        }

        #endregion
    }
}
