using UnityEngine;
using System;

#region UEventArgs

/// <summary>
/// 
/// </summary>
public class UEventArgs
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    private object _sender = null;

    #endregion

    #region Construction

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    public UEventArgs(object sender)
    {
        _sender = sender;
    }

    #endregion

    #region Public 

    /// <summary>
    /// 
    /// </summary>
    public object Sender
    {
        get { return _sender; }
    }

    #endregion
}

#endregion

#region UTextEventArgs

/// <summary>
/// 
/// </summary>
public class UTextEventArgs : UEventArgs
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    private string _text = string.Empty;

    #endregion

    #region Construction

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="text"></param>
    public UTextEventArgs(object sender, string text)
        : base(sender)
    {
        _text = text;
    }

    #endregion

    #region Public 

    /// <summary>
    /// 
    /// </summary>
    public string Text
    {
        get { return _text; }
    }

    #endregion
}

#endregion

#region UEnumEventArgs 

/// <summary>
/// 
/// </summary>
public class UEnumEventArgs : UEventArgs
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    private System.Enum _enum = null;

    #endregion

    #region Construction

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="text"></param>
    public UEnumEventArgs(object sender, System.Enum enumValue)
        : base(sender)
    {
        _enum = enumValue;
    }

    #endregion

    #region Public 

    /// <summary>
    /// 
    /// </summary>
    public System.Enum Value
    {
        get { return _enum; }
    }

    #endregion
}

#endregion