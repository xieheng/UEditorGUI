using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class UColorfulWidget : UWidget
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private Color _color = Color.white;

        #endregion

        #region Public

        /// <summary>
        /// 
        /// </summary>
        public Color color
        {
            set { _color = value; }
            get { return _color; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void OnGUI()
        {
            if (visible)
            {
                BeginGUI();
                {
                    UpdateGUI();
                }
                EndGUI();
            }
        }

        #endregion

        #region Private

        /// <summary>
        /// 
        /// </summary>
        protected void BeginGUI()
        {
            GUI.color = _color;
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void UpdateGUI()
        {
            //draw the ui here
        }

        /// <summary>
        /// 
        /// </summary>
        protected void EndGUI()
        {
            GUI.color = Color.white;
        }

        #endregion
    }
}