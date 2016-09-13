using UnityEngine;
using UnityEditor;

/// <summary>
/// 
/// </summary>
public class URectField : UWidget
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    private Rect _value = new Rect();

    #endregion

    #region Construction

    /// <summary>
    /// 
    /// </summary>
    public URectField()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    public URectField(string caption)
    {
        _caption = caption;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="rect"></param>
    public URectField(Rect rect)
    {
        _value = rect;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    /// <param name="rect"></param>
    public URectField(string caption, Rect rect)
    {
        _caption = caption;
        _value = rect;
    }

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
                _value = EditorGUILayout.RectField(_caption, _value);
            }
            bool changed = EditorGUI.EndChangeCheck();

            if (changed)
            {
                OnValueChangedHandler();
            }
        }
        GUI.color = Color.white;
    }

    #endregion

    #region Private 

    /// <summary>
    /// 
    /// </summary>
    private void OnValueChangedHandler()
    {

    }

    #endregion
}
