using UnityEngine;
using UnityEditor;

public abstract class UInspector : Editor
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    private ULayout _layout = new UVLayout();

    #endregion

    #region Public

    /// <summary>
    /// 
    /// </summary>
    public override void OnInspectorGUI()
    {
        _layout.OnGUI();
        Repaint();
    }

    #endregion
}
