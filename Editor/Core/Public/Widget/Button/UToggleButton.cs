using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class UToggleButton : UButton
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private bool _toggled = false;

        #endregion

        #region Event

        /// <summary>
        /// 
        /// </summary>
        public event UToggleChangedEventHandler OnToggleChanged;

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        public UToggleButton()
            : this("Toggle Button")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        public UToggleButton(string caption)
            : this(caption, Style.Normal)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        public UToggleButton(string caption, Style style)
            : base(caption, style)
        {
            
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
                _toggled = GUILayout.Toggle(_toggled, content, style);
            }
            if (EditorGUI.EndChangeCheck())
            {
                OnToggleChangedHandler();
            }
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
                if (value != _toggled)
                {
                    _toggled = value;
                    OnToggleChangedHandler();
                }
            }
            get { return _toggled; }
        }

        #endregion

        #region Private

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnToggleChangedHandler()
        {
            if (OnToggleChanged != null)
            {
                UToggleEventArgs args = new UToggleEventArgs(this, toggled);
                OnToggleChanged(args);
            }
        }

        #endregion
    }
}