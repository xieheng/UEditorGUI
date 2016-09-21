using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class UMenuButton : UMenuItem
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private string _text = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        private bool _enabled = true;

        #endregion

        #region Event

        /// <summary>
        /// 
        /// </summary>
        public event UEventHandler OnClicked;

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public UMenuButton(string text)
        {
            _text = text;
        }

        #endregion

        #region Override

        /// <summary>
        /// 
        /// </summary>
        public override void OnGUI()
        {
            if (!visible || _parent == null)
                return;

            if (_enabled)
            {
                _parent.AddItem(new GUIContent(_text), false, OnClickedHandler);
            }
            else
            {
                _parent.AddDisabledItem(new GUIContent(_text));
            }
        }

        #endregion

        #region Public

        /// <summary>
        /// 
        /// </summary>
        public bool enabled
        {
            set { _enabled = value; }
            get { return _enabled; }
        }

        #endregion

        #region Private

        /// <summary>
        /// 
        /// </summary>
        private void OnClickedHandler()
        {
            if (OnClicked != null)
            {
                UEventArgs args = new UEventArgs(this);
                OnClicked(args);
            }
        }

        #endregion
    }
}