using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class URectField : UCaptionWidget
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private Rect _value = new Rect();

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        public URectField()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        public URectField(string caption)
            : base(caption)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rect"></param>
        public URectField(Rect rect)
        {
            _value = rect;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="rect"></param>
        public URectField(string caption, Rect rect)
            : base(caption)
        {
            _value = rect;
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
                _value = EditorGUILayout.RectField(caption, _value);
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

        }

        #endregion
    }
}