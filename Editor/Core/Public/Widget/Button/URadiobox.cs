using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    public class URadiobox : UCaptionWidget
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private bool _toggled = false;

        #endregion

        #region Event

        /// <summary>
        /// 
        /// </summary>
        public event UToggleChangedEventHandler OnToggleChanged;

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        public URadiobox()
            : this("Radiobox")
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        public URadiobox(string caption)
            : base(caption)
        {

        }

        #endregion

        #region Public

        /// <summary>
        /// 
        /// </summary>
        public bool toggled
        {
            set
            {
                if (_toggled != value)
                {
                    _toggled = value;

                    if (OnToggleChanged != null)
                    {
                        OnToggleChanged(new UToggleEventArgs(this, toggled));
                    }
                }
            }
            get { return _toggled; }
        }

        #endregion

        #region Override

        /// <summary>
        /// 
        /// </summary>
        protected override void UpdateGUI()
        {
            toggled = EditorGUILayout.Toggle(content, toggled, EditorStyles.radioButton);
        }

        #endregion
    }
}