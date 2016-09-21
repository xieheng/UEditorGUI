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
        /// <param name="control"></param>
        protected static void ActiveToolbarGuiStyle(UControl control)
        {
            control.ActiveToolbarGuiStyle();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        protected static void UnActiveToolbarGuiStyle(UControl control)
        {
            control.style = GUIStyle.none;
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