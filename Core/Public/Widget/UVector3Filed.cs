using UnityEngine;
using UnityEditor;

/// <summary>
/// 
/// </summary>
public class UVector3Filed : UCaptionWidget
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    private Vector3 _vector = Vector3.zero;

    #endregion

    #region Event

    /// <summary>
    /// 
    /// </summary>
    public event UVector3EventHandler OnValueChanged;

    #endregion

    #region Construction

    /// <summary>
    /// 
    /// </summary>
    public UVector3Filed()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    public UVector3Filed(string caption)
        : base(caption)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="vector"></param>
    public UVector3Filed(Vector3 vector)
    {
        _vector = vector;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    /// <param name="vector"></param>
    public UVector3Filed(string caption, Vector3 vector)
        : base(caption)
    {
        _vector = vector;
    }

    #endregion

    #region Override

    /// <summary>
    /// 
    /// </summary>
    public override void OnGUI()
    {
        EditorGUI.BeginChangeCheck();
        {
            _vector = EditorGUILayout.Vector3Field(caption, _vector);
        }
        bool changed = EditorGUI.EndChangeCheck();

        if (changed)
        {
            OnValueChangedHandler();
        }
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
            UVector3EventArgs args = new UVector3EventArgs(this, _vector);
            OnValueChanged(args);
        }
    }

    #endregion
}
