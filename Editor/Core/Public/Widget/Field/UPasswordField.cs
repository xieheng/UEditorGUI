using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class UPasswordField : UCaptionWidget
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private string _password = string.Empty;

        #endregion

        #region Event

        /// <summary>
        /// 
        /// </summary>
        public event UTextChangedEventHandler OnPasswordChanged;

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        public UPasswordField(string password)
        {
            _password = password;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="password"></param>
        public UPasswordField(string caption, string password)
            : base(caption)
        {
            _password = password;
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
                _password = EditorGUILayout.PasswordField(caption, _password);
            }
            bool changed = EditorGUI.EndChangeCheck();

            if (changed)
            {
                OnPasswordChangedHandler();
            }
        }

        #endregion

        #region Public

        /// <summary>
        /// 
        /// </summary>
        public string password
        {
            set
            {
                _password = value;
                OnPasswordChangedHandler();
            }

            get { return _password; }
        }

        #endregion

        #region Private

        /// <summary>
        /// 
        /// </summary>
        private void OnPasswordChangedHandler()
        {
            if (OnPasswordChanged != null)
            {
                UTextEventArgs args = new UTextEventArgs(this, _password);
                OnPasswordChanged(args);
            }
        }

        #endregion
    }
}