using UnityEngine;
using UnityEditor;

/// <summary>
/// 
/// </summary>
public class UMenuItem
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    private string _caption = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    private bool _enabled = true;

    #endregion

    #region Construction
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    public UMenuItem(string caption)
    {
        _caption = caption;
        _enabled = true;
    }

    #endregion

    #region Public

    /// <summary>
    /// 
    /// </summary>
    public string Caption
    {
        get { return _caption; }
    }

    /// <summary>
    /// 
    /// </summary>
    public bool IsEnabled
    {
        set { _enabled = value; }
        get { return _enabled; }
    }
    
    /// <summary>
    /// 
    /// </summary>
    public void OnClickedHandler()
    {

    }

    #endregion
}
