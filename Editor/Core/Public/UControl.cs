using UnityEngine;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class UControl : UPanel
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private GUIStyle _style = GUIStyle.none;

        /// <summary>
        /// 
        /// </summary>
        private bool _attachOnToolbar = false;

        #endregion

        #region Privte

        /// <summary>
        /// 
        /// </summary>
        protected GUIStyle style
        {
            set { _style = value; }
            get { return _style; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected bool attachOnToolbar
        {
            set { _attachOnToolbar = value; }
            get { return _attachOnToolbar; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        protected static void ActiveToolbarGuiStyle(UControl control)
        {
            control.attachOnToolbar = true;
            control.ActiveToolbarGuiStyle();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        protected static void UnActiveToolbarGuiStyle(UControl control)
        {
            control.attachOnToolbar = false;
            control._style = GUIStyle.none;
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void ActiveToolbarGuiStyle()
        {
        }

        #endregion
    }
}