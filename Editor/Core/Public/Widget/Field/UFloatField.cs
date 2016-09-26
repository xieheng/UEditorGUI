using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class UFloatField : UCaptionWidget
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private float _value = 0f;

        #endregion

        #region Event

        /// <summary>
        /// 
        /// </summary>
        public event UFloatChangedEventHandler OnValueChanged;

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        public UFloatField()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        public UFloatField(string caption)
            : base(caption)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public UFloatField(float value)
        {
            _value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="value"></param>
        public UFloatField(string caption, float value)
            : base(caption)
        {
            _value = value;
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
                _value = EditorGUILayout.FloatField(caption, _value);
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
        public float value
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
                UFloatEventArgs args = new UFloatEventArgs(this, _value);
                OnValueChanged(args);
            }
        }

        #endregion
    }
}