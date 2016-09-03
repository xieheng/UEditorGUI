using UnityEngine;

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

#region 

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
}

#endregion