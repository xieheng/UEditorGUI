﻿using UnityEngine;
using UnityEditor;

/// <summary>
/// 
/// </summary>
public class UToolbarTextField : UTextFieldBase
{
    #region Construction

    /// <summary>
    /// 
    /// </summary>
    public UToolbarTextField()
        : base(EditorStyles.toolbarTextField)
    {
        _autoSize = false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    /// <param name="alignment"></param>
    public UToolbarTextField(string caption)
        : base(EditorStyles.toolbarTextField)
    {
        _autoSize = false;
        _caption = caption;
    }

    #endregion
}