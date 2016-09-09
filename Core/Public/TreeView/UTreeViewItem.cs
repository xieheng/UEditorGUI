using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using UEditorGUI.Internal.TreeView;

/// <summary>
/// 
/// </summary>
public class UTreeViewItem
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    protected string _text = "TreeView Item";

    /// <summary>
    /// 
    /// </summary>
    protected UTreeViewItem _parent = null;

    /// <summary>
    /// 
    /// </summary>
    protected int _depth = 0;

    /// <summary>
    /// 
    /// </summary>
    protected List<UTreeViewItemImp> _children = new List<UTreeViewItemImp>();

    #endregion

    #region Construction

    /// <summary>
    /// 
    /// </summary>
    /// <param name="text"></param>
    /// <param name="parent"></param>
    protected UTreeViewItem(string text, UTreeViewItem parent = null)
    {
        _text = text;
        _parent = parent;
        _depth = (_parent == null) ? 0 : _parent._depth + 1;
    }

    #endregion

    #region Public

    /// <summary>
    /// 
    /// </summary>
    /// <param name="child"></param>
    public UTreeViewItem Add(string text)
    {
        UTreeViewItemImp child = new UTreeViewItemImp(text, this);
        _children.Add(child);

        return child;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="child"></param>
    public bool Remove(UTreeViewItemImp item)
    {
        if (_children.Contains(item))
        {
            _children.Remove(item);
            return true;
        }
     
        foreach (UTreeViewItemImp child in _children)
        {
            bool removed = child.Remove(item);
            if (removed)
            {
                return true;
            }
        }

        return false;
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
    public virtual UTreeViewItem Parent
    {
        get { return null;}
    }

    #endregion
}
