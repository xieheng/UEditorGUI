using UnityEngine;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    public delegate void UEventHandler(UEventArgs args);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    public delegate void UTextChangedEventHandler(UTextEventArgs args);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    public delegate void UIntChangedEventHandler(UIntEventArgs args);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    public delegate void UFloatChangedEventHandler(UFloatEventArgs args);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    public delegate void UEnumChangedEventHandler(UEnumEventArgs args);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    public delegate void UToggleChangedEventHandler(UToggleEventArgs args);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    public delegate void UObjectChangedEventHandler(UObjectEventArgs args);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    public delegate void UBoundsChangedEventHandler(UBoundsEventArgs args);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    public delegate void UColorChangedEventHandler(UColorEventArgs args);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    public delegate void UAnimationCurveEventHandler(UAnimationCurveEventArgs args);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    public delegate void UVector2EventHandler(UVector2EventArgs args);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    public delegate void UVector3EventHandler(UVector3EventArgs args);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    public delegate void UVector4EventHandler(UVector4EventArgs args);
}