using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class UTagPopup : UCaptionWidget
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private string _tag = "Untagged";

        #endregion

        #region Event

        /// <summary>
        /// 
        /// </summary>
        public event UTextChangedEventHandler OnTagChanged;

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tag"></param>
        public UTagPopup(string tag)
        {
            _tag = tag;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="tag"></param>
        public UTagPopup(string caption, string tag)
            : base(caption)
        {
            _tag = tag;
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
                _tag = EditorGUILayout.TagField(caption, _tag);
            }
            bool changed = EditorGUI.EndChangeCheck();

            if (changed)
            {

            }
        }

        #endregion

        #region Public

        /// <summary>
        /// 
        /// </summary>
        public string tag
        {
            set
            {
                _tag = value;
                OnTagChangedHandler();
            }

            get { return _tag; }
        }

        #endregion

        #region Private

        /// <summary>
        /// 
        /// </summary>
        private void OnTagChangedHandler()
        {
            if (OnTagChanged != null)
            {
                UTextEventArgs args = new UTextEventArgs(this, _tag);
                OnTagChanged(args);
            }
        }

        #endregion
    }
}