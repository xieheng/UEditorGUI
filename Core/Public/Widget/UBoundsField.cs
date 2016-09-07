using UnityEngine;
using UnityEditor;

/// <summary>
/// 
/// </summary>
public class UBoundsField : UWidget
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    protected Bounds _bounds = new Bounds();

    #endregion

    #region Override

    /// <summary>
    /// 
    /// </summary>
    public override void OnGUI()
    {
        GUI.color = _color;
        {
            EditorGUI.BeginChangeCheck();
            {
                _bounds = EditorGUILayout.BoundsField(_caption, _bounds);
            }
            bool changed = EditorGUI.EndChangeCheck();

            if (changed)
            {
                OnBoundsChangedHandler();
            }
        }
        GUI.color = Color.white;
    }

    #endregion

    #region Private

    /// <summary>
    /// 
    /// </summary>
    private void OnBoundsChangedHandler()
    {

    }

    #endregion
}
