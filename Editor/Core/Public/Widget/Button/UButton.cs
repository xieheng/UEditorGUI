using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class UButton : UCaptionWidget
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        public enum Style
        {
            /// <summary>
            /// 
            /// </summary>
            Normal,

            /// <summary>
            /// 
            /// </summary>
            Left,

            /// <summary>
            /// 
            /// </summary>
            Middle,

            /// <summary>
            /// 
            /// </summary>
            Right,

            /// <summary>
            /// 
            /// </summary>
            Mini,

            /// <summary>
            /// 
            /// </summary>
            MiniLeft,

            /// <summary>
            /// 
            /// </summary>
            MiniMiddle,

            /// <summary>
            /// 
            /// </summary>
            MiniRight
        }

        /// <summary>
        /// 
        /// </summary>
        private static GUIStyle[] _stylesheet = null;

        #endregion

        #region Event

        /// <summary>
        /// 
        /// </summary>
        public event UEventHandler OnClicked;

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        public UButton()
            : this("Button")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        public UButton(string caption)
            : this(caption, Style.Normal)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="style"></param>
        public UButton(string caption, Style style)
            : base(caption)
        {
            this.style = GetStyle((int)style);
        }

        #endregion

        #region Override

        /// <summary>
        /// 
        /// </summary>
        protected override void UpdateGUI()
        {
            if (GUILayout.Button(content, style))
            {
                OnClickedHandler();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void ActiveToolbarGuiStyle()
        {
            this.style = GetStyle(8);
        }

        #endregion

        #region Private

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnClickedHandler()
        {
            if (OnClicked != null)
            {
                UEventArgs args = new UEventArgs(this);
                OnClicked(args);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        private static GUIStyle GetStyle(int styleIndex)
        {
            if (_stylesheet == null)
            {
                _stylesheet = new GUIStyle[9]{ new GUIStyle("button"),
                                               new GUIStyle("buttonleft"),
                                               new GUIStyle("buttonmid"),
                                               new GUIStyle("buttonright"),
                                               EditorStyles.miniButton,
                                               EditorStyles.miniButtonLeft,
                                               EditorStyles.miniButtonMid,
                                               EditorStyles.miniButtonRight,
                                               EditorStyles.toolbarButton };
            }

            return _stylesheet[styleIndex];
        }

        #endregion
    }
}