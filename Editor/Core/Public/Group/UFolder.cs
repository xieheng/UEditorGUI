using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class UFolder : UControlArea
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private string _caption = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        private bool _folder = false;

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        public UFolder(string caption)
        {
            _caption = caption;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="folder"></param>
        public UFolder(string caption, bool folder)
        {
            _caption = caption;
            _folder = folder;
        }

        #endregion

        #region Override

        /// <summary>
        /// 
        /// </summary>
        public override void OnGUI()
        {
            _folder = EditorGUILayout.Foldout(_folder, _caption);
            if (_folder)
            {
                DrawControls();
            }
        }

        #endregion
    }
}