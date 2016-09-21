using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class UVector2Filed : UCaptionWidget
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private Vector2 _vector = Vector2.zero;

        #endregion

        #region Event

        /// <summary>
        /// 
        /// </summary>
        public event UVector2EventHandler OnValueChanged;

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        public UVector2Filed()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        public UVector2Filed(string caption)
            : base(caption)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        public UVector2Filed(Vector2 vector)
        {
            _vector = vector;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="vector"></param>
        public UVector2Filed(string caption, Vector2 vector)
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
                _vector = EditorGUILayout.Vector2Field(caption, _vector);
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
                UVector2EventArgs args = new UVector2EventArgs(this, _vector);
                OnValueChanged(args);
            }
        }

        #endregion
    }
}