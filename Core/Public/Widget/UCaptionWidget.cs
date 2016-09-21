using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class UCaptionWidget : UColorfulWidget
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    private string _caption = string.Empty;

    #endregion

    #region Construction

    /// <summary>
    /// 
    /// </summary>
    protected UCaptionWidget()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    protected UCaptionWidget(string caption)
    {
        _caption = caption;
    }

    #endregion

    #region Public

    /// <summary>
    /// 
    /// </summary>
    public string caption
    {
        set { _caption = value; }
        get { return _caption; }
    }

    #endregion
}
