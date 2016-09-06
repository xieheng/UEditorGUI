using UnityEngine;

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
public delegate void UEnumChangedEventHandler(UEnumEventArgs args);

/// <summary>
/// 
/// </summary>
/// <param name="args"></param>
public delegate void UToggleChangedEventHandler(UToggleEventArgs args);