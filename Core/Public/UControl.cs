using UnityEngine;

/// <summary>
/// 
/// </summary>
public abstract class UControl : UPanel
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    private GUIStyle _style = GUIStyle.none;

    #endregion

    #region Privte

    /// <summary>
    /// 
    /// </summary>
    protected GUIStyle style
    {
        set { _style = value; }
        get { return _style; }
    }

    #endregion
}
