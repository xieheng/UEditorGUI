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
    protected List<UTreeViewItemImp> _children = new List<UTreeViewItemImp>();

    #endregion

    #region Public

    /// <summary>
    /// 
    /// </summary>
    /// <param name="child"></param>
    public UTreeViewItem Add(string text)
    {
        UTreeViewItemImp child = new UTreeViewItemImp();
        child._text = text;
        _children.Add(child);

        return child;
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

    #endregion
}
