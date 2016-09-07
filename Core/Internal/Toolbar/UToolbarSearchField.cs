using UnityEngine;
using UnityEditor;

namespace UEditorGUI.Internal.Toolbar
{
    /// <summary>
    /// 
    /// </summary>
    internal class UToolbarSearchField : USearchField
    {
        #region Construction

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alignment"></param>
        public UToolbarSearchField()
            : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alignment"></param>
        public UToolbarSearchField(string caption)
            : base(caption)
        {
        }

        #endregion
    }
}