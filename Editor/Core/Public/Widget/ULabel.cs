using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class ULabel : UColorfulWidget
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private string _text = string.Empty;

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public ULabel(string text)
        {
            _text = text;
        }

        #endregion

        #region Override

        /// <summary>
        /// 
        /// </summary>
        protected override void UpdateGUI()
        {
            GUILayout.Label(_text);
        }

        #endregion
    }
}