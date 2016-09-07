using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

/// <summary>
/// 
/// </summary>
public class UTreeViewItem
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    private bool _foldout = true;

    /// <summary>
    /// 
    /// </summary>
    private string _text = "TreeView Item";

    /// <summary>
    /// 
    /// </summary>
    private List<UTreeViewItem> _children = new List<UTreeViewItem>();

    #endregion

    #region Public

    /// <summary>
    /// 
    /// </summary>
    public void OnGUI()
    {
        for (int i = 0; i < _children.Count; i++)
        {
            UTreeViewItem child = _children[i];
            child.OnGUI();
        }
    }

    #endregion
}
