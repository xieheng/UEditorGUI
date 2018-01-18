using UnityEngine;
using UnityEditor;
using UEditorGUI.Internal.Styles;

namespace UEditorGUI.Internal.ListView
{
    /// <summary>
    /// 
    /// </summary>
    public class UListViewItemImp : UListViewItem
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private Rect _rect = new Rect();

        /// <summary>
        /// 
        /// </summary>
        private bool _selected = false;

        /// <summary>
        /// 
        /// </summary>
        private bool _focus = false;

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public UListViewItemImp(string text)
            : base(text)
        {

        }

        #endregion

        #region Public

        /// <summary>
        /// 
        /// </summary>
        public void OnFocus()
        {
            _focus = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public void LostFocus()
        {
            _focus = false;
        }

        /// <summary>
        /// 
        /// </summary>
        public void OnGUI()
        {
            Draw();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public bool Hit(Vector2 pt)
        {
            return rect.Contains(pt);
        }

        /// <summary>
        /// 
        /// </summary>
        public Rect rect
        {
            get { return _rect; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool selected
        {
            set { _selected = value; }
            get { return _selected; }
        }

        #endregion

        #region Private

        /// <summary>
        /// 
        /// </summary>
        private void Draw()
        {
            GUIStyle style = UEditorStylesHelper.GetStyle("TreeviewItemUnseleted");

            if (_selected)
            {
                if (_focus)
                {
                    style = UEditorStylesHelper.GetStyle("TreeviewItemSeletedBlue");
                }
                else
                {
                    style = UEditorStylesHelper.GetStyle("TreeviewItemSeletedGrey");
                }
            }

            _rect = EditorGUILayout.BeginHorizontal(style, GUILayout.ExpandWidth(true));
            {
                GUILayout.Label(_text);
            }
            EditorGUILayout.EndHorizontal();
        }

        #endregion
    }
}