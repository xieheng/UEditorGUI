using UnityEngine;
using UnityEditor;

/// <summary>
/// 
/// </summary>
public abstract class UMenuSub : UControl
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    protected GenericMenu _parent = null;

    #endregion

    #region Public

    /// <summary>
    /// 
    /// </summary>
    /// <param name="parent"></param>
    public void SetParent(GenericMenu parent)
    {
        _parent = parent;
    }

    #endregion
}