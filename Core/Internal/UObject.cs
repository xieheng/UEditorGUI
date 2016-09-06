using UnityEngine;

/// <summary>
/// 
/// </summary>
public abstract class UObject
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    protected bool _visible = true;

    #endregion

    #region Public

    /// <summary>
    /// 
    /// </summary>
    public bool IsVisibled
    {
        set { _visible = value; }
        get { return _visible; }
    }

    #endregion

    #region Abstract

    /// <summary>
    /// 
    /// </summary>
    public abstract void OnGUI();

    #endregion
}

