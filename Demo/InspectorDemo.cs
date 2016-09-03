using UnityEngine;
using UnityEditor;

class InspectorDemoObject : ScriptableObject
{
    
}

[CustomEditor(typeof(InspectorDemoObject))]
public class InspectorDemo : UInspector
{
    public InspectorDemo()
    {
        
    }
}
