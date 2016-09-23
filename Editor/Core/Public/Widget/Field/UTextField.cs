using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class UTextField : UCaptionWidget
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        protected string _text = string.Empty;

        #endregion

        #region Event

        /// <summary>
        /// 
        /// </summary>
        public event UTextChangedEventHandler OnTextChanged;

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        public UTextField()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        public UTextField(string caption)
            : base(caption)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="style"></param>
        protected UTextField(GUIStyle style)
        {
            this.style = style;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="style"></param>
        protected UTextField(string caption, GUIStyle style)
            : base(caption)
        {
            this.style = style;
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
                if (style == GUIStyle.none)
                {
                    _text = EditorGUILayout.TextField(caption, _text);
                }
                else
                {
                    _text = EditorGUILayout.TextField(caption, _text, style);
                }
            }
            bool changed = EditorGUI.EndChangeCheck();

            if (changed)
            {
                OnTextChangedHandler();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void ActiveToolbarGuiStyle()
        {
            this.style = EditorStyles.toolbarTextField;
        }

        #endregion

        #region Private

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnTextChangedHandler()
        {
            if (OnTextChanged != null)
            {
                UTextEventArgs args = new UTextEventArgs(this, _text);
                OnTextChanged(args);
            }
        }

        #endregion
    }
}