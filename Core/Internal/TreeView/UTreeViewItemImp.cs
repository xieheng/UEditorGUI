using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using UEditorGUI.Internal.Styles;

namespace UEditorGUI.Internal.TreeView
{
    /// <summary>
    /// 
    /// </summary>
    public class UTreeViewItemImp : UTreeViewItem
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private bool _foldout = true;

        /// <summary>
        /// 
        /// </summary>
        private bool _focus = false;

        /// <summary>
        /// 
        /// </summary>
        private bool _selected = false;

        /// <summary>
        /// 
        /// </summary>
        private Rect _rect = new Rect();

        /// <summary>
        /// 
        /// </summary>
        private const int INDENT_SPACE = 16;
        
        /// <summary>
        /// 
        /// </summary>
        private const int IMAGE_SPACE = 16;

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public UTreeViewItemImp(string text, int depth)
        {
            _text = text;
            _depth = depth;
        }

        #endregion

        #region Public

        /// <summary>
        /// 
        /// </summary>
        public bool IsContains(Vector2 pt)
        {
            return _rect.Contains(pt);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        public int IndexOf(UTreeViewItemImp child)
        {
            return _children.IndexOf(child);
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsSelected
        {
            set { _selected = value; }
            get { return _selected; }
        }

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
            DrawChildren();
        }

        #endregion

        #region Private

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
                int indent = _depth * INDENT_SPACE;

                if (_children.Count == 0)
                {
                    GUILayout.Space(indent + IMAGE_SPACE);
                }
                else
                {
                    GUILayout.Space(indent);
                    _foldout = GUILayout.Toggle(_foldout, string.Empty, UEditorStylesHelper.GetStyle("TreeviewItemFoldout"));
                }

                GUILayout.Label(_text);
            }
            EditorGUILayout.EndHorizontal();
        }

        /// <summary>
        /// 
        /// </summary>
        private void DrawChildren()
        {
            if (!_foldout)
                return;

            for (int i = 0; i < _children.Count; i++)
            {
                UTreeViewItemImp child = _children[i];
                child.OnGUI();
            }
        }

        #endregion
    }
}
