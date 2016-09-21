using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class UMenuItem
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        protected bool _visible = true;

        /// <summary>
        /// 
        /// </summary>
        protected GenericMenu _parent = null;

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
        /// <param name="parent"></param>
        public void SetParent(GenericMenu parent)
        {
            _parent = parent;
        }

        #endregion
    }
}