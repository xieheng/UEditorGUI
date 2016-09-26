using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class UObjectField : UCaptionWidget
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        protected Object _object = null;

        /// <summary>
        /// 
        /// </summary>
        protected System.Type _type = null;

        #endregion

        #region Event

        /// <summary>
        /// 
        /// </summary>
        public event UObjectChangedEventHandler OnObjectChanged;

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        public UObjectField(System.Type type)
        {
            _type = type;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="type"></param>
        public UObjectField(string caption, System.Type type)
            : base(caption)
        {
            _type = type;
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
                _object = EditorGUILayout.ObjectField(caption, _object, _type);
            }
            bool changed = EditorGUI.EndChangeCheck();

            if (changed)
            {
                OnObjectChangedHandler();
            }
        }

        #endregion

        #region Public

        /// <summary>
        /// 
        /// </summary>
        public Object targetObject
        {
            set 
            {
                _object = value;
                OnObjectChangedHandler();
            }

            get { return _object; }
        }

        #endregion

        #region Private

        /// <summary>
        /// 
        /// </summary>
        private void OnObjectChangedHandler()
        {
            if (OnObjectChanged != null)
            {
                UObjectEventArgs args = new UObjectEventArgs(this, _object);
                OnObjectChanged(args);
            }
        }

        #endregion
    }
}