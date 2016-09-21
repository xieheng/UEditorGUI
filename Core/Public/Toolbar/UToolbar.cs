using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

/// <summary>
/// 
/// </summary>
public class UToolbar : UControl
{
    #region Enum

    /// <summary>
    /// 
    /// </summary>
    public enum Alignment
    {
        /// <summary>
        /// 
        /// </summary>
        Left,

        /// <summary>
        /// 
        /// </summary>
        Right
    }

    #endregion

    #region Data

    /// <summary>
    /// 
    /// </summary>
    private List<UWidget> _leftItems = new List<UWidget>();

    /// <summary>
    /// 
    /// </summary>
    private List<UWidget> _rightItems = new List<UWidget>();

    #endregion

    #region Override

    /// <summary>
    /// 
    /// </summary>
    public override void OnGUI()
    {
        if (!visible)
            return;

        if (_leftItems.Count == 0 && _rightItems.Count == 0)
            return;

        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar, GUILayout.ExpandWidth(true));
        {
            for (int i = 0; i < _leftItems.Count; i++)
            {
                _leftItems[i].OnGUI();
            }

            GUILayout.FlexibleSpace();

            for (int i = 0; i < _rightItems.Count; i++)
            {
                _rightItems[i].OnGUI();
            }

        }
        EditorGUILayout.EndHorizontal();
    }

    #endregion

    #region Public

    /// <summary>
    /// 
    /// </summary>
    /// <param name="widget"></param>
    /// <param name="alignment"></param>
    public void AddWidget(UWidget widget, Alignment alignment = Alignment.Left)
    {
        if (alignment == Alignment.Left)
        {
            _leftItems.Add(widget);
        }
        else
        {
            _rightItems.Add(widget);
        }

        UControl.ActiveToolbarGuiStyle(widget);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="widget"></param>
    public void RemoveWidget(UWidget widget)
    {
        _leftItems.Remove(widget);
        _rightItems.Remove(widget);

        UControl.UnActiveToolbarGuiStyle(widget);
    }

    #endregion
}
