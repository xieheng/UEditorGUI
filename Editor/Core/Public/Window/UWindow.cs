using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class UWindow : EditorWindow
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private ULayout _layout = new UVLayout();

        #endregion

        #region Event
        #endregion

        #region Public

        /// <summary>
        /// 
        /// </summary>
        public string Caption
        {
            set { title = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="widget"></param>
        public void AddWidget(UControl widget)
        {
            _layout.AddWidget(widget);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="layout"></param>
        public void AddLayout(ULayout layout)
        {
            _layout.AddLayout(layout);
        }

        #endregion

        #region Private

        /// <summary>
        /// 
        /// </summary>
        protected UWindow()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnGUI()
        {
            _layout.OnGUI();
            Repaint();
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnFocus()
        {
            _layout.OnFocus();
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnLostFocus()
        {
            _layout.LostFocus();
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnDestroy()
        {

        }

        #endregion

        #region Static

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static void ShowWindow<T>() where T : UWindow
        {
            UWindow win = EditorWindow.GetWindow<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static void ShowWindow<T>(string caption) where T : UWindow
        {
            UWindow win = EditorWindow.GetWindow<T>();
            win.title = caption;
        }

        #endregion
    }
}