using UnityEngine;
using System.Collections;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class UCaptionWidget : UColorfulWidget
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private GUIContent _content = new GUIContent();

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        protected UCaptionWidget()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        protected UCaptionWidget(string caption)
        {
            _content.text = caption;
        }

        #endregion

        #region Public

        /// <summary>
        /// 
        /// </summary>
        public string caption
        {
            set { _content.text = value; }
            get { return _content.text; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string tooltip
        {
            set { _content.tooltip = value; }
            get { return _content.tooltip; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Texture image
        {
            set { _content.image = value; }
            get { return _content.image; }
        }

        #endregion

        #region Private

        /// <summary>
        /// 
        /// </summary>
        protected GUIContent content
        {
            get { return _content; }
        }

        #endregion
    }
}