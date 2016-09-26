using UnityEngine;
using UnityEditor;
using System;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class UEnumPopup : UCaptionWidget
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        protected System.Enum _enum = null;

        #endregion

        #region Event

        /// <summary>
        /// 
        /// </summary>
        public event UEnumChangedEventHandler OnValueChanged;

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumValue"></param>
        public UEnumPopup(System.Enum enumValue)
        {
            _enum = enumValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="enumValue"></param>
        public UEnumPopup(string caption, System.Enum enumValue)
            : base(caption)
        {
            _enum = enumValue;
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
                if (style == GUIStyle.none)
                {
                    _enum = EditorGUILayout.EnumPopup(caption, _enum);
                }
                else
                {
                    _enum = EditorGUILayout.EnumPopup(caption, _enum, style);
                }
            }
            bool changed = EditorGUI.EndChangeCheck();

            if (changed)
            {
                OnValueChangedHandler();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void ActiveToolbarGuiStyle()
        {
            this.style = EditorStyles.toolbarPopup;
        }

        #endregion

        #region Public

        /// <summary>
        /// 
        /// </summary>
        public System.Enum value
        {
            set 
            {
                _enum = value;
                OnValueChangedHandler();
            }

            get { return _enum; }
        }

        #endregion

        #region Private

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnValueChangedHandler()
        {
            if (OnValueChanged != null)
            {
                UEnumEventArgs args = new UEnumEventArgs(this, _enum);
                OnValueChanged(args);
            }
        }

        #endregion
    }
}