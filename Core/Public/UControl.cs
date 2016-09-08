using UnityEngine;

/// <summary>
/// 
/// </summary>
public abstract class UControl : UObject
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    protected GUIStyle _style = GUIStyle.none;

    /// <summary>
    /// 
    /// </summary>
    protected bool _focus = false;

    #endregion

    #region Public

    /// <summary>
    /// 
    /// </summary>
    public virtual void OnFocus()
    {
        _focus = true;
    }

    /// <summary>
    /// 
    /// </summary>
    public virtual void LostFocus()
    {
        _focus = false;
    }

    #endregion
}
