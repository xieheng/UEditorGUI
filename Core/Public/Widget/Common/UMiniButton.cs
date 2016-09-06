using UnityEngine;
using UnityEditor;

public class UMiniButton : UButton
{
    #region Construction

    /// <summary>
    /// 
    /// </summary>
    public UMiniButton()
        : base("Mini Button", EditorStyles.miniButton)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    public UMiniButton(string caption)
        : base(caption, EditorStyles.miniButton)
    {
    }

    #endregion
}
