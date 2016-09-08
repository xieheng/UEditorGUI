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

    #endregion

    #region Override

    /// <summary>
    /// 
    /// </summary>
    public override void OnGUI()
    {
        EditorGUILayout.BeginVertical(/*EditorStyles.textArea*/);
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
        UTreeViewItemImp child = new UTreeViewItemImp(text, 0);
        _children.Add(child);

        return child;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="child"></param>
    public void Remove(UTreeViewItem child)
    {
        UTreeViewItemImp childImp = child as UTreeViewItemImp;
        _children.Remove(childImp);
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

    #region Private

    /// <summary>
    /// 
    /// </summary>
    private void ProcessKeyboardEvent()
    {

    }

    private void ProcessMouseEvent()
    {

    }

    #endregion
}
