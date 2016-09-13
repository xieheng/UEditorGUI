using UnityEngine;
using UnityEditor;

/// <summary>
/// 
/// </summary>
public class UVector2Filed : UWidget
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    private Vector2 _vector = Vector2.zero;

    #endregion

    #region Event

    /// <summary>
    /// 
    /// </summary>
    public event UVector2EventHandler OnValueChanged;

    #endregion

    #region Construction

    /// <summary>
    /// 
    /// </summary>
    public UVector2Filed()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    public UVector2Filed(string caption)
    {
        _caption = caption;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="vector"></param>
    public UVector2Filed(Vector2 vector)
    {
        _vector = vector;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    /// <param name="vector"></param>
    public UVector2Filed(string caption, Vector2 vector)
    {
        _caption = caption;
        _vector = vector;
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
                _vector = EditorGUILayout.Vector2Field(_caption, _vector);
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
        if (OnValueChanged != null)
        {
            UVector2EventArgs args = new UVector2EventArgs(this, _vector);
            OnValueChanged(args);
        }
    }

    #endregion
}
