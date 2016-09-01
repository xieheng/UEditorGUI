using UnityEngine;
using UnityEditor;

/// <summary>
/// 
/// </summary>
public class UToolbar : UControl
{
    #region Data
    
    /// <summary>
    /// 
    /// </summary>
    private ULayout _layout = new UHLayout();

    #endregion

    #region Override

    /// <summary>
    /// 
    /// </summary>
    public override void OnGUI()
    {
        _layout.OnGUI();
    }

    #endregion
}
