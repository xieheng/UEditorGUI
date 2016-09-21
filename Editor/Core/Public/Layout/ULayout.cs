using UnityEngine;
using System.Collections.Generic;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class ULayout : UPanel
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        protected List<UPanel> _children = new List<UPanel>();

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        protected ULayout()
        {

        }

        #endregion

        #region Override

        /// <summary>
        /// 
        /// </summary>
        public override void OnGUI()
        {
            if (!visible)
                return;

            BeginGUI();
            {
                for (int i = 0; i < _children.Count; i++)
                {
                    UPanel child = _children[i];
                    child.OnGUI();
                }
            }
            EndGUI();
        }

        #endregion

        #region Public

        /// <summary>
        /// Add a widget into
        /// </summary>
        /// <param name="widget"></param>
        public void AddWidget(UControl widget)
        {
            if (widget != null)
            {
                _children.Add(widget);
            }
        }

        /// <summary>
        /// Add a layout into
        /// </summary>
        /// <param name="layout"></param>
        public void AddLayout(ULayout layout)
        {
            if (layout != null)
            {
                _children.Add(layout);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void OnFocus()
        {
            foreach (UControl c in _children)
            {
                c.OnFocus();
            }

            base.OnFocus();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void LostFocus()
        {
            foreach (UControl c in _children)
            {
                c.LostFocus();
            }

            base.LostFocus();
        }

        #endregion

        #region Private

        /// <summary>
        /// 
        /// </summary>
        protected virtual void BeginGUI()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void EndGUI()
        {

        }

        #endregion
    }
}