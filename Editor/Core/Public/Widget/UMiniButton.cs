using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class UMiniButton : UButton
    {
        #region Construction

        /// <summary>
        /// 
        /// </summary>
        public UMiniButton()
            : base("Mini Button", EditorStyles.miniButton)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        public UMiniButton(string caption)
            : base(caption, EditorStyles.miniButton)
        {
        }

        #endregion
    }
}