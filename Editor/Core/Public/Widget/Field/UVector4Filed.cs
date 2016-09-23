using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class UVector4Filed : UCaptionWidget
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private Vector4 _vector = Vector4.zero;

        #endregion

        #region Event

        /// <summary>
        /// 
        /// </summary>
        public event UVector4EventHandler OnValueChanged;

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        public UVector4Filed()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        public UVector4Filed(string caption)
            : base(caption)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        public UVector4Filed(Vector4 vector)
        {
            _vector = vector;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="vector"></param>
        public UVector4Filed(string caption, Vector4 vector)
            : base(caption)
        {
            _vector = vector;
        }

        #endregion

        #region Override

        /// <summary>
        /// 
        /// </summary>
        protected override void UpdateGUI()
        {
            EditorGUI.BeginChangeCheck();
            {
                _vector = EditorGUILayout.Vector4Field(caption, _vector);
            }
            bool changed = EditorGUI.EndChangeCheck();

            if (changed)
            {
                OnValueChangedHandler();
            }
        }

        #endregion

        #region Private

        /// <summary>
        /// 
        /// </summary>
        private void OnValueChangedHandler()
        {
            if (OnValueChanged != null)
            {
                UVector4EventArgs args = new UVector4EventArgs(this, _vector);
                OnValueChanged(args);
            }
        }

        #endregion
    }
}