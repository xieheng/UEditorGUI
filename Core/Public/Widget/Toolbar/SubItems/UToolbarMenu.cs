﻿using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

/// <summary>
/// 
/// </summary>
public class UToolbarMenu : UMenu 
{
    #region Construction

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    public UToolbarMenu(string caption)
        : base(caption, EditorStyles.toolbarDropDown)
    {
        _autoSize = false;
    }

    #endregion
}