using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class UControlArea : UControl
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private string _caption = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        private ULayout _layout = new UVLayout();

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        protected UControlArea(string caption)
        {
            _caption = caption;
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

        /// <summary>
        /// 
        /// </summary>
        public string caption
        {
            set { _caption = value; }
            get { return _caption; }
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