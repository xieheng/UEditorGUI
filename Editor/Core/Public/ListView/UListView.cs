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

        #region Event

        /// <summary>
        /// 
        /// </summary>
        public event UEventHandler OnSelectionChanged;

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
            if (_hasFocus)
            { 
                ProcessKeyboardEvent(); 
            }
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
        private void ProcessKeyboardEvent()
        {
            if (_children.Count == 0)
                return;

            if (Event.current.type == EventType.KeyDown)
            {
                if (Event.current.keyCode == KeyCode.DownArrow)
                {
                    if (_selections.Count == 0)
                    {
                        UListViewItemImp child = _children[0];
                        child.selected = true;
                        _selections.Add(child);
                    }
                    else
                    {
                        UListViewItemImp lastItem = _selections[_selections.Count - 1];
                        int index = _children.IndexOf(lastItem);

                        if (index < _children.Count - 1)
                        {
                            ClearSelectedList();

                            UListViewItemImp item = _children[index + 1];
                            item.selected = true;
                            _selections.Add(item);
                        }
                    }
                }
                else if (Event.current.keyCode == KeyCode.UpArrow)
                {
                    if (_selections.Count == 0)
                    {
                        UListViewItemImp child = _children[0];
                        child.selected = true;
                        _selections.Add(child);
                    }
                    else
                    {
                        UListViewItemImp firstItem = _selections[0];
                        int index = _children.IndexOf(firstItem);

                        if (index > 0)
                        {
                            ClearSelectedList();

                            UListViewItemImp item = _children[index - 1];
                            item.selected = true;
                            _selections.Add(item);
                        }
                    }
                }
                else
                {
                    //
                }

                Event.current.Use();
            }
        }

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
            bool selectionChanged = false;
            Vector2 mousePt = Event.current.mousePosition - new Vector2(_rect.x, _rect.y) + _scrollPos;

            foreach (UListViewItemImp child in _children)
            {
                if (child.Hit(mousePt))
                {
                    if (Event.current.control)
                    {
                        child.selected = !child.selected;
                        if (child.selected)
                        {
                            _selections.Add(child);
                        }
                        else
                        {
                            _selections.Remove(child);
                        }
                        selectionChanged = true;
                    }
                    else if (Event.current.shift)
                    {
                        int selectionCount = _selections.Count;

                        if (_selections.Count == 0)
                        {
                            child.selected = true;
                            _selections.Add(child);
                        }
                        else
                        {
                            UListViewItemImp first = _selections[0];

                            int firstIdx = _children.IndexOf(first);
                            int childIdx = _children.IndexOf(child);

                            ClearSelectedList();

                            int index = Mathf.Min(firstIdx, childIdx);
                            int count = Mathf.Abs(firstIdx - childIdx) + 1;
                            for (int i=0; i<count; i++)
                            {
                                UListViewItemImp item = _children[index + i];
                                item.selected = true;
                                _selections.Add(item);
                            }
                        }

                        if (_selections.Count != selectionCount)
                        {
                            selectionChanged = true;
                        }
                    }
                    else
                    {
                        ClearSelectedList();

                        child.selected = !child.selected;
                        if (child.selected)
                        {
                            _selections.Add(child);
                        }
                        selectionChanged = true;
                    }

                    if (selectionChanged)
                    {
                        //Debug.Log("listview selection changed");
                        if (OnSelectionChanged != null)
                        {
                            OnSelectionChanged(new UEventArgs(this));
                        }
                    }
                    //Event.current.Use();
                    return;
                }
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