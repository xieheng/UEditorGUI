using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class UPropertyField : UCaptionWidget
    {
        #region

        /// <summary>
        /// 
        /// </summary>
        private SerializedProperty _property = null;

        /// <summary>
        /// 
        /// </summary>
        private bool _children = false;

        #endregion

        #region

        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <param name="includeChildren"></param>
        public UPropertyField(SerializedProperty property, bool includeChildren = false)
        {
            _property = property;
            _children = includeChildren;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="property"></param>
        /// <param name="includeChildren"></param>
        public UPropertyField(string caption, SerializedProperty property, bool includeChildren = false)
            : base(caption)
        {
            _property = property;
            _children = includeChildren;
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
                EditorGUILayout.PropertyField(_property, new GUIContent(caption), _children);
            }
            bool changed = EditorGUI.EndChangeCheck();

            if (changed)
            {
                OnPropertyChangedHandler();
            }
        }

        #endregion

        #region Private

        /// <summary>
        /// 
        /// </summary>
        private void OnPropertyChangedHandler()
        {

        }

        #endregion
    }
}