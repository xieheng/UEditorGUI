﻿using UnityEngine;
using UnityEditor;

/// <summary>
/// 
/// </summary>
public class UButton : UButtonBase
{
    #region Construction

    /// <summary>
    /// 
    /// </summary>
    public UButton()
    {
        _caption = "Button";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    public UButton(string caption)
    {
        _caption = caption;
    }

    #endregion
}
