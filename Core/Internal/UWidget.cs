using UnityEngine;

/// <summary>
/// 
/// </summary>
public abstract class UWidget : UControl
{
    #region Data
    
    /// <summary>
    /// 
    /// </summary>
    protected string _caption = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    protected Color _color = Color.white;

    #endregion

    #region Public

    /// <summary>
    /// 
    /// </summary>
    public string Caption
    {
        set { _caption = value; }
        get { return _caption; }
    }

    /// <summary>
    /// 
    /// </summary>
    public Color Color
    {
        set { _color = value; }
        get { return _color; }
    }

    #endregion
}
