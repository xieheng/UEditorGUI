using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UEditorGUI.Internal.ListView;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class UListView : UControl
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private bool _hasFocus = false;

        /// <summary>
        /// 
        /// </summary>
        private Vector2 _scrollPos = Vector2.zero;

        /// <summary>
        /// 
        /// </summary>
        private Rect _rect = new Rect();

        /// <summary>
        /// 
        /// </summary>
        private List<UListViewItemImp> _children = new List<UListViewItemImp>();

        /// <summary>
        /// 
        /// </summary>
        private List<UListViewItemImp> _selections = new List<UListViewItemImp>();

        #endregion

        #region Override

        /// <summary>
        /// 
        /// </summary>
        public override void OnFocus()
        {
            if (_hasFocus)
            {
                foreach (UListViewItemImp child in _children)
                {
                    child.OnFocus();
                }
            }

            base.OnFocus();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void LostFocus()
        {
            foreach(UListViewItemImp child in _children)
            {
                child.LostFocus();
            }

            base.LostFocus();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void OnGUI()
        {
            EditorGUILayout.BeginVertical("box");
            {
                _scrollPos = GUILayout.BeginScrollView(_scrollPos, GUILayout.ExpandHeight(true));
                {
                    foreach (UListViewItemImp child in _children)
                    {
                        child.OnGUI();
                    }
                }
                GUILayout.EndScrollView();

                _rect = GUILayoutUtility.GetLastRect();
            }
            EditorGUILayout.EndVertical();

            ProcessMouseEvent();
        }

        #endregion

        #region Public

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public UListViewItem Add(string text)
        {
            UListViewItemImp child = new UListViewItemImp(text);
            _children.Add(child);

            return child;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Remove(UListViewItem item)
        {
            UListViewItemImp imp = item as UListViewItemImp;
            if (_children.Contains(imp))
            {
                _children.Remove(imp);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            _children.RemoveAt(index);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            _children.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        public int count
        {
            get { return 0; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public UListViewItem this[int index]
        {
            get { return _children[index]; }
        }

        #endregion

        #region Private

        /// <summary>
        /// 
        /// </summary>
        private void ProcessMouseEvent()
        {
            if (Event.current.type == EventType.MouseUp)
            {
                if (!_rect.Contains(Event.current.mousePosition))
                {
                    _hasFocus = false;
                    ClearSelectedList();
                    LostFocus();
                }
                else
                {
                    _hasFocus = true;
                    OnFocus();

                    if (Event.current.button == 0)
                    {
                        ProcessLeftMouseButton();
                    }
                    else if (Event.current.button == 1)
                    {
                        ProcessRightMouseButton();
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ProcessLeftMouseButton()
        {
            Vector2 mousePt = Event.current.mousePosition - new Vector2(_rect.x, _rect.y) + _scrollPos;

            foreach (UListViewItemImp child in _children)
            {
                if (child.Hit(mousePt))
                {
                    if (!Event.current.shift && !Event.current.control)
                    {
                        ClearSelectedList();
                    }
                    //Event.current.Use();

                    child.selected = !child.selected;
                    if (child.selected)
                    {
                        _selections.Add(child);
                    }

                    return;
                }
            }

            if (_selections.Count > 0)
            {
                //event...
            }

            ClearSelectedList();
        }

        /// <summary>
        /// 
        /// </summary>
        private void ProcessRightMouseButton()
        {
            Vector2 mousePt = Event.current.mousePosition - new Vector2(_rect.x, _rect.y) + _scrollPos;
        }

        /// <summary>
        /// 
        /// </summary>
        private void ClearSelectedList()
        {
            foreach (UListViewItemImp child in _selections)
            {
                child.selected = false;
            }

            _selections.Clear();
        }

        #endregion
    }
}