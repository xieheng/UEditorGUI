using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class UIntSlider : UCaptionWidget
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private int _min = 0;

        /// <summary>
        /// 
        /// </summary>
        private int _max = 1;

        /// <summary>
        /// 
        /// </summary>
        private int _value = 0;

        #endregion

        #region Event

        /// <summary>
        /// 
        /// </summary>
        private event UIntChangedEventHandler OnValueChanged;

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public UIntSlider(int value, int min, int max)
        {
            _value = value;
            _min = min;
            _max = max;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public UIntSlider(string caption, int value, int min, int max)
            : base(caption)
        {
            _value = value;
            _min = min;
            _max = max;
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
                _value = EditorGUILayout.IntSlider(caption, _value, _min, _max);
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
                UIntEventArgs args = new UIntEventArgs(this, _value);
                OnValueChanged(args);
            }
        }

        #endregion
    }
}