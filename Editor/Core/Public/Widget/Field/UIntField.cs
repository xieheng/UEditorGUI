using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class UIntField : UCaptionWidget
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        protected int _value = 0;

        #endregion

        #region Event

        /// <summary>
        /// 
        /// </summary>
        public event UIntChangedEventHandler OnValueChanged;

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        public UIntField()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        public UIntField(string caption)
            : base(caption)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="initValue"></param>
        public UIntField(int initValue)
        {
            _value = initValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="initValue"></param>
        public UIntField(string caption, int initValue)
            : base(caption)
        {
            _value = initValue;
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
                _value = EditorGUILayout.IntField(caption, _value);
            }
            bool changed = EditorGUI.EndChangeCheck();

            if (changed)
            {
                OnValueChangedHandler();
            }
        }

        #endregion

        #region Public 

        /// <summary>
        /// 
        /// </summary>
        public int value
        {
            set
            {
                _value = value;
                OnValueChangedHandler();
            }

            get { return _value; }
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
                UIntEventArgs args = new UIntEventArgs(this, _value);
                OnValueChanged(args);
            }
        }

        #endregion
    }
}