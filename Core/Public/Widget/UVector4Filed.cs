using UnityEngine;
using UnityEditor;

/// <summary>
/// 
/// </summary>
public class UVector4Filed : UWidget
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    private Vector4 _vector = Vector4.zero;

    #endregion

    #region Event

    /// <summary>
    /// 
    /// </summary>
    public event UVector4EventHandler OnValueChanged;

    #endregion

    #region Construction

    /// <summary>
    /// 
    /// </summary>
    public UVector4Filed()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    public UVector4Filed(string caption)
    {
        _caption = caption;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="vector"></param>
    public UVector4Filed(Vector4 vector)
    {
        _vector = vector;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    /// <param name="vector"></param>
    public UVector4Filed(string caption, Vector4 vector)
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
                _vector = EditorGUILayout.Vector4Field(_caption, _vector);
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
            UVector4EventArgs args = new UVector4EventArgs(this, _vector);
            OnValueChanged(args);
        }
    }

    #endregion
}
