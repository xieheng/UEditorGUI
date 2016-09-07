using UnityEngine;
using UnityEditor;

/// <summary>
/// 
/// </summary>
public class UColorField : UWidget
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    protected Color _value = Color.white;

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
                _value = EditorGUILayout.ColorField(_caption, _value);
            }
            bool changed = EditorGUI.EndChangeCheck();

            if (changed)
            {
                OnColorChangedHandler();
            }
        }
        GUI.color = Color.white;
    }

    #endregion

    #region Private

    /// <summary>
    /// 
    /// </summary>
    private void OnColorChangedHandler()
    {

    }

    #endregion
}
