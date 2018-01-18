using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    public class UListViewItem
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        protected string _text = string.Empty;

        #endregion

        #region Construction

        public UListViewItem(string text)
        {
            _text = text;
        }

        #endregion
    }
}