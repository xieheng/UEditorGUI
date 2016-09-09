using UnityEngine;
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
        _selected.Remove(itemImp);

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
        _selected.Remove(item);

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

    #endregion

    #region Private

    /// <summary>
    /// 
    /// </summary>
    private void ProcessKeyboardEvent()
    {
        if (Event.current.type == EventType.KeyDown)
        {
            switch (Event.current.keyCode)
            {
                case KeyCode.DownArrow:
                    break;
                case KeyCode.UpArrow:
                    break;
                case KeyCode.LeftArrow:
                    break;
                case KeyCode.RightArrow:
                    break;
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
            UTreeViewItemImp curSelected = null;
            Vector2 mousePt = Event.current.mousePosition - new Vector2(_rect.x, _rect.y);

            foreach (UTreeViewItemImp child in _children)
            {
                curSelected = child.HitChild(mousePt);
                if (curSelected != null)
                {
                    break;
                }
            }

            if (curSelected == null)
            {
                ClearSelectedList();
                Event.current.Use();

                return;
            }
           
            if (Event.current.shift)
            {
                if (_selected.Count == 0)
                {
                    curSelected.IsSelected = true;
                    _selected.Add(curSelected);
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
            }
            else if (Event.current.control)
            {
                if (_selected.Contains(curSelected))
                {
                    curSelected.IsSelected = false;
                    _selected.Remove(curSelected);
                }
                else
                {
                    curSelected.IsSelected = true;
                    _selected.Add(curSelected);
                }
            }
            else 
            {
                ClearSelectedList();

                curSelected.IsSelected = true;
                _selected.Add(curSelected);
            }

            Event.current.Use();
        }
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

    #endregion
}
