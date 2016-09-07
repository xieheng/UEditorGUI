using UnityEngine;
using UnityEditor;
using UEditorGUI.Internal.Menu;

/// <summary>
/// 
/// </summary>
public class UMenuSeparator : UMenuSub
{
    #region Override

    /// <summary>
    /// 
    /// </summary>
    public override void OnGUI()
    {
        if (!_visible)
            return;

        if (_parent != null)
        {
            _parent.AddSeparator(string.Empty);
        }
    }

    #endregion
}
