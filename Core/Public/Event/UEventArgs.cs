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

#region UIntEventArgs

/// <summary>
/// 
/// </summary>
public class UIntEventArgs : UEventArgs
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    private int _value = 0;

    #endregion

    #region Construction

    public UIntEventArgs(object sender, int intValue)
        : base(sender)
    {
        _value = intValue;
    }

    #endregion

    #region Public 

    /// <summary>
    /// 
    /// </summary>
    public int Value
    {
        get { return _value; }
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

#region UToggleEventArgs

/// <summary>
/// 
/// </summary>
public class UToggleEventArgs : UEventArgs
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    private bool _toggled = false;

    #endregion

    #region Construction

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="toggled"></param>
    public UToggleEventArgs(object sender, bool toggled)
        : base(sender)
    {
        _toggled = toggled;
    }

    #endregion

    #region Public 

    /// <summary>
    /// 
    /// </summary>
    public bool IsToggled
    {
        get { return _toggled; }
    }

    #endregion
}

#endregion

#region UObjectEventArgs

/// <summary>
/// 
/// </summary>
public class UObjectEventArgs : UEventArgs
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    private System.Object _object = null;

    #endregion

    #region Construction

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="color"></param>
    public UObjectEventArgs(object sender, System.Object value)
        : base(sender)
    {
        _object = value;
    }

    #endregion

    #region Public

    /// <summary>
    /// 
    /// </summary>
    public System.Object Object
    {
        get { return _object; }
    }

    #endregion
}

#endregion

#region UBoundsEventArgs

/// <summary>
/// 
/// </summary>
public class UBoundsEventArgs : UEventArgs
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    private Bounds _bounds = new Bounds();

    #endregion

    #region Construction

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="color"></param>
    public UBoundsEventArgs(object sender, Bounds bounds)
        : base(sender)
    {
        _bounds = bounds;
    }

    #endregion

    #region Public 

    /// <summary>
    /// 
    /// </summary>
    public Bounds Bounds
    {
        get { return _bounds; }
    }

    #endregion
}

#endregion

#region UColorEventArgs

/// <summary>
/// 
/// </summary>
public class UColorEventArgs : UEventArgs
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    private Color _color = Color.white;

    #endregion

    #region Construction

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="color"></param>
    public UColorEventArgs(object sender, Color color)
        : base(sender)
    {
        _color = color;
    }

    #endregion

    #region Public 

    /// <summary>
    /// 
    /// </summary>
    public Color Color
    {
        get { return _color; }
    }

    #endregion
}

#endregion
