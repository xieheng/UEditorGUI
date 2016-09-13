using UnityEngine;
using UnityEditor;

/// <summary>
/// 
/// </summary>
public class UAnimationCurveField : UWidget
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    private AnimationCurve _curve = null;

    #endregion

    #region Event

    /// <summary>
    /// 
    /// </summary>
    public event UAnimationCurveEventHandler OnCurveChanged;

    #endregion

    #region Construction

    /// <summary>
    /// 
    /// </summary>
    public UAnimationCurveField()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    public UAnimationCurveField(string caption)
    {
        _caption = caption;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="curve"></param>
    public UAnimationCurveField(AnimationCurve curve)
    {
        _curve = curve;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    /// <param name="curve"></param>
    public UAnimationCurveField(string caption, AnimationCurve curve)
    {
        _caption = caption;
        _curve = curve;
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
                _curve = EditorGUILayout.CurveField(_caption, _curve);
            }
            bool changed = EditorGUI.EndChangeCheck();

            if (changed)
            {
                OnAnimationCurveChangedHandler();
            }
        }
        GUI.color = Color.white;
    }

    #endregion

    #region

    /// <summary>
    /// 
    /// </summary>
    private void OnAnimationCurveChangedHandler()
    {
        if (OnCurveChanged != null)
        {
            UAnimationCurveEventArgs args = new UAnimationCurveEventArgs(this, _curve);
            OnCurveChanged(args);
        }
    }

    #endregion
}
