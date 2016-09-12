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
        /// <param name="parent"></param>
        public UTreeViewItemImp(string text, UTreeViewItem parent = null)
            : base(text, parent)
        {

        }

        #endregion

        #region Public

        /// <summary>
        /// 
        /// </summary>
        public bool IsSelected
        {
            set { _selected = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsFoldout
        {
            set 
            {
                if (_children.Count == 0)
                {
                    _foldout = false;
                }
                else
                {
                    _foldout = value; 
                }
            }
            get { return _foldout; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(UTreeViewItemImp item)
        {
            return _children.IndexOf(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        public void FillChildrenInto(List<UTreeViewItemImp> list)
        {
            if (_foldout)
            {
                foreach (UTreeViewItemImp child in _children)
                {
                    list.Add(child);
                    child.FillChildrenInto(list);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void OnFocus()
        {
            foreach (UTreeViewItemImp child in _children)
            {
                child.OnFocus();
            }

            _focus = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public void LostFocus()
        {
            foreach (UTreeViewItemImp child in _children)
            {
                child.LostFocus();
            }

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public UTreeViewItemImp HitChild(Vector2 pt)
        {
            if (_rect.Contains(pt))
                return this;

            foreach(UTreeViewItemImp child in _children)
            {
                UTreeViewItemImp hit = child.HitChild(pt);
                if (hit != null)
                {
                    return hit;
                }
            }

            return null;
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

            _rect = EditorGUILayout.BeginHorizontal(style);
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
