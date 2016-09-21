using UnityEngine;
using UnityEditor;
using UEditorGUI;

/// <summary>
/// 
/// </summary>
class InspectorDemoObject : UInspectorTargetObject
{
    
}

/// <summary>
/// A demo of UInspector
/// </summary>
[CustomEditor(typeof(InspectorDemoObject))]
public class InspectorDemo : UInspector
{
    public InspectorDemo()
    {
        ULabel label = new ULabel("Label");
        AddWidget(label);

        UTextField textField = new UTextField("Text Filed");
        AddWidget(textField);
    }
}
