using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class UFoldout : UControlArea
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private bool _foldout = false;

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        public UFoldout(string caption)
            : base(caption)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="folder"></param>
        public UFoldout(string caption, bool foldout)
            : base(caption)
        {
            _foldout = foldout;
        }

        #endregion

        #region Override

        /// <summary>
        /// 
        /// </summary>
        public override void OnGUI()
        {
            _foldout = EditorGUILayout.Foldout(_foldout, caption);
            if (_foldout)
            {
                DrawControls();
            }
        }

        #endregion
    }
}