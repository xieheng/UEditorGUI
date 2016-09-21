using UnityEngine;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class UPanel
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private bool _visible = true;

        /// <summary>
        /// 
        /// </summary>
        private bool _focus = false;

        #endregion

        #region Public

        /// <summary>
        /// 
        /// </summary>
        public abstract void OnGUI();

        /// <summary>
        /// 
        /// </summary>
        public bool visible
        {
            set { _visible = value; }
            get { return _visible; }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void OnFocus()
        {
            focus = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void LostFocus()
        {
            focus = false;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool focus
        {
            protected set { _focus = value; }
            get { return _focus; }
        }

        #endregion
    }
}