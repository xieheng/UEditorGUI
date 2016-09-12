﻿using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using UEditorGUI.Internal.TreeView;

/// <summary>
/// 
/// </summary>
public class UTreeView : UControl
{
    #region Data

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
    private List<UTreeViewItemImp> _selected = new List<UTreeViewItemImp>();

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
        foreach (UTreeViewItemImp child in _children)
        {
            child.OnFocus();
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

        _rect = EditorGUILayout.BeginVertical(/*EditorStyles.textArea*/);
        {
            _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos, GUILayout.ExpandHeight(true));
            {
                for (int i = 0; i < _children.Count; i++)
                {
                    UTreeViewItemImp child = _children[i];
                    child.OnGUI();
                }
            }
            EditorGUILayout.EndScrollView();
        }
        EditorGUILayout.EndVertical();

        ProcessKeyboardEvent();
        ProcessMouseEvent();

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
        UTreeViewItemImp itemImp = item as UTreeViewItemImp;
        RemoveFromSelectedList(itemImp);

        if (_children.Contains(itemImp))
        {
            _children.Remove(itemImp);
        }
        else
        {
            foreach(UTreeViewItemImp child in _children)
            {
                if (child.Remove(itemImp))
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
    public int Count
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
    public UTreeViewItem[] SelectedItems
    {
        get { return _selected.ToArray(); }
    }
    /// <summary>
    /// 
    /// </summary>
    public bool IsMultiSeletion
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

        if (_selected.Count == 0)
        {
            next = _children[0];
        }
        else
        {
            UTreeViewItemImp current = _selected[_selected.Count - 1];

            if (current.IsFoldout)
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
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="item"></param>
    private UTreeViewItemImp MoveNext(UTreeViewItemImp item)
    {
        if (item.Count > 0)
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
        UTreeViewItemImp parent = item.Parent as UTreeViewItemImp;

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
            if (index < parent.Count - 1)
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

        if (_selected.Count == 0)
        {
            prev = _children[0];
        }
        else
        {
            UTreeViewItemImp current = _selected[0];
            UTreeViewItemImp parent = current.Parent as UTreeViewItemImp;

            if (parent == null)//root node
            {
                int index = _children.IndexOf(current);
                if (index > 0)
                {
                    prev = _children[index - 1];

                    if (prev.Count > 0 && prev.IsFoldout)
                    {
                        prev = prev[prev.Count - 1] as UTreeViewItemImp;
                    }
                }
            }
            else//child node
            {
                int index = parent.IndexOf(current);
                if (index > 0)
                {
                    prev = parent[index - 1] as UTreeViewItemImp;

                    if (prev.Count > 0 && prev.IsFoldout)
                    {
                        prev = prev[prev.Count - 1] as UTreeViewItemImp;
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
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="item"></param>
    private void ProcessLeftArrayKey()
    {
        if (_selected.Count == 0)
            return;

        if (_selected.Count == 1)
        {
            UTreeViewItemImp item = _selected[0];

            if (item.IsFoldout)
            {
                item.IsFoldout = false; 
            }
            else
            {
                UTreeViewItemImp parent = item.Parent as UTreeViewItemImp;
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
            foreach (UTreeViewItemImp item in _selected)
            {
                if (item.IsFoldout)
                {
                    item.IsFoldout = HasSelectedChild(item);
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
        if (_selected.Count == 0)
            return;

        if (_selected.Count == 1)
        {
            UTreeViewItemImp item = _selected[0];

            if (!item.IsFoldout)
            {
                item.IsFoldout = true;
            }
            else if (item.Count > 0)
            {
                item.IsSelected = false;
                ClearSelectedList();

                UTreeViewItemImp child = item[0] as UTreeViewItemImp;
                AddToSelectedList(child);

                _selectedChanged = true;
            }
        }
        else
        {
            foreach (UTreeViewItemImp item in _selected)
            {
                if (!item.IsFoldout)
                {
                    item.IsFoldout = true;
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

        for (int i=0; i<item.Count; i++)
        {
            UTreeViewItemImp child = item[i] as UTreeViewItemImp;
            hasSelectedChilld = child.IsSelected ? true : HasSelectedChild(child);

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

        if (curSelected == null && _selected.Count > 0)
        {
            ClearSelectedList();
            Event.current.Use();

            _selectedChanged = true;
            return;
        }
       
        if (_multiSelection && Event.current.shift)
        {
            if (_selected.Count == 0)
            {
                AddToSelectedList(curSelected);
            }
            else
            {
                List<UTreeViewItemImp> list = GetItemsInChildren();

                UTreeViewItemImp first = _selected[0];

                int firstIndex = list.IndexOf(first);
                int currentIndex = list.IndexOf(curSelected);

                int index = Mathf.Min(firstIndex, currentIndex);
                int count = Mathf.Abs(firstIndex - currentIndex) + 1;

                List<UTreeViewItemImp> selectedList = list.GetRange(index, count);
                _selected.Clear();

                foreach (UTreeViewItemImp child in selectedList)
                {
                    child.IsSelected = true;
                }
                _selected.AddRange(selectedList);
            }

            _selectedChanged = true;
        }
        else if (_multiSelection && Event.current.control)
        {
            if (_selected.Contains(curSelected))
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
            if (_selected.Count == 1 && curSelected == _selected[0])
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

        Event.current.Use();
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
        item.IsSelected = true;
        _selected.Add(item);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="item"></param>
    private void RemoveFromSelectedList(UTreeViewItemImp item)
    {
        item.IsSelected = false;
        _selected.Remove(item);
    }

    /// <summary>
    /// 
    /// </summary>
    private void ClearSelectedList()
    {
        foreach (UTreeViewItemImp child in _selected)
        {
            child.IsSelected = false;
        }

        _selected.Clear();
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
