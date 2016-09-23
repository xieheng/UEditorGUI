using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class UControlArea : UControl
    {
        #region

        /// <summary>
        /// 
        /// </summary>
        private ULayout _layout = new UVLayout();

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        protected UControlArea()
        {

        }

        #endregion

        #region Public

        /// <summary>
        /// 
        /// </summary>
        /// <param name="widget"></param>
        public void AddWidget(UControl widget)
        {
            _layout.AddWidget(widget);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="layout"></param>
        public void AddLayout(ULayout layout)
        {
            _layout.AddLayout(layout);
        }

        #endregion

        #region Private

        /// <summary>
        /// 
        /// </summary>
        protected void DrawControls()
        {
            _layout.OnGUI();
        }

        #endregion
    }
}