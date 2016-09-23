using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class UToggleButton : UCaptionWidget
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
        public UToggleButton()
        {
            caption = "Toggle Button";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        public UToggleButton(string caption)
            : base(caption)
        {
            
        }

        #endregion

        #region Override

        /// <summary>
        /// 
        /// </summary>
        protected override void UpdateGUI()
        {
            style = attachOnToolbar ? EditorStyles.toolbarButton : GUI.skin.GetStyle("Button");
            Rect rect = GUILayoutUtility.GetRect(new GUIContent(caption), style, GUILayout.ExpandWidth(!attachOnToolbar));

            EditorGUI.BeginChangeCheck();
            {
                _toggled = GUI.Toggle(rect, _toggled, string.Empty, style);
            }
            bool changed = EditorGUI.EndChangeCheck();

            GUIStyle labelStyle = EditorStyles.miniLabel;
            labelStyle.alignment = TextAnchor.MiddleCenter;

            GUI.Label(rect, caption, labelStyle);

            if (changed)
            {
                OnToggleChangedHandler();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void ActiveToolbarGuiStyle()
        {
            this.style = EditorStyles.toolbarButton;
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
                bool store = _toggled;
                _toggled = value;

                if (store != _toggled)
                {
                    OnToggleChangedHandler();
                }
            }
            get { return _toggled; }
        }

        #endregion

        #region Private

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnToggleChangedHandler()
        {
            if (OnToggleChanged != null)
            {
                UToggleEventArgs args = new UToggleEventArgs(this, _toggled);
                OnToggleChanged(args);
            }
        }

        #endregion
    }
}