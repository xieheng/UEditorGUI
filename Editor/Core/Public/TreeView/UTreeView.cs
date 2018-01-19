using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using UEditorGUI.Internal.TreeView;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class UTreeView : UControl
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
        private List<UTreeViewItemImp> _children = new List<UTreeViewItemImp>();

        /// <summary>
        /// 
        /// </summary>
        private List<UTreeViewItemImp> _selections = new List<UTreeViewItemImp>();

        /// <summary>
        /// 
        /// </summary>
        private Rect _rect = new Rect();

        /// <summary>
        /// 
        /// </summary>
        private bool _multiSelection = true;

        /// <summary>
        /// 
        /// </summary>
        private bool _selectedChanged = false;

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
                foreach (UTreeViewItemImp child in _children)
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
            foreach (UTreeViewItemImp child in _children)
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
            _selectedChanged = false;

            EditorGUILayout.BeginVertical("box");
            {
                _scrollPos = GUILayout.BeginScrollView(_scrollPos, GUILayout.ExpandHeight(true));
                {
                    for (int i = 0; i < _children.Count; i++)
                    {
                        UTreeViewItemImp child = _children[i];
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

            if (_selectedChanged)
            {
                OnSelectionChangedHandler();
            }
        }

        #endregion

        #region Public

        /// <summary>
        /// 
        /// </summary>
        /// <param name="child"></param>
        public UTreeViewItem Add(string text)
        {
            UTreeViewItemImp child = new UTreeViewItemImp(text);
            _children.Add(child);

            return child;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="child"></param>
        public void Remove(UTreeViewItem item)
        {
            UTreeViewItemImp imp = item as UTreeViewItemImp;
            RemoveFromSelectedList(imp);

            if (_children.Contains(imp))
            {
                _children.Remove(imp);
            }
            else
            {
                foreach (UTreeViewItemImp child in _children)
                {
                    if (child.Remove(imp))
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            UTreeViewItemImp item = _children[index];
            RemoveFromSelectedList(item);

            _children.RemoveAt(index);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            ClearSelectedList();
            _children.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        public int count
        {
            get { return _children.Count; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public UTreeViewItem this[int index]
        {
            get { return _children[index]; }
        }

        /// <summary>
        /// 
        /// </summary>
        public UTreeViewItem[] selections
        {
            get { return _selections.ToArray(); }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool multiSeletion
        {
            set { _multiSelection = value; }
            get { return _multiSelection; }
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
                switch (Event.current.keyCode)
                {
                    case KeyCode.DownArrow:
                        ProcessDownArrayKey();
                        break;
                    case KeyCode.UpArrow:
                        ProcessUpArrayKey();
                        break;
                    case KeyCode.LeftArrow:
                        ProcessLeftArrayKey();
                        break;
                    case KeyCode.RightArrow:
                        ProcessRightArrayKey();
                        break;
                }

                Event.current.Use();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        private void ProcessDownArrayKey()
        {
            UTreeViewItemImp next = null;

            if (_selections.Count == 0)
            {
                next = _children[0];
            }
            else
            {
                UTreeViewItemImp current = _selections[_selections.Count - 1];

                if (current.foldout)
                {
                    next = MoveNext(current);
                }
                else
                {
                    next = MoveNextInParent(current);
                }
            }

            if (next != null)
            {
                ClearSelectedList();
                AddToSelectedList(next);

                _selectedChanged = true;

                if (next.rect.y + next.rect.height >= _rect.height + _scrollPos.y)
                {
                    _scrollPos.y += next.rect.height;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        private UTreeViewItemImp MoveNext(UTreeViewItemImp item)
        {
            if (item.count > 0)
            {
                return item[0] as UTreeViewItemImp;
            }

            return item;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        private UTreeViewItemImp MoveNextInParent(UTreeViewItemImp item)
        {
            UTreeViewItemImp parent = item.parent as UTreeViewItemImp;

            if (parent == null)//root node
            {
                int index = _children.IndexOf(item);
                if (index < _children.Count - 1)
                {
                    return _children[index + 1];
                }
            }
            else//child node
            {
                int index = parent.IndexOf(item);
                if (index < parent.count - 1)
                {
                    return parent[index + 1] as UTreeViewItemImp;
                }
                else
                {
                    return MoveNextInParent(parent);
                }
            }

            return item;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        private void ProcessUpArrayKey()
        {
            UTreeViewItemImp prev = null;

            if (_selections.Count == 0)
            {
                prev = _children[0];
            }
            else
            {
                UTreeViewItemImp current = _selections[0];
                UTreeViewItemImp parent = current.parent as UTreeViewItemImp;

                if (parent == null)//root node
                {
                    int index = _children.IndexOf(current);
                    if (index > 0)
                    {
                        prev = _children[index - 1];

                        if (prev.count > 0 && prev.foldout)
                        {
                            prev = prev[prev.count - 1] as UTreeViewItemImp;
                        }
                    }
                }
                else//child node
                {
                    int index = parent.IndexOf(current);
                    if (index > 0)
                    {
                        prev = parent[index - 1] as UTreeViewItemImp;

                        if (prev.count > 0 && prev.foldout)
                        {
                            prev = prev[prev.count - 1] as UTreeViewItemImp;
                        }
                    }
                    else
                    {
                        prev = parent;
                    }
                }
            }

            if (prev != null)
            {
                ClearSelectedList();
                AddToSelectedList(prev);

                _selectedChanged = true;

                if (prev.rect.y  < _scrollPos.y)
                {
                    _scrollPos.y -= prev.rect.height;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        private void ProcessLeftArrayKey()
        {
            if (_selections.Count == 0)
                return;

            if (_selections.Count == 1)
            {
                UTreeViewItemImp item = _selections[0];

                if (item.foldout)
                {
                    item.foldout = false;
                }
                else
                {
                    UTreeViewItemImp parent = item.parent as UTreeViewItemImp;
                    if (parent != null)
                    {
                        ClearSelectedList();
                        AddToSelectedList(parent);

                        _selectedChanged = true;
                    }
                }
            }
            else
            {
                foreach (UTreeViewItemImp item in _selections)
                {
                    if (item.foldout)
                    {
                        item.foldout = HasSelectedChild(item);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        private void ProcessRightArrayKey()
        {
            if (_selections.Count == 0)
                return;

            if (_selections.Count == 1)
            {
                UTreeViewItemImp item = _selections[0];

                if (!item.foldout)
                {
                    item.foldout = true;
                }
                else if (item.count > 0)
                {
                    item.selected = false;
                    ClearSelectedList();

                    UTreeViewItemImp child = item[0] as UTreeViewItemImp;
                    AddToSelectedList(child);

                    _selectedChanged = true;
                }
            }
            else
            {
                foreach (UTreeViewItemImp item in _selections)
                {
                    if (!item.foldout)
                    {
                        item.foldout = true;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool HasSelectedChild(UTreeViewItemImp item)
        {
            bool hasSelectedChilld = false;

            for (int i = 0; i < item.count; i++)
            {
                UTreeViewItemImp child = item[i] as UTreeViewItemImp;
                hasSelectedChilld = child.selected ? true : HasSelectedChild(child);

                if (hasSelectedChilld)
                {
                    break;
                }
            }

            return hasSelectedChilld;
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
            UTreeViewItemImp curSelected = null;
            Vector2 mousePt = Event.current.mousePosition - new Vector2(_rect.x, _rect.y) + _scrollPos;

            foreach (UTreeViewItemImp child in _children)
            {
                curSelected = child.HitChild(mousePt);
                if (curSelected != null)
                {
                    break;
                }
            }

            if (curSelected == null && _selections.Count > 0)
            {
                ClearSelectedList();
                //Event.current.Use();

                _selectedChanged = true;
                return;
            }

            if (_multiSelection && Event.current.shift)
            {
                if (_selections.Count == 0)
                {
                    AddToSelectedList(curSelected);
                }
                else
                {
                    List<UTreeViewItemImp> list = GetItemsInChildren();

                    UTreeViewItemImp first = _selections[0];

                    int firstIndex = list.IndexOf(first);
                    int currentIndex = list.IndexOf(curSelected);

                    int index = Mathf.Min(firstIndex, currentIndex);
                    int count = Mathf.Abs(firstIndex - currentIndex) + 1;

                    List<UTreeViewItemImp> selectedList = list.GetRange(index, count);
                    _selections.Clear();

                    foreach (UTreeViewItemImp child in selectedList)
                    {
                        child.selected = true;
                    }
                    _selections.AddRange(selectedList);
                }

                _selectedChanged = true;
            }
            else if (_multiSelection && Event.current.control)
            {
                if (_selections.Contains(curSelected))
                {
                    RemoveFromSelectedList(curSelected);
                }
                else
                {
                    AddToSelectedList(curSelected);
                }

                _selectedChanged = true;
            }
            else
            {
                if (_selections.Count == 1 && curSelected == _selections[0])
                {
                    //_selectedChanged = false;
                }
                else
                {
                    ClearSelectedList();
                    AddToSelectedList(curSelected);

                    _selectedChanged = true;
                }
            }

            //Event.current.Use();
        }

        /// <summary>
        /// 
        /// </summary>
        private void ProcessRightMouseButton()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        private void AddToSelectedList(UTreeViewItemImp item)
        {
            if (item != null)
            {
                item.selected = true;
                _selections.Add(item);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        private void RemoveFromSelectedList(UTreeViewItemImp item)
        {
            item.selected = false;
            _selections.Remove(item);
        }

        /// <summary>
        /// 
        /// </summary>
        private void ClearSelectedList()
        {
            foreach (UTreeViewItemImp child in _selections)
            {
                child.selected = false;
            }

            _selections.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        private List<UTreeViewItemImp> GetItemsInChildren()
        {
            List<UTreeViewItemImp> list = new List<UTreeViewItemImp>();

            foreach (UTreeViewItemImp child in _children)
            {
                list.Add(child);
                child.FillChildrenInto(list);
            }

            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnSelectionChangedHandler()
        {
            if (OnSelectionChanged != null)
            {
                UEventArgs args = new UEventArgs(this);
                OnSelectionChanged(args);
            }
        }

        #endregion
    }
}