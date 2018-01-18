using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    public class UCheckbox : UCaptionWidget
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        public enum Style
        {
            /// <summary>
            /// 
            /// </summary>
            Right,

            /// <summary>
            /// 
            /// </summary>
            Left
        }

        private Style _style = Style.Right;

        /// <summary>
        /// 
        /// </summary>
        private bool _toggled = false;

        #endregion

        #region Event

        /// <summary>
        /// 
        /// </summary>
        public event UToggleChangedEventHandler OnToggleChangedHandle;

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        public UCheckbox()
            : this("Checkbox")
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        public UCheckbox(string caption, Style style = Style.Right)
        {
            this.caption = caption;
            this._style = style;
        }

        #endregion

        #region Public

        /// <summary>
        /// 
        /// </summary>
        public bool toggled
        {
            set 
            {
                if (_toggled != value)
                {
                    _toggled = value;

                    if (OnToggleChangedHandle != null)
                    {
                        OnToggleChangedHandle(new UToggleEventArgs(this, toggled));
                    }
                }
            }
            get { return _toggled; }
        }

        #endregion

        #region Override

        /// <summary>
        /// 
        /// </summary>
        protected override void UpdateGUI()
        {
            if (_style == Style.Right)
            {
                toggled = EditorGUILayout.Toggle(content, toggled);
            }
            else
            {
                toggled = EditorGUILayout.ToggleLeft(content, toggled);
            }
        }

        #endregion
    }
}